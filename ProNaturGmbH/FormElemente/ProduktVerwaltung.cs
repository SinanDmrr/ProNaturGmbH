using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ProNaturGmbH
{
    public partial class ProduktVerwaltung : Form
    {
        //@"C:\Users\demir\Desktop\CSharp_Intensivkurs_Udemy\Abschnitt7-ProNaturGmbH\ProNaturGmbH\ProNaturGmbH\bin\Debug\NaturBioMarkt.db";
        private static string connString = "Data Source=./NaturBioMarkt.db;Version=3;";        
        // Verbindung zur Datenbank erstellen
        private SQLiteConnection databaseConnection = new SQLiteConnection(connString);
        // OBJEKT ERZEUGUNG DER EIGENEN KLASSE
        private SqLiteQuerys sqlQueryToDb = new SqLiteQuerys();

        private string tableName = "Produkt";


        public ProduktVerwaltung()
        {
            InitializeComponent();                        
                        
            // EIGENE METHODE 1
            DataTable dbToDt = sqlQueryToDb.LoadDbToDataTable(tableName, databaseConnection);
            // EIGENE METHODE 2 in der foreach
            foreach (string category in sqlQueryToDb.dtToCb("Kategorie",dbToDt))
            {
                comboBox_Kategorie.Items.Add(category);
            }
            // Eigens erstellte Methode um die DataGridView mit der DataBase zu befüllen
            dgv.DataSource = dbToDt;
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            if(textBox_Name.Text == "" || textBox_Marke.Text == "" || textBox_Preis.Text == "" || comboBox_Kategorie.SelectedIndex == -1)
            {
                MessageBox.Show("Bitte gebe alle Felder an bevor du auf Speichern drückst", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    sqlQueryToDb.saveToDb(textBox_Name.Text, textBox_Marke.Text, comboBox_Kategorie.SelectedItem.ToString(), textBox_Preis.Text, databaseConnection);     
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


        private void btn_edit_Click(object sender, EventArgs e)
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
                string oldName = dgv.SelectedRows[0].Cells[1].Value.ToString();
                string oldMarke = dgv.SelectedRows[0].Cells[2].Value.ToString();
                string oldKategorie = dgv.SelectedRows[0].Cells[3].Value.ToString();
                string oldPreis = dgv.SelectedRows[0].Cells[4].Value.ToString();

                // Änderungen an den Textboxen durchführen
                string newName = textBox_Name.Text;
                string newMarke = textBox_Marke.Text;
                string newKategorie = comboBox_Kategorie.Text;
                string newPreis = textBox_Preis.Text;

                // Änderungen in der Datenbank durchführen
                sqlQueryToDb.changeInDb(ID, newName, newMarke, newKategorie, newPreis, databaseConnection);

                // Neue Werte anzeigen
                string newValues = ID + ", " + newName + ", " + newMarke + ", " + newKategorie + ", " + newPreis;
                string oldValues = ID + ", " + oldName + ", " + oldMarke + ", " + oldKategorie + ", " + oldPreis;
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


        // ↓ METHODEN AB HIER ↓
        private void clearAllFields()
        {            
            textBox_Name.Text = "";
            textBox_Marke.Text = "";
            textBox_Preis.Text = "";
            comboBox_Kategorie.SelectedIndex = -1; // Deselektiert mit -1

            sqlQueryToDb.LoadDbToDataTable(tableName, databaseConnection);
        }


        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Name.Text = dgv.SelectedRows[0].Cells[1].Value.ToString();
            textBox_Marke.Text = dgv.SelectedRows[0].Cells[2].Value.ToString();
            comboBox_Kategorie.Text = dgv.SelectedRows[0].Cells[3].Value.ToString();
            textBox_Preis.Text = dgv.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void ProduktVerwaltung_Load(object sender, EventArgs e)
        {
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ClearSelection();
        }

        public void dgvUpdate()
        {
            dgv.DataSource = sqlQueryToDb.LoadDbToDataTable(tableName, databaseConnection);
        }
    }
}
