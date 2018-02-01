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

        public int SaveUser(User userToSave)
        {
            var flag = 0;
            using (var context = new Context())
            {
                var user = new User();

                user = context.Users.FirstOrDefault(c => c.Document == userToSave.Document);

                if (user == null)
                {

                    user = new User
                    {
                        Document = userToSave.Document,
                        Name = userToSave.Name,
                        Birthday = userToSave.Birthday,
                        Email = userToSave.Email,
                        Celphone = userToSave.Celphone,
                        Phone = userToSave.Phone,
                        Profesion = userToSave.Profesion,
                        Activity = userToSave.Activity,
                        PollingPlace = userToSave.PollingPlace
                    };
                    context.Users.Add(user);
                    flag = 1;
                }
                else
                {
                    User u = context.Users.FirstOrDefault(cl => cl.Document == userToSave.Document);

                    u.Name = userToSave.Name;
                    u.Birthday = userToSave.Birthday;
                    u.Email = userToSave.Email;
                    u.Celphone = userToSave.Celphone;
                    u.Phone = userToSave.Phone;
                    u.Profesion = userToSave.Profesion;
                    u.Activity = userToSave.Activity;
                    u.PollingPlace = userToSave.PollingPlace;
                    flag = 2;
                }

                context.SaveChanges();

            }

            return flag;

        }




        //    public User GetUserByDocument()
        //{
        //    var user = new User();
        //    using (var context = new Context())
        //    {
        //        user = context.Users.FirstOrDefault(x => x.Documento == "8357559");
        //    }

        //    return user;
        //}

    }
}
