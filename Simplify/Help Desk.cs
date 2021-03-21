using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using TextRank;

namespace Simplify
{
    public partial class Help_Desk : UserControl
    {
        public Help_Desk()
        {
            InitializeComponent();
        }

        static async void MakeRequest(string textInput, string anoReq, string uri)
        {
            using (var httpClient = new HttpClient())
            {
                /*var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString["model-version"] = "latest";
                queryString["showStats"] = "true";
                queryString["stringIndexType"] = "TextElements_v8";

                var uri = "https://simplifylytics.cognitiveservices.azure.com/text/analytics/v3.1-preview.1/entities/linking?" + queryString;*/
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "282cd5fa03de40d0ad34003a7f56a691");
                using (var request = new HttpRequestMessage(new HttpMethod(anoReq), uri))
                {
                    request.Headers.TryAddWithoutValidation("Accept", "application/json");

                    request.Content = new StringContent("{\"documents\": [{ \"language\": \"en\",\"id\": \"1\", \"text\": \"" + textInput + "\" }]}", Encoding.UTF8, "application/json");

                    using (var response = await httpClient.SendAsync(request))
                    {
                        using (HttpContent content1 = response.Content)
                        {
                            string mycontent = await content1.ReadAsStringAsync();
                            Console.WriteLine(mycontent);

                        }
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = System.IO.File.ReadAllText(@"WriteText.txt");

            
            var phrases = text.KeyPhrases();


            Form hideBg = new Form();
            try
            {
                using(Form3 form3 = new Form3(phrases.Item1))
                {
                    hideBg.StartPosition = FormStartPosition.Manual;
                    hideBg.FormBorderStyle = FormBorderStyle.None;
                    hideBg.Opacity = 0.70d;
                    hideBg.BackColor = Color.Black;
                    hideBg.WindowState = FormWindowState.Maximized;
                    hideBg.TopMost = true;
                    hideBg.Location = this.Location;
                    hideBg.ShowInTaskbar = false;
                    hideBg.Show();
                    form3.Owner = hideBg;

                    form3.ShowDialog();
                    hideBg.Dispose();
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                hideBg.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form hideBg = new Form();
            try
            {
                using (Form4 form4 = new Form4())
                {
                    hideBg.StartPosition = FormStartPosition.Manual;
                    hideBg.FormBorderStyle = FormBorderStyle.None;
                    hideBg.Opacity = 0.70d;
                    hideBg.BackColor = Color.Black;
                    hideBg.WindowState = FormWindowState.Maximized;
                    hideBg.TopMost = true;
                    hideBg.Location = this.Location;
                    hideBg.ShowInTaskbar = false;
                    hideBg.Show();
                    form4.Owner = hideBg;

                    form4.ShowDialog();
                    hideBg.Dispose();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                hideBg.Dispose();
            }
        }
    }
}
