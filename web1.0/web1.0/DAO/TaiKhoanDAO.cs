using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web1._0.Models;

namespace web1._0.DAO
{
    public class TaiKhoanDAO
    {
        SanSachCu db = null;
        public TaiKhoanDAO()
        {
            db = new SanSachCu();
        }


        public int Insert(TaiKhoan entity)
        {
            db.TaiKhoans.Add(entity);
            int temp = entity.ma;
            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                temp = -1;
            }

            return temp;
        }

        public List<TaiKhoan> getListTaiKhoan()
        {
            List<TaiKhoan> listtaikhoan = db.TaiKhoans.ToList();

            return listtaikhoan;
        }
        
    }
}