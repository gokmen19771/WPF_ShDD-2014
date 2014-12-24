using DevExpress.Xpf.Grid;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Data.Filtering;


namespace DenetimWIN.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EvrakKayıtListView : UserControl
    {
        public EvrakKayıtListView()
        {
            InitializeComponent();
            this.Loaded += EvrakKayıt_Loaded;

            
            btnDüzenle.ItemClick += btnDüzenle_Click;
            btnExcel.ItemClick += btnExcel_Click;
            btnYeni.ItemClick += btnYeni_Click;
            btnİlgiYeni.ItemClick += btnİlgiYeni_Click;

           
        }
    

        void EvrakKayıt_Loaded(object sender, RoutedEventArgs e)
        {
            KayıtGetir();
        }

        ObservableCollection<EvrakKayıtEski> liste;
        
        private async void KayıtGetir()
        {
            view1.SearchControl = null;

            string aranan = "";
            string tamEşleşmeMi = "1";


            if (chk1 != null) tamEşleşmeMi = chk1.IsChecked.Value ? "1" : "0";

            if (txtSearch != null) aranan = txtSearch.SearchText;
        

            grd.ShowLoadingPanel = true;

            string param = "param=" + aranan + ";" + biDönecekKayıtSayısı.EditValue + ";" + tamEşleşmeMi;


            HttpResponseMessage response = await Utils.Client.GetAsync(@"Api/EvrakKayıtEski?" + param);


            if (response.IsSuccessStatusCode)
            {
                liste = response.Content.ReadAsAsync<ObservableCollection<EvrakKayıtEski>>().Result;
                grd.ItemsSource = liste;
            }

            grd.ShowLoadingPanel = false;

            view1.SearchControl = txtSearch;
        }

   
    

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.SaveFileDialog folder = new System.Windows.Forms.SaveFileDialog();
            folder.Filter = "*.xlsx|*.xlsx|*.xls|*.xls";

            folder.FilterIndex = 1;


            System.Windows.Forms.DialogResult dia = folder.ShowDialog();

            if (dia == System.Windows.Forms.DialogResult.OK)
            {
                if (folder.FilterIndex == 1)
                    view1.ExportToXlsx(folder.FileName);
                else
                    view1.ExportToXls(folder.FileName);
            }

           

        }


        void btnYeni_Click(object sender, RoutedEventArgs e)
        {
            YeniEvrak("");
        }


        void btnİlgiYeni_Click(object sender, RoutedEventArgs e)
        {
            YeniEvrak("İlgidenYeni");
        }


        public void YeniEvrak(string YeniTip)
        {
            EvrakKayıtEski seciliEvrak = grd.SelectedItem as EvrakKayıtEski;


            EvrakEditView w = new EvrakEditView();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            EvrakKayıtEski evrak = new EvrakKayıtEski();

         
            if (seciliEvrak != null && YeniTip == "İlgidenYeni")
            {
                evrak.KayitNo = seciliEvrak.KayitNo;
                evrak.Konu = seciliEvrak.Konu;
                evrak.KonuBasligi = seciliEvrak.KonuBasligi;
                evrak.KaldirildigiKlasor = seciliEvrak.KaldirildigiKlasor;
                evrak.KlasorSiraNo = seciliEvrak.KlasorSiraNo;
            }
         
            w.DataContext = evrak;

            bool? result = w.ShowDialog();
            if (result == false) return;



            HttpResponseMessage response = Utils.Client.PostAsJsonAsync(@"Api/EvrakKayıtEski", evrak).Result;


            evrak = response.Content.ReadAsAsync<EvrakKayıtEski>().Result;

            liste.Add(evrak);

            grd.View.ScrollIntoView(grd.VisibleRowCount - 1);
        
        }


        private void btnDüzenle_Click(object sender, RoutedEventArgs e)
        {
            EvrakEditView w = new EvrakEditView();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            EvrakKayıtEski evrak = grd.SelectedItem as EvrakKayıtEski;



            w.DataContext = evrak;

            bool? result = w.ShowDialog();

            bool editModuMu = (result == true && evrak.Id != 0);

            if (editModuMu == false) return;



            HttpResponseMessage response = Utils.Client.PutAsJsonAsync(@"Api/EvrakKayıtEski/" + evrak.Id, evrak).Result;

            evrak = response.Content.ReadAsAsync<EvrakKayıtEski>().Result;

            grd.RefreshRow(grd.View.FocusedRowHandle);
        }

        CheckEdit chk1;
        SearchControl txtSearch;
        Button btnAra;
       
        private void DockPanel_Loaded(object sender, RoutedEventArgs e)
        {
            DockPanel dp = sender as DockPanel;

            chk1 = dp.Children[0] as CheckEdit; chk1.EditValueChanged += chk1_EditValueChanged;
            txtSearch = dp.Children[1] as SearchControl; txtSearch.KeyDown += txtSearch_KeyDown;
            btnAra = dp.Children[2] as Button; btnAra.Click += btnAra_Click;

            view1.SearchControl = txtSearch;
            
        }

        void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                KayıtGetir();
            }
        }

        private void btnAra_Click(object sender, RoutedEventArgs e)
        {
            KayıtGetir();
        }

  
        private void chk1_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {

            KayıtGetir();
        }

    }
}
