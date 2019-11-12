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
    /// Interaction logic for AnsatUIVinue.xaml
    /// </summary>
    public partial class AnsatUIVinue : Window
    {
        S2EksamenEntities db = new S2EksamenEntities();

        Ansatte ansat = new Ansatte();

        Ansatte Result;
        public AnsatUIVinue()
        {
            InitializeComponent();

            dtgShow();
        }

        //Knap for at tilføje en spiller
        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            ansat.Navn = tbName.Text;
            ansat.Løn = int.Parse(tbPay.Text);
            ansat.Jobtype = tbJobType.Text;
            ansat.Telefonnummer = int.Parse(tbCellphone.Text);
            ansat.Dommer = tbJudge.Text;

            db.Ansatte.Add(ansat);

            db.SaveChanges();

            dtgShow();
        }

        //Knap for at updatere en spiller
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int updateID = Convert.ToInt32(tbId.Text);
            var update = db.Ansatte.Where(w => w.Id == updateID).FirstOrDefault();

            Result.Navn = tbName.Text;
            Result.Telefonnummer = int.Parse(tbCellphone.Text);
            Result.Løn = int.Parse(tbPay.Text);
            Result.Jobtype = tbJobType.Text;
            Result.Dommer = tbJudge.Text;

            db.Entry(Result).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();

            dtgShow();
        }

        //Knap for at slette en spiller
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int deleteID = Convert.ToInt32(tbId.Text);
            var delete = db.Ansatte.Where(w => w.Id == deleteID).FirstOrDefault();
            if (delete != null)
            {
                db.Ansatte.Remove(delete);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Fejl: Ansat me det intastede ID exsisgterer ikke.");
            }

            dtgShow();
        }

        //Kanp for at vise indholdet af datagriddet
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            dtgShow();
        }

        //Knap for at komme til spiller vinudet 
        private void btnSpiller_Click(object sender, RoutedEventArgs e)
        {
            SpillereUI spillere = new SpillereUI();

            spillere.Show();

            close();   
        }

        //Knap for at komme til turnerings vinudet 
        private void btnTurneringer_Click(object sender, RoutedEventArgs e)
        {
            Turneringer turneringer = new Turneringer();

            turneringer.Show();

            close();
        }

        //Knap for at komme til Sponser vinudet 
        private void btnSponserer_Click(object sender, RoutedEventArgs e)
        {
            Sponserer sponserer = new Sponserer();

            sponserer.Show();

            close();
        }

        //Knap for at komme til PlayerCheck vinudet 
        private void btnPlayerCheck_Click(object sender, RoutedEventArgs e)
        {
            PlayerCheck playerCheck = new PlayerCheck();

            playerCheck.Show();

            close();
        }


        //methode for at vise indholdet af datagriddet
        private void dtgShow()
        {
            dtgInfo.ItemsSource = db.Ansatte.ToList<Ansatte>();
        }

        //Methode for at lukke et vindue
        private void close()
        {
            this.close();
        }




    }
}
