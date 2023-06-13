using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNaturGmbH
{
    public partial class RechnungVerwalten : Form
    {
        //@"C:\Users\demir\Desktop\CSharp_Intensivkurs_Udemy\Abschnitt7-ProNaturGmbH\ProNaturGmbH\ProNaturGmbH\bin\Debug\NaturBioMarkt.db";
        private static string connString = "Data Source=./NaturBioMarkt.db;Version=3;";
        // Verbindung zur Datenbank erstellen
        private SQLiteConnection databaseConnection = new SQLiteConnection(connString);
        // OBJEKT ERZEUGUNG DER EIGENEN KLASSE
        private SqLiteQuerys sqlQueryToDb = new SqLiteQuerys();

        private string tableName = "Rechnung";

        public RechnungVerwalten()
        {
            InitializeComponent();
            DataTable dbToDt = sqlQueryToDb.LoadDbToDataTable(tableName, databaseConnection);
            // EIGENE METHODE 2 in der foreach
            foreach (string bills in sqlQueryToDb.dtToCb("Rechnungsempfaenger",dbToDt))
            {
                comboBox_Rechnungsempfaenger.Items.Add(bills);                
            }
            dgvUpdate();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            
        }

        public void dgvUpdate()
        {
            dgv.DataSource = sqlQueryToDb.LoadDbToDataTable(tableName, databaseConnection);
        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            if (comboBox_Rechnungsempfaenger.SelectedIndex == -1 || textBox_Waren.Text == "" || textBox_Summe.Text == "")
            {
                MessageBox.Show("Bitte gebe alle Felder an bevor du auf Speichern drückst", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {                    
                    sqlQueryToDb.saveToDb(comboBox_Rechnungsempfaenger.Text, textBox_Waren.Text, textBox_Summe.Text, databaseConnection);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Bitte nur Gleitkommazahlen angeben", "FEHLERMELDUNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            clearAllFields();
            dgvUpdate();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string ID = dgv.SelectedRows[0].Cells[0].Value.ToString();

            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bitte wähle erst einmal eine Zeile aus die du bearbeiten willst.");
                return;
            }
            else
            {
                // Alte Werte vor der Änderung speichern
                string oldRechnungsempfaenger = dgv.SelectedRows[0].Cells[1].Value.ToString();
                string oldWaren = dgv.SelectedRows[0].Cells[2].Value.ToString();
                string oldSumme = dgv.SelectedRows[0].Cells[3].Value.ToString();

                // Änderungen an den Textboxen durchführen
                string newRechnungsempfaenger = comboBox_Rechnungsempfaenger.Text;
                string newWaren = textBox_Waren.Text;
                string newSumme = textBox_Summe.Text;

                // Änderungen in der Datenbank durchführen
                sqlQueryToDb.changeInDb(tableName, ID, newRechnungsempfaenger, newWaren, newSumme, databaseConnection);

                // Neue Werte anzeigen
                string newValues = ID + ", " + newRechnungsempfaenger + ", " + newWaren + ", " + newSumme;
                string oldValues = ID + ", " + oldRechnungsempfaenger + ", " + oldWaren + ", " + oldSumme;
                MessageBox.Show("Alte Werte: " + oldValues + "\nNeue Werte: " + newValues);
                dgvUpdate();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string id = dgv.SelectedRows[0].Cells[0].Value.ToString();

            sqlQueryToDb.deleteFromDb(tableName, id, databaseConnection);
            dgvUpdate();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearAllFields();
        }

        private void clearAllFields()
        {
            textBox_Waren.Text = "";
            textBox_Summe.Text = "";            
            comboBox_Rechnungsempfaenger.SelectedIndex = -1; // Deselektiert mit -1

            sqlQueryToDb.LoadDbToDataTable(tableName, databaseConnection);
            dgvUpdate();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox_Rechnungsempfaenger.Text = dgv.SelectedRows[0].Cells[1].Value.ToString();
            textBox_Waren.Text = dgv.SelectedRows[0].Cells[2].Value.ToString();
            textBox_Summe.Text = dgv.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
