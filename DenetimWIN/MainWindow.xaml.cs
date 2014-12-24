using DenetimWIN.View;
using DevExpress.Xpf.Docking;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace DenetimWIN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            nvItemTümSüreçler.Click += nvItemTümSüreçler_Click;
        }

        void nvItemTümSüreçler_Click(object sender, EventArgs e)
        {
            //DocumentPanel page = new DocumentPanel();
            //DosyaKayıtListView uc = new DosyaKayıtListView();
           
            //page.Content = uc;
            //page.Caption = "Süreç Listesi";

            //mdiContainer.Add(page);
        }

        private void nav_evrakkayıt_Click(object sender, EventArgs e)
        {
            DocumentPanel page = new DocumentPanel();

            EvrakKayıtListView evrak = new EvrakKayıtListView();
            page.Content = evrak;
            page.Caption = "Evrak Listesi";

            mdiContainer.Add(page);

        }
    }
}
