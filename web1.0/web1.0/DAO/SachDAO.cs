using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web1._0.Models;

namespace web1._0.DAO
{
    public class SachDAO
    {
        SanSachCu db = null;
        public SachDAO()
        {
            db = new SanSachCu();
        }
        public IEnumerable<Sach> getListHistoryTransaction()
        {
            IEnumerable<Sach> listSach = from book in db.Saches where book.tinhtrang == true orderby book.ngaydang select book ;
            return listSach;
        }
        public IEnumerable<Sach> getListSaleBook()
        {
            IEnumerable<Sach> listSach = from book in db.Saches where book.tinhtrang == false orderby book.ngaydang select book;
            return listSach;
        }

    }
}