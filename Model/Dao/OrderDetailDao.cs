using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDetailDao
    {
        ProjectShopDbContext db = null;
        public OrderDetailDao()
        {
            db = new ProjectShopDbContext();
        }
        public bool Insert(OrderDetail orderdetail)
        {
            try
            {
                db.OrderDetails.Add(orderdetail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
