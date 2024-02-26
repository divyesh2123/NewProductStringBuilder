using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProductStringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (EDMSEntities d= new EDMSEntities())
            {
                var users = d.Users.ToList();
                var mytemplate = d.EmailTemplates.FirstOrDefault(y => y.NameOf == "ProductEmail");
              
                foreach(var d1 in users)
                {
                    var p = new StringBuilder(mytemplate.Body);

                    p.Replace("##FirstName##", d1.Name);
                    p.Replace("##LastName##", d1.UserName);
                    p.Replace("##ProductName##", "New Course for nest.js");
                    EmailHelper.sendEmail(d1.Email,p.ToString(),mytemplate.Title);

                }
            }
        }
    }
}
