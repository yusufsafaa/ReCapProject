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
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IDataResult<int> Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessDataResult<int>(payment.Id,Messages.SuccessfulPayment);
        }

        public IDataResult<Payment> GetLastPaymentOfCustomer(int customerId)
        {
            var payments=_paymentDal.GetAll(p=>p.CustomerId==customerId);

            var lastPayment = payments.OrderByDescending(p => p.PaymentDate).First();
            return new SuccessDataResult<Payment>(lastPayment);
        }
    }
}
