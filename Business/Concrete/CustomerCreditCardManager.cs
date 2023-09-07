using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerCreditCardManager : ICustomerCreditCardService
    {
        ICustomerCreditCardDal _customerCreditCardDal;
        ICreditCardService _creditCardService;
        public CustomerCreditCardManager(ICustomerCreditCardDal customerCreditCardDal, ICreditCardService creditCardService)
        {
            _customerCreditCardDal = customerCreditCardDal;
            _creditCardService = creditCardService;

        }
        public IResult DeleteCustomerCreditCard(CustomerCreditCardModel customerCreditCardModel)
        {
            var creditCardToDeletedResult = _creditCardService.Get(customerCreditCardModel.CreditCard.CardNumber,
                                                             customerCreditCardModel.CreditCard.ExpireYear,
                                                             customerCreditCardModel.CreditCard.ExpireMonth,
                                                             customerCreditCardModel.CreditCard.Cvc,
                                                             customerCreditCardModel.CreditCard.CardHolderFullName.ToUpperInvariant());
            if (!creditCardToDeletedResult.Success)
            {
                return new ErrorResult(Messages.CreditCardNotFound);
            }

            CustomerCreditCard customerCreditCard = new CustomerCreditCard()
            {
                CustomerId = customerCreditCardModel.CustomerId,
                CreditCardId = customerCreditCardModel.CreditCard.Id
            };

            var result=GetCustomerCreditCard(customerCreditCard);

            if (result.Success)
            {
                _customerCreditCardDal.Delete(customerCreditCard);

                var controlResult = GetCustomerCreditCard(customerCreditCard);
                if (!controlResult.Success)
                {
                    return new SuccessResult(Messages.CustomerCreditCardDeleted);
                }
                return new ErrorResult(Messages.CustomerCreditCardFailedToDelete);
            }

            return new ErrorResult(Messages.CustomerCreditCardNotFound);
        }

        public IDataResult<List<CreditCard>> GetSavedCreditCardsByCustomerId(int customerId)
        {
            var userCreditCardsResult=_customerCreditCardDal.GetAll(c=>c.CustomerId == customerId);
            List<CreditCard> userCreditCards = new List<CreditCard>();
            foreach (var item in userCreditCardsResult)
            {
                var creditCard = _creditCardService.GetById(item.CreditCardId);
                if (creditCard.Success)
                {
                    userCreditCards.Add(creditCard.Data);
                }
                else
                {
                    return new ErrorDataResult<List<CreditCard>>(creditCard.Message);
                }
            }

            return new SuccessDataResult<List<CreditCard>>(userCreditCards,Messages.CustomerCreditCardsListed);
        }
        
        public IResult SaveCustomerCreditCard(CustomerCreditCardModel customerCreditCardModel)
        {
            var creditCardResult = _creditCardService.Get(customerCreditCardModel.CreditCard.CardNumber,
                                                        customerCreditCardModel.CreditCard.ExpireYear,
                                                        customerCreditCardModel.CreditCard.ExpireMonth,
                                                        customerCreditCardModel.CreditCard.Cvc,
                                                        customerCreditCardModel.CreditCard.CardHolderFullName.ToUpperInvariant());
            if (!creditCardResult.Success)
            {
                return new ErrorResult(creditCardResult.Message);
            }

            CustomerCreditCard customerCreditCard = new CustomerCreditCard()
            {
                CustomerId = customerCreditCardModel.CustomerId,
                CreditCardId = creditCardResult.Data.Id
            };

            var customerCreditCardExist=_customerCreditCardDal.GetAll(c=>c.CustomerId==customerCreditCard.CustomerId && c.CreditCardId==customerCreditCard.CreditCardId);

            if (customerCreditCardExist.Count() > 0)
            {
                return new ErrorResult(Messages.CustomerCreditCardAlreadySaved);
            }

            _customerCreditCardDal.Add(customerCreditCard);

            var result = GetCustomerCreditCard(customerCreditCard);
            if (!result.Success)
            {
                return new ErrorResult(Messages.CustomerCreditCardFailedToSave);
            }
            return new SuccessResult(Messages.CustomerCreditCardSaved);
        }

        private IDataResult<CustomerCreditCard> GetCustomerCreditCard(CustomerCreditCard customerCreditCard)
        {
            var result = _customerCreditCardDal.Get(c => c.CustomerId == customerCreditCard.CustomerId && c.CreditCardId == customerCreditCard.CreditCardId);

            if(result !=null)
            {
                return new SuccessDataResult<CustomerCreditCard>(result);
            }
            return new ErrorDataResult<CustomerCreditCard>();
        }
    }
}
