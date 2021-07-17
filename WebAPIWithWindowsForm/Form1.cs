using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities.Dtos.UserDtos;
using Entities.Enums;

namespace WebAPIWithWindowsForm
{
    public partial class Form1 : Form
    {
        #region Defines

        private string url = "http://localhost:63545/api/";
        private int selectedID = 0;

        #endregion Defines

        #region Form1

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            await DataGirdViewFill();
            CmbGenderFill();
        }

        #endregion Form1

        #region Crud

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                UserAddDto userAddDto = new UserAddDto()
                {
                    FirstName = txtFirstName.Text,
                    Address = txtAddress.Text,
                    DateOfBirth = Convert.ToDateTime(dtpDateOfBirth.Text),
                    Email = txtEmail.Text,
                    Gender = cmbGender.Text == "Erkek" ? true : false,
                    LastName = txtLastName.Text,
                    Password = txtPassword.Text,
                    UserName = txtUserName.Text
                };
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(url + "Users/Add", userAddDto);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Ekleme işlemi başarılı!");
                    await DataGirdViewFill();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Ekleme işlemi başrısız!");
                }
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                UserUpdateDto userUpdateDto = new UserUpdateDto()
                {
                    Id = selectedID,
                    FirstName = txtFirstName.Text,
                    Address = txtAddress.Text,
                    DateOfBirth = Convert.ToDateTime(dtpDateOfBirth.Text),
                    Email = txtEmail.Text,
                    Gender = cmbGender.Text == "Erkek" ? true : false,
                    LastName = txtLastName.Text,
                    Password = txtPassword.Text,
                    UserName = txtUserName.Text
                };
                HttpResponseMessage response = await httpClient.PutAsJsonAsync(url + "Users/Update", userUpdateDto);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Düzenleme işlemi başarılı!");
                    await DataGirdViewFill();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Düzenleme işlemi başrısız!");
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync(url + "Users/Delete/" + selectedID);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Silme işlemi başarılı!");
                    await DataGirdViewFill();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Silme işlemi başrısız!");
                }
            }
        }

        private async void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            selectedID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            using (HttpClient httpClient = new HttpClient())
            {
                var user = await httpClient.GetFromJsonAsync<UserDto>(url + "Users/GetById/" + selectedID);

                txtAddress.Text = user.Address;
                cmbGender.SelectedValue = user.Gender == true ? 1 : 2;
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtUserName.Text = user.UserName;
                txtEmail.Text = user.Email;
                txtPassword.Text = String.Empty;
                dtpDateOfBirth.Value = user.DateOfBirth;
            }
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        #endregion Crud

        #region Methods

        private void CmbGenderFill()
        {
            List<Gender> genders = new List<Gender>();
            genders.Add(new Gender() { Id = 1, GenderName = "Erkek" });
            genders.Add(new Gender() { Id = 2, GenderName = "Kadın" });
            cmbGender.DataSource = genders;
            cmbGender.DisplayMember = "GenderName";
            cmbGender.ValueMember = "Id";
        }

        private class Gender
        {
            public int Id { get; set; }
            public string GenderName { get; set; }
        }

        private async Task DataGirdViewFill()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var users = await httpClient.GetFromJsonAsync<List<UserDetailDto>>(url + "Users/GetList");
                dataGridView1.DataSource = users;
            }
        }

        private void ClearForm()
        {
            txtAddress.Text = String.Empty;
            cmbGender.SelectedValue = 0;
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtUserName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtPassword.Text = String.Empty;
            dtpDateOfBirth.Value = DateTime.Now;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        #endregion Methods
    }
}