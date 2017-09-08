using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace LibraryProject.Extention_Classes
{
    public static class NewspaperExtention
    {
        private static string writePath = AppDomain.CurrentDomain.BaseDirectory + @"App_Data/newspapers.txt";
        private static string writeXmlPath = AppDomain.CurrentDomain.BaseDirectory + @"App_Data/newspapers.xml";

        public static void GetTxtList(this List<Newspaper> list)
        {
            StringBuilder result = new StringBuilder(130);

            if (list.Count > 0)
            {
                foreach (Newspaper item in list)
                {
                    result.AppendLine($"Name: {item.Name} Author: {item.Category} Publisher: {item.Publisher} Price: {item.Price.ToString()}");
                }
            }

            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(result);
            }
        }

        public static void GetXmlList(this List<Newspaper> xmlNewspapersList)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Newspaper>));

            using (FileStream fs = new FileStream(writeXmlPath, FileMode.Create))
            {
                xs.Serialize(fs, xmlNewspapersList);
            }
        }

        public static void SetNewspaperListToDb(this List<Newspaper> magazineList, string connectionString)
        {
            StringBuilder insertSqlExpression = new StringBuilder(300);
            insertSqlExpression.Append("INSERT INTO Newspapers ([Id], [Name], [Category], [Publisher],[Price]) VALUES");

            foreach (Newspaper item in magazineList)
            {
                if (item == magazineList.Last())
                {
                    insertSqlExpression.Append($"('{item.Id}','{item.Name}','{item.Category}','{item.Publisher}','{item.Price}');");
                }
                else
                {
                    insertSqlExpression.Append($"('{item.Id}','{item.Name}','{item.Category}','{item.Publisher}','{item.Price}'),");
                }
            }

            string InsertSqlExpression = insertSqlExpression.ToString();
            string DeleteSqlExpression = "DELETE FROM Newspapers";

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(DeleteSqlExpression, con);
                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }

                command = new SqlCommand(InsertSqlExpression, con);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}