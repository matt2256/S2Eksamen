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
    /// Interaction logic for Turneringer.xaml
    /// </summary>
    public partial class Turneringer : Window
    {
        S2EksamenEntities db = new S2EksamenEntities();

        Tuneringer Tuneringer = new Tuneringer();

        Tuneringer Result;
        public Turneringer()
        {
            InitializeComponent();

            dtgshow();
        }

        //Knap for at vise indholdet af datagriddet
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            dtgshow();
        }

        //knap for at tilføje en turnering
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Tuneringer.Tuneringsnavn = tbTurneyName.Text;
            Tuneringer.Spillerid = int.Parse(tbId.Text);
            Tuneringer.Spillernavn = tbName.Text;
            Tuneringer.Spillertelefon = int.Parse(tbCellPhone.Text);
            Tuneringer.Dommerid = int.Parse(tbJudgeId.Text);
            Tuneringer.Dommernavn = tbJudgeName.Text;
            Tuneringer.Dommertelefon = tbJudgeCellphone.Text;
            Tuneringer.Dommerlevel = tbJudgeLevel.Text;

            db.Tuneringer.Add(Tuneringer);

            db.SaveChanges();

            dtgshow();
        }

        //knap for at updatere en turnering 
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int updateID = Convert.ToInt32(tbId.Text);
            var update = db.Tuneringer.Where(w => w.TurneringsId == updateID).FirstOrDefault();

            Result.Tuneringsnavn = tbTurneyName.Text;
            Result.Spillernavn = tbName.Text;
            Result.Spillertelefon = int.Parse(tbCellPhone.Text);
            Result.Dommerid = int.Parse(tbJudgeId.Text);
            Result.Dommernavn = tbJudgeName.Text;
            Result.Dommertelefon = tbJudgeCellphone.Text;
            Result.Dommerlevel = tbJudgeLevel.Text;

            db.Entry(Result).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();

            dtgshow();
        }

        //knap for at slett en turnering
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (tbId.Text != "")
            {
                int deleteID = Convert.ToInt32(tbId.Text);
                var delete = db.Tuneringer.Where(w => w.TurneringsId == deleteID).FirstOrDefault();
                if (delete != null)
                {
                    db.Tuneringer.Remove(delete);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("FejL: Turnering med det indtastede ID exsisterer ikke.");
                }
            }

            dtgshow();
        }

        //knap for at komme hen til spiller vinduet 
        private void btnSpiller_Click(object sender, RoutedEventArgs e)
        {
            SpillereUI spillereUI = new SpillereUI();

            spillereUI.Show();

            close();
        }

        //knap for at komme hen til sponser vinduet
        private void btnSponsorer_Click(object sender, RoutedEventArgs e)
        {
            Sponserer sponserer = new Sponserer();

            sponserer.Show();

            close();
        }

        //knap for at komme hen til ansatte vinduet
        private void btnAnsatte_Click(object sender, RoutedEventArgs e)
        {
            AnsatUIVinue ansatUIVinue = new AnsatUIVinue();

            ansatUIVinue.Show();

            close();
        }

        //knap for at komme til player check vinduet 
        private void btnPlayerCheck_Click(object sender, RoutedEventArgs e)
        {
            PlayerCheck playerCheck = new PlayerCheck();

            playerCheck.Show();

            close();
        }

        //Methode for at vise indholdet af datagriddet 
        private void dtgshow()
        {
            dtgInfo.ItemsSource = db.Tuneringer.ToList<Tuneringer>();
        }

        //Methode for at lukke et vindue
        private void close()
        {
            this.close();
        }




    }
}
