using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        ICreditCardService _creditCardService;
        public PaymentManager(IPaymentDal paymentDal, ICreditCardService creditCardService)
        {
            _paymentDal = paymentDal;
            _creditCardService = creditCardService;

        }
        public IDataResult<int> Pay(CreditCard creditCard, int customerId, decimal amount)
        {
            var result = _creditCardService.Validate(creditCard);

            if (result.Success)
            {
                if (creditCard.Balance < amount)
                {
                    return new ErrorDataResult<int>(-1, Messages.InsufficientCardBalance);
                }

                creditCard.Balance -= amount;
                _creditCardService.Update(creditCard);
                DateTime paymentDate = DateTime.Now;
                
                _paymentDal.Add(new Payment { Amount = amount, CustomerId = customerId, CreditCardId = creditCard.Id, PaymentDate = paymentDate });

                var paymentId = _paymentDal.Get(p => p.CustomerId == customerId && p.Amount == amount && p.CreditCardId == creditCard.Id && (p.PaymentDate.Date == paymentDate.Date && p.PaymentDate.Hour == paymentDate.Hour && p.PaymentDate.Second == paymentDate.Second)).Id;
                return new SuccessDataResult<int>(paymentId, Messages.PaymentSuccessful);
            }

            return new ErrorDataResult<int>(-1, result.Message);
        }
    }
}
