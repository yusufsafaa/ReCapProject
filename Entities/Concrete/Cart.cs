using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Cart:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public int TotalPrice { get; set; }
        public int RentedDay { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
