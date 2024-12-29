using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace HavamBatsinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = "https://api.openweathermap.org/data/2.5/forecast?lat=39.786251&lon=30.523749&appid=958b6e62783adba733c86c96dd551594&mode=xml&units=metric";
            XDocument havadurumu = XDocument.Load(path);
            XElement current = havadurumu.Root;
            
            XElement forecast = current.Element("forecast");
            XElement time = forecast.Element("time");
            XElement temperature = time.Element("temperature");
            MessageBox.Show(temperature.Attribute("value").Value);

            double dblsicaklik = Convert.ToDouble(current.Element("temperature").Attribute("value").Value.Replace(".",","));
            int sicaklik = Convert.ToInt32(dblsicaklik);
            lbl_sicaklik.Text = sicaklik.ToString() + "°C";
            lbl_sehir.Text = current.Element("city").Attribute("name").Value;
            double dblhissedilen = Convert.ToDouble(current.Element("feels_like").Attribute("value").Value.Replace(".", ","));
            int hissedilen = Convert.ToInt32(dblhissedilen);
            lbl_hissedilen.Text = "Hissedilen " + hissedilen.ToString() + "°C";

            //https://openweathermap.org/img/wn/10d@2x.png
            string hava = current.Element("weather").Attribute("value").Value;
            string ikon = current.Element("weather").Attribute("icon").Value;
            string imgpath = "http://openweathermap.org/img/wn/" + ikon + "@2x.png";
            pictureBox1.ImageLocation = imgpath;
            lbl_hava.Text = hava;


        }

    }
}
