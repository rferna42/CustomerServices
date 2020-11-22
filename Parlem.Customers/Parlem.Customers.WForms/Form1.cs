using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parlem.Customers.WForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task<string> GetCustomerHttp()
        {
            WebRequest oRequest = WebRequest.Create("http://localhost:61992/api/Customer");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private async Task<string> GetProductHttp()
        {
            WebRequest oRequest = WebRequest.Create("http://localhost:61992/api/Product");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private async Task<string> GetCustomerProductHttp()
        {
            var uri = "http://localhost:61992/api/Forms?customerDocNum=" + textBox1.Text;
            WebRequest oRequest = WebRequest.Create(uri);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string customerProduct = await GetCustomerProductHttp();
            List<DataBase.Model.ViewModel.CustomerProductViewModel> list = JsonConvert.DeserializeObject<List<DataBase.Model.ViewModel.CustomerProductViewModel>>(customerProduct);
            dataGridView3.DataSource = list;
        }
    }
}
