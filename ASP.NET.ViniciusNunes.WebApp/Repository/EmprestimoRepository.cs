using ASP.NET.ViniciusNunes.WebApp.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.ViniciusNunes.WebApp.Repository
{
    public class EmprestimoRepository
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\VSO\viniciusnunes\AssessmentAspNet-master\ASP.NET.ViniciusNunes.WebApp\App_Data\Biblioteca.mdf;Integrated Security=True";
        LivroRepository repoLivros = new LivroRepository();

        public IEnumerable<LivroEmprestimo> BuscarTodosOsEmprestimos()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Emprestimos";
                var selectCommand = new SqlCommand(commandText, connection);

                LivroEmprestimo emprestimo = null;
                var emprestimos = new List<LivroEmprestimo>();

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            emprestimo = new LivroEmprestimo();
                            emprestimo.Id = (int)reader["Id"];
                            emprestimo.dataEmprestimo = DateTime.Parse(reader["dataEmprestimo"].ToString());
                            emprestimo.dataDevolucao = DateTime.Parse(reader["dataDevolucao"].ToString());
                            emprestimo.livroId = (int)reader["livroId"];

                            emprestimos.Add(emprestimo);
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }

                return emprestimos;
            }
        }

        public LivroEmprestimo EmprestimoDetalhes(int idEmprestimo)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Emprestimos WHERE Id = " + idEmprestimo;
                var selectCommand = new SqlCommand(commandText, connection);

                LivroEmprestimo emprestimo = null;

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            emprestimo = new LivroEmprestimo();
                            emprestimo.Id = (int)reader["Id"];
                            emprestimo.dataEmprestimo = DateTime.Parse(reader["dataEmprestimo"].ToString());
                            emprestimo.dataDevolucao = DateTime.Parse(reader["dataDevolucao"].ToString());
                            emprestimo.livroId = (int)reader["livroId"];
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }

                return emprestimo;
            }
        }

        public void AtualizarEmprestimo(LivroEmprestimo emprestimo, FormCollection collection)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string commandText = "UPDATE Emprestimos SET dataEmprestimo=@dataEmprestimo, dataDevolucao=@dataDevolucao, livroId=@livroId Where iD=@Id";
                SqlCommand insertCommand = new SqlCommand(commandText, connection);
                insertCommand.Parameters.AddWithValue("@Id", emprestimo.Id);
                insertCommand.Parameters.AddWithValue("@dataEmprestimo", DateTime.Parse(collection.Get("dataEmprestimo")));
                insertCommand.Parameters.AddWithValue("@dataDevolucao", DateTime.Parse(collection.Get("dataDevolucao")));
                string livroIdStr = collection.Get("livroId");
                insertCommand.Parameters.AddWithValue("@livroId", int.Parse(livroIdStr));

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

        public void AdicionarEmprestimo(FormCollection collection)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string commandText = "INSERT INTO Emprestimos (dataEmprestimo, dataDevolucao, livroId) VALUES (@dataEmprestimo, @dataDevolucao, @livroId)";
                SqlCommand insertCommand = new SqlCommand(commandText, connection);
                insertCommand.Parameters.AddWithValue("@dataEmprestimo", DateTime.Parse(collection.Get("dataEmprestimo")));
                insertCommand.Parameters.AddWithValue("@dataDevolucao", DateTime.Parse(collection.Get("dataDevolucao")));
                string livroIdStr = collection.Get("livroId");
                insertCommand.Parameters.AddWithValue("@livroId", int.Parse(livroIdStr));
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

        public void DeletarEmprestimo(int idEmprestimo)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string commandText = "DELETE Emprestimos Where iD=@Id";
                SqlCommand insertCommand = new SqlCommand(commandText, connection);
                insertCommand.Parameters.AddWithValue("@Id", idEmprestimo);
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