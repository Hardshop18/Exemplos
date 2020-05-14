using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;

namespace WooCommerc
{
    public partial class Form1 : Form
    {
        private Configuracao configuracao;
        private RestAPI _restApi;
        private WCObject _wc;

        public Form1()
        {
            InitializeComponent();
            configuracao = new Configuracao();
            _restApi = new RestAPI(configuracao.url, configuracao.wooKey, configuracao.wooSecret, requestFilter: RequestFilter, responseFilter: ResponseFilter);
            _restApi.Debug = true;
            _wc = new WCObject(_restApi);
        }
        private void RequestFilter(System.Net.HttpWebRequest request)
        {
            request.UserAgent = "WooCommerce.NET";
            string jsonString = JsonConvert.SerializeObject(request, Formatting.Indented);
            TraceRequest(jsonString);
            /*
                "Method: " + request.Method + Environment.NewLine +
                "AbsoluteUri: " + request.RequestUri.AbsoluteUri + Environment.NewLine +
                "OriginalString: " + request.RequestUri.OriginalString + Environment.NewLine +
                "ReadWriteTimeout: " + request.ReadWriteTimeout + Environment.NewLine +
                "Timeout: " + request.Timeout + Environment.NewLine
                );*/
        }

        private void ResponseFilter(System.Net.HttpWebResponse response)
        {
            string jsonString = JsonConvert.SerializeObject(response, Formatting.Indented);

            string resposta = "response: " + Environment.NewLine +
                              "X-QM-overview-time_taken: " + response.Headers["X-QM-overview-time_taken"] + Environment.NewLine +
                              "X-QM-overview-time_usage: " + response.Headers["X-QM-overview-time_usage"] + Environment.NewLine +
                              "X-QM-overview-memory: " + response.Headers["X-QM-overview-memory"] + Environment.NewLine + 
                              "X-QM-overview-memory_usage: " + response.Headers["X-QM-overview-memory_usage"] + Environment.NewLine;
            TraceRequest(resposta + jsonString);
        }

        public static void TraceRequest(string texto)
        {
            if (!Directory.Exists("Logs"))
                Directory.CreateDirectory("Logs");
            using (StreamWriter writer = new StreamWriter(string.Format("Logs/{0}TraceRequest.txt", DateTime.Now.ToString("yyyy-MM-dd")), true, Encoding.UTF8))
            {
                writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " - " + texto);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Produto(textBox1.Text);
        }

        public async void Produto(string id)
        {
            try
            {
                var consulta = new Dictionary<string, string>();
                consulta.Add("per_page", "100");
                if (id != "")
                    consulta.Add("include", id);
                var teste = await _wc.Product.GetAll(consulta);
                richTextBox1.Text = JsonConvert.SerializeObject(teste, Formatting.Indented);
            }
            catch (Exception e )
            {
                richTextBox1.Text = e.GetExceptionsMsg();
            }
        }

        public async void Orders(string id)
        {
            try
            {
                var consulta = new Dictionary<string, string>();
                consulta.Add("per_page", "100");
                if (id != "")
                    consulta.Add("product", id);
                var orders = await _wc.Order.GetAll(consulta);

                richTextBox1.Text = JsonConvert.SerializeObject(orders, Formatting.Indented);
            }
            catch (Exception e )
            {
                richTextBox1.Text = e.GetExceptionsMsg();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Orders(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
