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
using Corespa.Models;

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
          
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var repo = new UserRepository();
            var user = new User()
            {
                Document = txtDocument.Text.Trim(),
                 Name = txtName.Text.Trim(),
                 Birthday = dtpBirthday.Value,
                 Email = txtEmail.Text.Trim(),
                 Celphone = txtCelPhone.Text.Trim(),
                 Phone = int.Parse(txtPhone.Text.Trim()),
                 Profesion = txtProfesion.Text.Trim(),
                 Activity = txtActivity.Text.Trim(),
                 PollingPlace = txtPolingPlace.Text.Trim()
            };

            try
            {
                var response = repo.SaveUser(user);

                if (response > 0) MessageBox.Show("El registro se actualizó correctamente.");

            } catch 
            {
                MessageBox.Show("Se ha producido un errror, verifique la información ingresada.");
            }

            
        }

        private void FrmUserRegistration_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtDocument_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
