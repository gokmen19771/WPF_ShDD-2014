using DenetimMVC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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

namespace DenetimWIN.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EvrakEditView : Window
    {

        List<KonuBasliklari> konuBaşlıkları;

        public List<KonuBasliklari> KonuBaşlıkları
        {
            get { return konuBaşlıkları; }
            set { konuBaşlıkları = value; }
        }



        public EvrakEditView()
        {
            InitializeComponent();


            HttpResponseMessage response = Utils.Client.GetAsync(@"Api/KonuBaşlıkları").Result;

        

            if (response.IsSuccessStatusCode)
            {
                KonuBaşlıkları = response.Content.ReadAsAsync<List<KonuBasliklari>>().Result;
                cboKonuBaşlık.ItemsSource = KonuBaşlıkları;
                cboKonuBaşlık.DisplayMember = "KonuBasligi";
                cboKonuBaşlık.ValueMember = "KonuBasligi";
                
            }

            SaveCommandBarButtonItem.ItemClick += SaveCommandBarButtonItem_ItemClick;
            CloseCommandBarButtonItem.ItemClick += CloseCommandBarButtonItem_ItemClick;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EvrakKayıtEski evrak = this.DataContext as EvrakKayıtEski;

            if (evrak.Id == 0)
            {
                txtİşlemiYapan.EditValue = Utils.AktifKullanıcı.KullaniciAdSoyad;
                txtİşlemTarihi.EditValue = DateTime.Now;
            }
        }

        void CloseCommandBarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.DialogResult = false;
        }

    

        void SaveCommandBarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            EvrakKayıtEski evrak = this.DataContext as EvrakKayıtEski;

            evrak.SonIslemYapan = Utils.AktifKullanıcı.KullaniciAdSoyad;
            evrak.SonIslemTarihi = DateTime.Now;

            if (evrak.Id == 0)
            {
                evrak.IslemYapan = Utils.AktifKullanıcı.KullaniciAdSoyad;
                evrak.IslemTarihi = DateTime.Now;
            }


            this.DialogResult = true;
        }

    

    
    }
}
