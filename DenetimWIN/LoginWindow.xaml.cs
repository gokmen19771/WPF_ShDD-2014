
using DenetimMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DenetimWIN;
using System.Configuration;
using System.Collections.Specialized;

namespace dxDenetim2013.View
{
    /// <summary>
    /// Interaction logic for KullanıcıWindow.xaml
    /// </summary>
    public partial class KullanıcıWindow : Window
    {
        public KullanıcıWindow()
        {
            InitializeComponent();
        }

     

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Kullanicilar kul = new Kullanicilar();

            string host = ConfigurationManager.AppSettings.Get("host");
       


            Utils.Client = new HttpClient();
            Utils.Client.BaseAddress = new Uri(host);


            var username = txtKullanici.Text;
            var password = txtParola.Text;


            var accountUri = @"Account/Login";
          
            var authRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(accountUri,UriKind.RelativeOrAbsolute),
                Content = new FormUrlEncodedContent(
                    new List<KeyValuePair<string, string>> {                            
                    new KeyValuePair<string, string>("Username", username), 
                    new KeyValuePair<string, string>("Password", password)
            })
            };

            
            try 
	        {	        
		         var authResponse = Utils.Client.SendAsync(authRequest).Result;
                 authResponse.EnsureSuccessStatusCode();
	        }
	        catch (Exception ex)
	        {
                MessageBox.Show(ex.Data.ToString()); return;
	        }



            HttpResponseMessage response = Utils.Client.GetAsync(@"Api/Kullanicilar/" + username).Result;
                       
            Utils.AktifKullanıcı = response.Content.ReadAsAsync<Kullanicilar>().Result;

            MainWindow w = new MainWindow();
            w.Title = "Server Ip:" + host +  "  Kullanıcı:" + Utils.AktifKullanıcı.KullaniciAdSoyad;


            w.Show();
            this.Close();

          
           
        }
    }
}
