using Corespa.Models;
using Corespa.Repositories;
using System;
using System.Windows.Forms;
using System.Net.Mail;

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
                try
                {
                    var user = new User()
                    {
                        Document = txtDocument.Text.Trim(),
                        Name = txtName.Text.Trim(),
                        Birthday = dtpBirthday.Value,
                        Email = txtEmail.Text.Trim(),
                        Celphone = txtCelPhone.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Profesion = txtProfesion.Text.Trim(),
                        Activity = txtActivity.Text.Trim(),
                        PollingPlace = txtPolingPlace.Text.Trim(),
                        Neighborhood = txtNeighborhood.Text.Trim()
                    };
                    
                    new MailAddress(user.Email);                                            
                    
                    var response = repo.SaveUser(user);

                    CleanForm();

                    if (response > 0) MessageBox.Show("El registro se actualizó correctamente.");

                }
                catch (FormatException)
                {
                    MessageBox.Show("Formato de correo electrónico incorrecto.");
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
            txtNeighborhood.Text = string.Empty;
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
                    txtPhone.Text = user.Phone;
                    txtCelPhone.Text = user.Celphone;
                    txtActivity.Text = user.Activity;
                    txtProfesion.Text = user.Profesion;
                    txtPolingPlace.Text = user.PollingPlace;
                    txtNeighborhood.Text = user.Neighborhood;
                }
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Sólo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
