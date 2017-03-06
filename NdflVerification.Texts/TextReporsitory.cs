using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace NdflVerification.Texts
{
    public class TextReporsitory : ITextRepository
    {
        public IEnumerable<TextInfo> GetTexts()
        {
            var result = new List<TextInfo>();

            using (var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["TextsConnection"].ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Name, Value FROM [dbo].[Texts]", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var text = new TextInfo(reader["Name"].ToString(), reader["Value"].ToString());
                    result.Add(text);
                }
            }

            return result;
        }
    }
}