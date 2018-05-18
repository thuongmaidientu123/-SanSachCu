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


        public Boolean Insert(TaiKhoan entity)
        {
            db.TaiKhoans.Add(entity);
            Boolean temp = true;
            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                temp = false;
            }

            return temp;
        }

        public TaiKhoan getByUserName(string UserName)
        {
            return db.TaiKhoans.SingleOrDefault(a => a.tendangnhap == UserName);
            
        }

        public Boolean CheckLogin(string userName,string passWord)
        {
            var a = db.TaiKhoans.Count(x => x.tendangnhap == userName && x.matkhau == passWord);
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}