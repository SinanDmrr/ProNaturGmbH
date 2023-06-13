using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ProNaturGmbH
{
    internal class SqLiteQuerys
    {
        public DataTable LoadDbToDataTable(SQLiteConnection connection)
        {
            string query = "SELECT * FROM Produkt";
            DataTable dt = new DataTable();
            // using (){} dient dazu das man sich .Open() und .CLose() spart denn alles zwischen den {} wird geöffnet und geschlossen
            using (SQLiteDataAdapter sqliteAdapter = new SQLiteDataAdapter(query, connection))
            {
                sqliteAdapter.Fill(dt);                
            }
            return dt;
        }

        public HashSet<string> dtToCb(DataTable dt)
        {
            HashSet<string> uniqueCategoriesHashSet = new HashSet<string>();
            foreach (DataRow dr in dt.Rows)
            {
                string category = dr["Kategorie"].ToString();   // Spalte Kategorie Inhalte
                if (!uniqueCategoriesHashSet.Contains(category))
                {                    
                    uniqueCategoriesHashSet.Add(category);
                }
            }
            return uniqueCategoriesHashSet;
        }

        public void saveToDb(string name, string marke, string kategorie, string preis, SQLiteConnection connection)
        {
            if (preis.Contains(","))
            {
                preis = preis.Replace(",", ".");
            }
            string query = "INSERT INTO Produkt (name, marke, kategorie, preis) VALUES (@name, @marke, @kategorie, @preis)";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@marke", marke);
                command.Parameters.AddWithValue("@kategorie", kategorie);
                command.Parameters.AddWithValue("@preis", preis);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void changeInDb(string ID, string newName, string newMarke, string newKategorie, string newPreis, SQLiteConnection connection)
        {
            string query = "UPDATE Produkt SET Name = @Name, Marke = @Marke, Kategorie = @Kategorie, Preis = @Preis WHERE ID = @ID";

            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@Name", newName);
            cmd.Parameters.AddWithValue("@Marke", newMarke);
            cmd.Parameters.AddWithValue("@Kategorie", newKategorie);
            cmd.Parameters.AddWithValue("@Preis", newPreis);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }

        public void deleteFromDb(string ID, SQLiteConnection connection)
        {
            DialogResult result = MessageBox.Show("Bist du dir sicher das du diese Zeile mit der ID " +
                    ID + " unwiederruflich löschen willst?", "ACHTUNG", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(result == DialogResult.Yes)
            {
                string query = "DELETE FROM Produkt WHERE ID = @ID";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
            {
                MessageBox.Show("Lösch vorgang wurde beendet", "INFORMATION");
                return;
            }
        }
    }
}
