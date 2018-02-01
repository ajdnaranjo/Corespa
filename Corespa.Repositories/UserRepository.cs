using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corespa.Models;

namespace Corespa.Repositories
{
    public class UserRepository
    {

        public List<DocType> GetDocTypes()
        {
            var docTypes = new List<DocType>();
            using (var context = new Context())
            {
                docTypes = context.DocTypes.ToList();
            }

            return docTypes;
        }



        public User GetUserByDocument()
        {
            var user = new User();
            using (var context = new Context())
            {
                user = context.Users.FirstOrDefault(x => x.Documento == "8357559");
            }

            return user;
        }

    }
}
