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
using System.Net;
using Newtonsoft.Json;
using System.Windows.Navigation;

namespace U
{
    /// <summary>
    /// Interaction logic for PlayerCheck.xaml
    /// </summary>
    public partial class PlayerCheck : Window
    {
        S2EksamenEntities db = new S2EksamenEntities();



        public PlayerCheck()
        {
            InitializeComponent();
        }

        //kanp for at komme hen til spiller vinduet
        private void btnSpiller_Click(object sender, RoutedEventArgs e)
        {
            SpillereUI spillere = new SpillereUI();

            spillere.Show();

            close();


        }

        //knap for at komme hen til ansatte vinduet
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

        //Knap for at komme hen til turnerings vinduet
        private void btnTurneringer_Click(object sender, RoutedEventArgs e)
        {
            Turneringer turneringer = new Turneringer();

            turneringer.Show();

            close();
        }


        //Knap for at se om en player findes
        private void btnPlayerCheck_Click(object sender, RoutedEventArgs e)
        {
            getPlayerCheck();
        }

        //Methode for at få et chekket om en player findes
        void getPlayerCheck()
        {
            string playerName = tbPlayerCheck.Text;

            using (WebClient web = new WebClient())
            {
                string url = string.Format(@"https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{0}?api_key=RGAPI-2bc80102-1a62-4e04-980a-f885a4df90dd", playerName);

                var json = web.DownloadString(url);

                var result = JsonConvert.DeserializeObject<SummonerInfo.root>(json);

                SummonerInfo.root output = result;

                tbPlayerCheckResult.Text = string.Format("{0}", output.summonerLevel);
            }
        }

        //Methode for at lukke et vindue
        private void close()
        {
            this.close();
        }



    }
}
