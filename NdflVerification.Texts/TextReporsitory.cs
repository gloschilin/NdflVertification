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
                var command = new SqlCommand("SELECT Response, Validator, OtherResponse FROM [dbo].[TempValidator]", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var text = new TextInfo(reader["Validator"].ToString(), reader["Response"].ToString(), reader["OtherResponse"].ToString());
                    result.Add(text);
                }
            }

            return result;
        }
    }
}