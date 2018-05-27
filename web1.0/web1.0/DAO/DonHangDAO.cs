using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web1._0.Models;

namespace web1._0.DAO
{
    public class DonHangDAO
    {
        SanSachCu db = null;
        
        public DonHangDAO()
        {
            
            db = new SanSachCu();
        }
        public Boolean Insert(DonHang entity)
        {
            db.DonHangs.Add(entity);
            Boolean temp = true;
            
            
            try
            {
               db.SaveChanges();
            }
            catch (Exception ex)
            { 
                temp = false;
            }

            return temp;
        }
    }
}