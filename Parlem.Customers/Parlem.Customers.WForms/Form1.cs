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
            string respuesta = await GetHttp();
            List<ViewModel.CustomerViewModel> list = JsonConvert.DeserializeObject<List<ViewModel.CustomerViewModel>>(respuesta);
            dataGridView3.DataSource = list;
        }

        private async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create("http://localhost:61992/api/Customer");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
    }
}
