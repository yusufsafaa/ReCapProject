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
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;
        ICustomerCreditCardService _customerCreditCardService;
        public CreditCardManager(ICreditCardDal creditCardDal,ICustomerCreditCardService customerCreditCardService)
        {
            _creditCardDal = creditCardDal;
            _customerCreditCardService = customerCreditCardService;
        }

        public IDataResult<int> Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessDataResult<int>(creditCard.Id,Messages.SaveNewCreditCard);
        }

        public IDataResult<CreditCard> Get(string cardNumber, string expireYear, string expireMonth, string cvc, string cardHolderFullName)
        {
            var creditCard=GetCreditCardByCardInfo(cardNumber,expireYear,expireMonth,cvc,cardHolderFullName);
          
            if(creditCard == null )
            {
                return new ErrorDataResult<CreditCard>(Messages.CreditCardNotValid);
            }
            return new SuccessDataResult<CreditCard>(creditCard);
        }

        public IDataResult<CreditCard> GetById(int creditCardId)
        {
            var creditCard=_creditCardDal.Get(c=>c.Id==creditCardId);

            if(creditCard == null)
            {
                return new ErrorDataResult<CreditCard>(Messages.CreditCardNotFound);
            }
            return new SuccessDataResult<CreditCard>(creditCard,Messages.CreditCardListed);
        }

        public IDataResult<List<CreditCard>> GetCustomerCreditCards(int customerId)
        {
            var customerCreditCardsIdResult = _customerCreditCardService.GetCustomerCreditCardsId(customerId);

            List<CreditCard> customerCreditCards = new List<CreditCard>();
            foreach (var customerCreditCardId in customerCreditCardsIdResult.Data)
            {
                var creditCard = _creditCardDal.Get(c => c.Id == customerCreditCardId.CreditCardId);
                customerCreditCards.Add(creditCard);
            }

            return new SuccessDataResult<List<CreditCard>>(customerCreditCards);
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        public IResult Validate(CreditCard creditCard)
        {
            var validateResult = GetCreditCardByCardInfo(creditCard.CardNumber,creditCard.ExpireYear,creditCard.ExpireMonth,creditCard.Cvc,creditCard.CardHolderFullName);

            if(validateResult == null)
            {
                return new ErrorResult(Messages.CreditCardNotValid);
            }
            return new SuccessResult();
        }

        private CreditCard GetCreditCardByCardInfo(string cardNumber, string expireYear, string expireMonth, string cvc, string cardHolderFullName)
        {
            return _creditCardDal.Get(c => c.CardNumber == cardNumber &&
                                           c.ExpireYear == expireYear &&
                                           c.ExpireMonth == expireMonth &&
                                           c.Cvc == cvc &&
                                           c.CardHolderFullName == cardHolderFullName.ToUpperInvariant()); // Convert Turkish characters into standard characters.
        }
    }
}
