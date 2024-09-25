using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace upisivanjePodatakaCSV
{
    public partial class Form1 : Form
    {
        List<Osoba> listaOsoba = new List<Osoba>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrisanje_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtGodinaRodjenja.Clear();
            txtIme.Clear();
            txtPrezime.Clear();
        }

        private void btnUpis_Click(object sender, EventArgs e)
        {
            // Osoba osoba = new Osoba();
            try
            {
                Osoba osoba = new Osoba(txtIme.Text,
                    txtPrezime.Text, txtEmail.Text,
                    Convert.ToInt16(txtGodinaRodjenja.Text));

                txtEmail.Clear();
                txtGodinaRodjenja.Clear();
                txtIme.Clear();
                txtPrezime.Clear();
                txtIme.Focus();

                DialogResult upit = MessageBox.Show("Želite li unijeti još podatka?", "Upit",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                switch (upit)
                {
                    case DialogResult.Yes:
                        {
                            listaOsoba.Add(osoba);
                            break;
                        }
                    case DialogResult.No:
                        {
                            
                            txtIme.Enabled = false;
                            txtPrezime.Enabled = false;
                            txtGodinaRodjenja.Enabled = false;
                            txtEmail.Enabled = false;
                            
                            break;
                        }
                }
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.Message, "Pogrešan unos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
