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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace U
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //knap for at komme hen til spiller vinduet
        private void btnSpiller_Click(object sender, RoutedEventArgs e)
        {
            SpillereUI spillere = new SpillereUI();

            spillere.Show();

            close();
        }
        
        //knap for at komme hent il ansatte vinduet 
        private void btnAnsatte_Click(object sender, RoutedEventArgs e)
        {
            AnsatUIVinue ansatUIVinue = new AnsatUIVinue();

            ansatUIVinue.Show();

            close();
        }

        //knap for at komme hen til sponser vinduet
        private void btnSponsorer_Click(object sender, RoutedEventArgs e)
        {
            Sponserer sponserer = new Sponserer();

            sponserer.Show();

            close();
        }

        //knap for at komme hen til turnerings vinduet
        private void btnTurneringer_Click(object sender, RoutedEventArgs e)
        {
            Turneringer turneringer = new Turneringer();

            turneringer.Show();

            close();
        }

        //Knap for at komme hen til playercheck vinduet
        private void btnPlayerCheck_Click(object sender, RoutedEventArgs e)
        {
            PlayerCheck playerCheck = new PlayerCheck();

            playerCheck.Show();

            close();
        }

        //Methode for at lukke et vindue
        private void close()
        {
            this.close();
        }
    }
}
