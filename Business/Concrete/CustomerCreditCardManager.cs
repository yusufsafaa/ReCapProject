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

        public IResult Add(CustomerCreditCard customerCreditCard)
        {
            _customerCreditCardDal.Add(customerCreditCard);
            return new SuccessResult();
        }
    }
}
