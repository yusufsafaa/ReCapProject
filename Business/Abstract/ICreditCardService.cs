using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<CreditCard> Get(string cardNumber, string expireYear, string expireMonth, string cvc, string cardHolderFullName);
        IDataResult<CreditCard> GetById(int creditCardId);
        IDataResult<List<CreditCard>> GetCustomerCreditCards(int customerId);
        IResult Validate(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IDataResult<int> Add(CreditCard creditCard);
    }
}
