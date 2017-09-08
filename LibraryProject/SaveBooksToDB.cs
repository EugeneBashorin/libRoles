using System.Data.SqlClient;
using LibraryProject.Models;
using System.Collections.Generic;
using System;
using System.Data.Common;
using System.Collections;

namespace LibraryProject
{
    public class SaveBooksToDB
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True";
        public bool SetBookToDb(Book book)
        {
            bool flagResult = false;
            string query = string.Format("INSERT INTO Books " + 
                "([Id], [Name], [Author], [Publisher],[Price]) " +
                "VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", book.Id, book.Name, book.Author, book.Publisher, book.Price);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand(query,con);
                try
                {
                    con.Open();
                    if (com.ExecuteNonQuery() == 1)
                    {
                        flagResult = true;
                    }
                }
                catch(Exception)
                { }
            }
            return flagResult;
        }

        public bool SetBooksListToDb(List<Book> bookList)
        {
            bool flagResult = false;
            string query = "INSERT INTO Books ([Id], [Name], [Author], [Publisher],[Price]) VALUES";
            for (int i = 0; i < bookList.Count; i++)
            {
                if (i == bookList.Count - 1)
                {
                    query += $"('{bookList[i].Id}', '{bookList[i].Name}', '{bookList[i].Author}', '{bookList[i].Publisher}', '{bookList[i].Price}');";
                }
               else
                {
                    query += $"('{bookList[i].Id}', '{bookList[i].Name}', '{bookList[i].Author}', '{bookList[i].Publisher}', '{bookList[i].Price}'),";
                }
            }          
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand(query, con);
                try
                { 
                    con.Open();
                    if (com.ExecuteNonQuery() >= 1)
                    {
                        flagResult = true;
                    }
                }
                catch(Exception)
                { }
            }
            return flagResult;
        }

        public ArrayList GetBooksFromDb()
        {
            ArrayList bookList = new ArrayList();

            string query = "SELECT * FROM Books";
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        foreach (DbDataRecord result in dr)
                            bookList.Add(result);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                { }
            }
            return bookList;
        }
    }
}