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
    /// Interaction logic for Spiller.xaml
    /// </summary>
    public partial class Sponserer : Window
    {
        S2EksamenEntities db = new S2EksamenEntities();

        Sponsorer Sponsorer = new Sponsorer();

        Sponsorer Result;

        public Sponserer()
        {
            InitializeComponent();

            dtgshow();
        }

        //Knap for vise datagriddet
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            dtgshow();
        }

        //Knap for at tilføje en sponser
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Sponsorer.Firmanavn = tbCompanyName.Text;
            Sponsorer.Branche = tbBranch.Text;
            Sponsorer.Spillerid = int.Parse(tbPlayerID.Text);
            Sponsorer.Spillernavn = tbPlayerName.Text;
            Sponsorer.Udgift = int.Parse(tbExpense.Text);

            db.Sponsorer.Add(Sponsorer);

            db.SaveChanges();

            dtgshow();
        }


        //knap for slette sponsere 
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (tbId.Text != "")
            {
                int deleteID = Convert.ToInt32(tbId.Text);
                var delete = db.Sponsorer.Where(w => w.SponsorerId == deleteID).FirstOrDefault();
                if (delete != null)
                {
                    db.Sponsorer.Remove(delete);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Fejl: Sponser med det indtastede ID exsiterer ikke.");
                }
            }

            dtgshow();
        }

        //knap for at updaterer sponser information
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int updateID = Convert.ToInt32(tbId.Text);
            var update = db.Sponsorer.Where(w => w.SponsorerId == updateID).FirstOrDefault();

            Result.Firmanavn = tbCompanyName.Text;
            Result.Branche = tbBranch.Text;
            Result.Spillerid = int.Parse(tbPlayerID.Text);
            Result.Spillernavn = tbPlayerName.Text;
            Result.Udgift = int.Parse(tbExpense.Text);

            db.Entry(Result).State = System.Data.Entity.EntityState.Modified;


            db.SaveChanges();

            dtgshow();
        }

        //Knap for at komme hen til spiller vinduet
        private void btnSpiller_Click(object sender, RoutedEventArgs e)
        {
            SpillereUI spillereUI = new SpillereUI();

            spillereUI.Show();

            close();
        }

        //Knap for at komme hen til ansatte vinduet
        private void btnAnsatte_Click(object sender, RoutedEventArgs e)
        {
            AnsatUIVinue ansatUIVinue = new AnsatUIVinue();

            ansatUIVinue.Show();

            close();
        }

        //Knap for at komme hen til player check vinduet
        private void btnPlayerCheck_Click(object sender, RoutedEventArgs e)
        {
            PlayerCheck playerCheck = new PlayerCheck();

            playerCheck.Show();

            close();
        }

        //knap for at komme hen til turnerings vinduet
        private void btnTurneringer_Click(object sender, RoutedEventArgs e)
        {
            Turneringer turneringer = new Turneringer();

            turneringer.Show();

            close();
        }

        
        //Methode for at vise indholdet af datagriddet
        private void dtgshow()
        {
            dtgInfo.ItemsSource = db.Sponsorer.ToList<Sponsorer>();
        }

        //Methode for at lukke et vindue
        private void close()
        {
            this.close();
        }




    }
}
