using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using Entities.Dtos.UserDtos;

namespace WebAPIWithWindowsForm
{
    public partial class Form1 : Form
    {
        private string url = "http://localhost:63545/api/Users/GetList";

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var users = await httpClient.GetFromJsonAsync<List<UserDetailDto>>(new Uri(url));
                dataGridView1.DataSource = users;
            }
        }
    }
}