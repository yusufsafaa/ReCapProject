using Business.Abstract;
using Entities.Concrete;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private ICustomerCreditCardService _customerCreditCardService;
        private ICreditCardService _creditCardService;
        public CreditCardsController(ICustomerCreditCardService customerCreditCardService, ICreditCardService creditCardService)
        {
            _customerCreditCardService = customerCreditCardService;
            _creditCardService = creditCardService;
        }

        [HttpPost("savecreditcard")]
        public IActionResult SaveCreditCard(CreditCard creditCard)
        {
            var result = _creditCardService.Add(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("savecreditcardtocustomer")]
        public IActionResult SaveCreditCardToCustomer(CustomerCreditCard customerCreditCard)
        {
            var result = _customerCreditCardService.Add(customerCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
