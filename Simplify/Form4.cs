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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Simplify
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private async void Form4_LoadAsync(object sender, EventArgs e)
        {
            string content = @"Do you have a history of hypertension in your family? …So your father and your grandmother has hypertension, I see I see. Okay I will now place an inflatable arm cuff on your arm to monitor your blood pressure… oh, you have a blood pressure of 141/92.
Oookay. Bad news first, you are diagnosed with Stage 2 Hypertension, don’t worry Morrison, here is the good news: this can be treated as long as you remember to take your required medication. 
for your prescription: I’m going to have you take 5 milligrams of amlodipine everyday. Now please, do not miss a day of your meds, and as with every other medicine, you should only be eating this after every meal if you can. As for your treatment, besides watching what you eat it is recommended that you lose weight. According to your record, you are 78 kilograms... your treatment will be smoother if you try to lose weight. Even if you did have a lower blood pressure on your next check up, please do not stop on your medication. It is very important.";
            string joms = "{\"documents\": [{ \"language\": \"en\",\"id\": \"1\", \"text\": \"" + Help_Desk._textRead + "\" }]}";


            using (var httpClient = new HttpClient())
            {

                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString["model-version"] = "latest";
                queryString["showStats"] = "true";
                //queryString["stringIndexType"] = "TextElements_v8";

                var uri = "https://simplifylytics.cognitiveservices.azure.com/text/analytics/v3.1-preview.1/entities/linking?" + queryString;
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "282cd5fa03de40d0ad34003a7f56a691");
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), uri))
                {
                    request.Headers.TryAddWithoutValidation("Accept", "application/json");


                    request.Content = new StringContent(joms, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.SendAsync(request))
                    {
                        using (HttpContent content1 = response.Content)
                        {
                            string contentmy = await content1.ReadAsStringAsync();

                            var jo = JObject.Parse(contentmy);
                            //var te = JObject.Parse();

                            string jomsTest = jo["documents"][0]["entities"].ToString();
                            var array = JArray.Parse(jomsTest);


                            int basex = panel1.Location.X;
                            int basey = panel1.Location.Y;
                            foreach (var item in array)
                            {
                                Button b = new Button();
                                b.Left = basex;
                                b.Top = basey;
                                b.Size = new Size(240, 50); // <== add this line
                                basey += 60;

                                //MessageBox.Show(item.ToString());
                                b.Font = new System.Drawing.Font("Gotham", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                b.Text = item["name"].ToString();
                                b.FlatStyle = FlatStyle.Flat;

                                //b.Click += new EventHandler(b_Click);
                                panel1.Controls.Add(b);
                            }
                            
                        }
                    }
                }
            }
        }
    }
}
