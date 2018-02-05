using Corespa.Models;
using Corespa.Repositories;
using System;
using System.Windows.Forms;

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
      
        private void btnSave_Click(object sender, EventArgs e)
        {
            var repo = new UserRepository();

            if (ValidateFields())
            {

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

                    CleanForm();

                    if (response > 0) MessageBox.Show("El registro se actualizó correctamente.");

                }
                catch
                {
                    MessageBox.Show("Se ha producido un errror, verifique la información ingresada.");
                }
            }
            else
                MessageBox.Show("Verifique la información ingresada, faltan campos por diligenciar.");


        }

        private bool ValidateFields()
        {
            var flag = true;

            if (string.IsNullOrEmpty(txtDocument.Text.Trim())) flag = false;
            if (string.IsNullOrEmpty(txtName.Text.Trim())) flag = false;


            return flag;

        }

        private void CleanForm()
        {
            txtDocument.Text = string.Empty;
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtCelPhone.Text = string.Empty;
            txtProfesion.Text = string.Empty;
            txtActivity.Text = string.Empty;
            txtPolingPlace.Text = string.Empty;
            dtpBirthday.Value = DateTime.Now;
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

        private void txtDocument_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDocument.Text.Trim()))
            {
                var repo = new UserRepository();
                var user = repo.GetUserByDocument(txtDocument.Text.Trim());

                if (user != null)
                {
                    txtName.Text = user.Name;
                    dtpBirthday.Value = user.Birthday;
                    txtEmail.Text = user.Email;
                    txtPhone.Text = user.Phone.ToString();
                    txtCelPhone.Text = user.Celphone;
                    txtActivity.Text = user.Activity;
                    txtProfesion.Text = user.Profesion;
                    txtPolingPlace.Text = user.PollingPlace;
                }
            }
        }
    }
}
