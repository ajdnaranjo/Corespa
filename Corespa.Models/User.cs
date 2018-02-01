using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Corespa.Models
{
    public class User
    {
        public int Id { get; set; }        
        public string Document { get; set; }      
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Celphone { get; set; }
        public int Phone { get; set; }
        public string Profesion { get; set; }
        public string Activity { get; set; }
        public string PollingPlace { get; set; }

    }
}
