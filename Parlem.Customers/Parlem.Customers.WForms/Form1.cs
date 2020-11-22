using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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

        private async void Form1_Load(object sender, EventArgs e)
        {
            string customer = await GetCustomerHttp();
            List<DataBase.Model.ViewModel.CustomerViewModel> customerList = JsonConvert.DeserializeObject<List<DataBase.Model.ViewModel.CustomerViewModel>>(customer);
            dataGridView3.DataSource = customerList;

            string product = await GetProductHttp();
            List<DataBase.Model.ViewModel.ProductViewModel> productList = JsonConvert.DeserializeObject<List<DataBase.Model.ViewModel.ProductViewModel>>(product);
            dataGridView4.DataSource = productList;
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
    }
}
