using System;
using System.Collections.Generic;
using System.IO;
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

namespace Jacopo.Bartoletti._5G.DataPump2
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int Nriga = 1;
        String[] colonna;
        List<Classe> Classi = new List<Classe>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter fileOut = new StreamWriter(@"C:\Users\jacop\Desktop\Jacopo.Bartoletti.5G.DataPump2\Jacopo.Bartoletti.5G.DataPump2\Dati.sql");

                int i = 0;


                for (; i < Classi.Count(); i++)
                {

                    fileOut.WriteLine("INSERT INTO \"Docenti\"(idclasse,nomeclasse,Specializazione,Articolazione,CodiceMinisteriale,Aula,Sede,Cordinatore,iddocente) VALUES ('" + Classi[i].idclasse.ToString() + "', '" + Classi[i].nomeclasse.ToString() + "', '" + Classi[i].Specializzazione.ToString() + "', '" + Classi[i].Articolazione.ToString() + "', '" + Classi[i].CodiceMinisteriale.ToString() + "', '" + Classi[i].Aula.ToString() + "', '" + Classi[i].Sede.ToString() + "', '" + Classi[i].Cordinatore.ToString() + "', '" + Classi[i].iddocente.ToString() + "');");

                }

                MessageBox.Show("Database Creato con successo");

                fileOut.Close();
            }
            catch
            {

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader FileIn = new StreamReader(@"C:\Users\Jacop\Desktop\Jacopo.Bartoletti.5G.DataPump2\Jacopo.Bartoletti.5G.DataPump2\Classi_2019-2.csv");
                FileIn.ReadLine();

                while (!FileIn.EndOfStream)
                {
                    try
                    {
                        string riga = FileIn.ReadLine();

                        colonna = riga.Split(';');

                        Classe c = new Classe();
                        c.ID = Convert.ToInt32(colonna[0]);
                        c.idclasse =colonna[1];
                        c.nomeclasse = colonna[2];
                        c.Specializzazione = colonna[3];
                        c.Articolazione = colonna[4];
                        c.CodiceMinisteriale = colonna[5];
                        c.Aula = colonna[6];
                        c.Sede = colonna[7];
                        c.Cordinatore = colonna[8];
                        c.iddocente = colonna[9];

                        Classi.Add(c);
                        Nriga++;
                    }
                    catch (Exception Erore)
                    {
                        MessageBox.Show(Erore.Message);
                    }
                }
            }
            catch (Exception Erore)
            {
                MessageBox.Show(Erore.Message);
            }

            dgDati.ItemsSource = Classi;
        }
    }

    //idclasse;nomeclasse;Specializzazione;Articolazione;CodiceMinisteriale;Aula;Sede;Cordinatore;iddocente
    public class Classe
    {
        public int ID { get; set; }
        public string idclasse { get; set; }

        public string nomeclasse { get; set; }

        public string Specializzazione { get; set; }

        public string Articolazione { get; set; }

        public string CodiceMinisteriale { get; set; }

        public string Aula { get; set; }

        public string Sede { get; set; }

        public string Cordinatore { get; set; }

        public string iddocente { get; set; }

        public Classe()
        {

        }
    }
}
