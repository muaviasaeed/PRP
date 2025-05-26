using System;
using MySql.Data.MySqlClient;

public class LanguageStatistics
{
    public void ShowLanguageStats()
    {
        string connStr = "server=localhost;user=root;database=world;port=3306;password=muavia310304hN@";
        MySqlConnection conn = new MySqlConnection(connStr);
        conn.Open();

        string[] languages = { "Chinese", "English", "Hindi", "Spanish", "Arabic" };

        foreach (var lang in languages)
        {
            string sql = $@"
                SELECT Language, 
                       SUM((Population * Percentage) / 100) AS Speakers 
                FROM countrylanguage 
                JOIN country ON country.Code = countrylanguage.CountryCode 
                WHERE Language = '{lang}' 
                GROUP BY Language";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                double speakers = Convert.ToDouble(reader["Speakers"]);
                Console.WriteLine($"{lang}: {speakers:N0} speakers");
            }

            reader.Close();
        }

        conn.Close();
    }
}
