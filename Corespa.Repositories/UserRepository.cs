using Corespa.Models;
using System.Linq;
using System;
using System.IO;
using CsvHelper;
using System.Text;
using System.Windows.Forms;

namespace Corespa.Repositories
{
    public class UserRepository
    {

        public int SaveUser(User userToSave)
        {
            int flag;
            using (var context = new Context())
            {
                var user = context.Users.FirstOrDefault(c => c.Document == userToSave.Document);

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
                        PollingPlace = userToSave.PollingPlace,
                        Neighborhood = userToSave.Neighborhood
                    };
                    context.Users.Add(user);
                    flag = 1;
                }
                else
                {
                    var u = context.Users.FirstOrDefault(cl => cl.Document == userToSave.Document);

                    u.Name = userToSave.Name;
                    u.Birthday = userToSave.Birthday;
                    u.Email = userToSave.Email;
                    u.Celphone = userToSave.Celphone;
                    u.Phone = userToSave.Phone;
                    u.Profesion = userToSave.Profesion;
                    u.Activity = userToSave.Activity;
                    u.PollingPlace = userToSave.PollingPlace;
                    u.Neighborhood = userToSave.Neighborhood;
                    flag = 2;
                }

                context.SaveChanges();

            }

            return flag;

        }

        public User GetUserByDocument(string document)
        {
            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(x => x.Document == document);
            }
        }

        public void ExportUsers()
        {
            using (var mem = new MemoryStream())
            {
                using (var writer = new StreamWriter(mem))
                {
                    using (var csv = new CsvWriter(writer))
                    {
                        using (var context = new Context())
                        {

                            csv.Configuration.Delimiter = "|";

                            var users = context.Users.ToList();

                            csv.WriteField("Documento");
                            csv.WriteField("Nombre");
                            csv.WriteField("Fecha nacimiento");
                            csv.WriteField("Correo");
                            csv.WriteField("Celular");
                            csv.WriteField("Telefono");
                            csv.WriteField("Profesion");
                            csv.WriteField("Actividad");
                            csv.WriteField("Puesto votacion");
                            csv.WriteField("Barrio");

                            csv.NextRecord();

                            foreach (var user in users)
                            {
                                csv.WriteField(user.Document);
                                csv.WriteField(user.Name);
                                csv.WriteField(user.Birthday.ToString());
                                csv.WriteField(user.Email);
                                csv.WriteField(user.Celphone);
                                csv.WriteField(user.Phone);
                                csv.WriteField(user.Profesion);
                                csv.WriteField(user.Activity);
                                csv.WriteField(user.PollingPlace);
                                csv.WriteField(user.Neighborhood);

                                csv.NextRecord();
                            }
                        }
                    }
                    var result = Encoding.UTF8.GetString(mem.ToArray());
                    SaveFileDialog save = new SaveFileDialog
                    {
                        Filter = "CSV|*.csv|All file|*.*",
                        FilterIndex = 1
                    };
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(save.FileName, result);
                    }
                }
            }
        }
    }
}


