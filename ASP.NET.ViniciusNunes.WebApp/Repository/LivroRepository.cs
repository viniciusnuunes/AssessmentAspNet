using ASP.NET.ViniciusNunes.WebApp.Domain;
using ASP.NET.ViniciusNunes.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP.NET.ViniciusNunes.WebApp.Repository
{
    public interface ILivroRepository
    {
        List<Livro> BuscarTodosOsLivros();        
    }

    public class LivroRepository : ILivroRepository
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\VSO\viniciusnunes\AssessmentAspNet-master\ASP.NET.ViniciusNunes.WebApp\App_Data\Biblioteca.mdf;Integrated Security=True";

        public List<Livro> BuscarTodosOsLivros()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string commandText = "SELECT * FROM Livro";
                var selectCommand = new SqlCommand(commandText, connection);

                Livro livro;
                var livros = new List<Livro>();

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            livro = new Livro();
                            livro.Id = (int)reader["Id"];
                            livro.Nome = reader["Nome"].ToString();
                            livro.Autor = reader["Autor"].ToString();
                            livro.Editora = reader["Editora"].ToString();
                            livro.Ano = reader["Ano"].ToString();

                            livros.Add(livro);
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
                return livros;
            }
        }

        public Livro getLivroDetails(int idLivro)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Livro WHERE Id = " + idLivro;
                var selectCommand = new SqlCommand(commandText, connection);

                Livro livro = null;

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            livro = new Livro();
                            livro.Id = (int)reader["Id"];
                            livro.Autor = reader["Autor"].ToString();
                            livro.Editora = reader["Editora"].ToString();
                            livro.Ano = reader["Ano"].ToString();

                        }
                    }
                }
                finally
                {
                    connection.Close();
                }

                return livro;
            }
        }

        internal void AdicionarLivro(Livro livro)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "INSERT INTO Livro (Nome, Autor, Editora, Ano) VALUES (@Nome, @Autor, @Editora, @Ano)";
                var insertCommand = new SqlCommand(commandText, connection);
                insertCommand.Parameters.AddWithValue("@Nome", livro.Nome);
                insertCommand.Parameters.AddWithValue("@Autor", livro.Autor);
                insertCommand.Parameters.AddWithValue("@Editora", livro.Editora);
                insertCommand.Parameters.AddWithValue("@Ano", livro.Ano);

                try
                {
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        internal void AtualizarLivro(int Id, Livro livro)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                string commandText = "UPDATE Livro SET Nome=@Nome, Autor=@Autor, Editora=@Editora, Ano=@Ano Where Id=@Id";
                SqlCommand insertCommand = new SqlCommand(commandText, connection);
                insertCommand.Parameters.AddWithValue("@Id", livro.Id);
                insertCommand.Parameters.AddWithValue("@Nome", livro.Nome);
                insertCommand.Parameters.AddWithValue("@Autor", livro.Autor);
                insertCommand.Parameters.AddWithValue("@Editora", livro.Editora);
                insertCommand.Parameters.AddWithValue("@Ano", livro.Ano);
                try
                {
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void DeletarLivro(int id = 0)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string commandText = "DELETE Livro Where Id=@Id";
                SqlCommand insertCommand = new SqlCommand(commandText, connection);
                insertCommand.Parameters.AddWithValue("@Id", id);
                try
                {
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}