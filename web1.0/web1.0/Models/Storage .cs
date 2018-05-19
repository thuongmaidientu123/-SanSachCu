using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace web1._0.Models
{
    public class Storage
    {
        public void SaveUploadedFile(string path,
                                     HttpPostedFileBase sourceFile)
        {
            string name = Path.GetFileName(sourceFile.FileName);
            sourceFile.SaveAs(path + @"\" + name);
        }
    }
}