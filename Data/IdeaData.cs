using ConsoleIdeaApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleIdeaApp.Data
{
    public class IdeaData
    {
        private string connectionString;

        public IdeaData()
        {
        }

        public IdeaData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddIdea(Idea idea)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Ideas (Title, Description, CreatedAt) " +
                               "VALUES (@Title, @Description, @CreatedAt)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", idea.Title);
                command.Parameters.AddWithValue("@Description", idea.Description);
                command.Parameters.AddWithValue("@CreatedAt", idea.CreatedAt);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Idea> GetLatestIdeas(int count)
        {
            List<Idea> ideas = new List<Idea>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP " + count + " * FROM Ideas ORDER BY CreatedAt DESC";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Idea idea = new Idea
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        CreatedAt = (DateTime)reader["CreatedAt"]
                    };

                    ideas.Add(idea);
                }
            }

            return ideas;
        }

        public List<Idea> SearchIdeas(string searchTerm)
        {
            List<Idea> ideas = new List<Idea>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Ideas WHERE Title LIKE '%' + @SearchTerm + '%'";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SearchTerm", searchTerm);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Idea idea = new Idea
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        CreatedAt = (DateTime)reader["CreatedAt"]
                    };

                    ideas.Add(idea);
                }
            }

            return ideas;
        }

        internal object GetIdeas()
        {
            throw new NotImplementedException();
        }
    }
}
