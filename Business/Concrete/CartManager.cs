using Business.Abstract;
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
    public class CartManager : ICartService
    {
        ICartDal _cartDal;
        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }
        public IResult Add(Cart cart)
        {
            _cartDal.Add(cart);
            return new SuccessResult();
        }

        public IResult Delete(Cart cart)
        {
            _cartDal.Delete(cart);
            return new SuccessResult();
        }

        public IResult DeleteAllByUserId(int userId)
        {
            var cartItems = _cartDal.GetAll(c => c.UserId == userId);

            foreach (var cartItem in cartItems)
            {
                _cartDal.Delete(cartItem);
            }
            return new SuccessResult();
        }

        public IDataResult<List<Cart>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<Cart>>(_cartDal.GetAll(c=>c.UserId==userId));
        }

        public IDataResult<Cart> GetById(int id)
        {
            return new SuccessDataResult<Cart>(_cartDal.Get(c=>c.Id==id));
        }

        public IResult Update(Cart cart)
        {
            _cartDal.Update(cart);
            return new SuccessResult();
        }
    }
}
