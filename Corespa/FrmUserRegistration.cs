using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Corespa.Repositories;

namespace Corespa
{
    public partial class FrmUserRegistration : Form
    {
        public FrmUserRegistration()
        {
            InitializeComponent();
            InitialLoad();
        }

        private void InitialLoad()
        {
            var repo = new UserRepository();
            cbDocType.DataSource =  repo.GetDocTypes();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var repo = new Repositories.UserRepository();
            var user = repo.GetUserByDocument();
        }
    }
}
