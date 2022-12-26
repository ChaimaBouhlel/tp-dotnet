using System.Data.SQLite;
using System.Diagnostics;

namespace tp3.Models
{
    public class Personal_info
    {
        public static List<Person> GetAllPerson()
        {
            List<Person> list = new List<Person>();
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=C:\\Users\\21697\\Documents\\GL3 chaima\\tp3database.db");
            dbCon.Open();
            using (dbCon)
            {
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM personal_info", dbCon);
                SQLiteDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string firstName = (string)reader["first_name"];
                        string lastName = (string)reader["last_name"];
                        string email = (string)reader["email"];
                        //string dateBirth = (string)reader["date_birth"].ToString();
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];
                        list.Add(new Person(id, firstName, lastName, email, image, country));
                    }
                }
            }
            return list;
        }
        public static Person GetPerson(int id)
        {
            List<Person> list = GetAllPerson();
            return list.Find(x => x.id == id);
        }
    }
}
