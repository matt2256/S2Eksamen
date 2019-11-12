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

namespace U
{
    /// <summary>
    /// Interaction logic for SpillereUI.xaml
    /// </summary>
    public partial class SpillereUI : Window
    {
        S2EksamenEntities db = new S2EksamenEntities();

        Spillere Spillere = new Spillere();

        Spillere Result;
        public SpillereUI()
        {
            InitializeComponent();

            dtgshow();
        }

        //knap for at vise datagriddet 
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            dtgshow();
        }

        //knap for at tilføje spiller 
        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            Spillere.SummonerNavn = tbSummonerName.Text;
            Spillere.Rang = int.Parse(tbRank.Text);
            Spillere.Tuneringstype = cbTurneyType.Text;

            db.Spillere.Add(Spillere);

            db.SaveChanges();

            dtgshow();
        }

        //knap for at slette spiller information
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (tbId.Text != "")
            {
                int deleteID = Convert.ToInt32(tbId.Text);
                var delete = db.Spillere.Where(w => w.SpillerId == deleteID).FirstOrDefault();
                if (delete != null)
                {
                    db.Spillere.Remove(delete);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Fejl: Spiller med det indtastede ID exsisterer ikke.");
                }
            }

            dtgshow();
        }

        //Knap for at updatere spiller information
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int updateID = Convert.ToInt32(tbId.Text);
            var update = db.Spillere.Where(w => w.SpillerId == updateID).FirstOrDefault();

            Result.Navn = tbName.Text;
            Result.SummonerNavn = tbSummonerName.Text;
            Result.Rang = int.Parse(tbRank.Text);
            Result.Telefonnummer = int.Parse(tbCellphone.Text);
            Result.Tuneringstype = cbTurneyType.Text;

            db.Entry(Result).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();

            dtgshow();
        }

        //Knap for at komme hen til turnerings vinduet
        private void btnTurneringer_Click(object sender, RoutedEventArgs e)
        {
            Turneringer turneringer = new Turneringer();

            turneringer.Show();

            close();
        }

        //Knap for at komme hen til ansatte vinduet
        private void btnAnsatte_Click(object sender, RoutedEventArgs e)
        {
            AnsatUIVinue ansat = new AnsatUIVinue();

            ansat.Show();

            close();
        }

        //Knap for at komme hen til playercheck vinduet
        private void btnPlayerCheck_Click(object sender, RoutedEventArgs e)
        {
            PlayerCheck playerCheck = new PlayerCheck();

            playerCheck.Show();

            close();
        }

        //knap for at komme hen til sponser vinduet
        private void btnSponsere_Click(object sender, RoutedEventArgs e)
        {
            Sponserer sponserer = new Sponserer();

            sponserer.Show();

            close();

            
        }

        //Methode for at vise datagriddet
        private void dtgshow()
        {
            dtgInfo.ItemsSource = db.Spillere.ToList<Spillere>();
        }

        //Methode for at lukke et vindue
        private void close()
        {
            this.close();
        }
    }
}
