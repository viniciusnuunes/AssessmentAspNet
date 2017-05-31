using ASP.NET.ViniciusNunes.WebApp.Domain;
using ASP.NET.ViniciusNunes.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.ViniciusNunes.WebApp.Repository
{
    public interface IEmprestimoRepository
    {
        List<Emprestimo> GetAllEmprestimos();
        Emprestimo GetEmprestimosDetails(int idEmprestimo);
        void AdicionarEmprestimo(EmprestimoViewModel emprestimo);
        void AtualizarEmprestimo(Emprestimo emprestimo);        
        void DeletarEmprestimo(int idEmprestimo);
    }
    public class EmprestimoRepository : IEmprestimoRepository
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\VSO\viniciusnunes\AssessmentAspNet_ViniciusNunes\ASP.NET.ViniciusNunes.WebApp\App_Data\Biblioteca.mdf;Integrated Security=True";        

        public List<Emprestimo> GetAllEmprestimos()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Emprestimos";
                var selectCommand = new SqlCommand(commandText, connection);

                Emprestimo emprestimo = null;
                var emprestimos = new List<Emprestimo>();

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            emprestimo = new Emprestimo();
                            emprestimo.Id = (int)reader["Id"];
                            emprestimo.dataEmprestimo = (reader["dataEmprestimo"].ToString());
                            emprestimo.dataDevolucao = (reader["dataDevolucao"].ToString());
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

        public Emprestimo GetEmprestimosDetails(int idEmprestimo)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Emprestimos WHERE Id = " + idEmprestimo;
                var selectCommand = new SqlCommand(commandText, connection);

                Emprestimo emprestimo = null;

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            emprestimo = new Emprestimo();
                            emprestimo.Id = (int)reader["Id"];
                            emprestimo.dataEmprestimo = reader["dataEmprestimo"].ToString();
                            emprestimo.dataDevolucao = reader["dataDevolucao"].ToString();
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

        public void AtualizarEmprestimo(Emprestimo emprestimo)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string commandText = "UPDATE Emprestimos SET dataEmprestimo=@dataEmprestimo, dataDevolucao=@dataDevolucao, livroId=@livroId Where iD=@Id";
                SqlCommand insertCommand = new SqlCommand(commandText, connection);
                insertCommand.Parameters.AddWithValue("@Id", emprestimo.Id);
                insertCommand.Parameters.AddWithValue("@dataEmprestimo", emprestimo.dataEmprestimo);
                insertCommand.Parameters.AddWithValue("@dataDevolucao", emprestimo.dataDevolucao);
                insertCommand.Parameters.AddWithValue("@livroId", emprestimo.livroId);

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

        public void AdicionarEmprestimo(EmprestimoViewModel emprestimo)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string commandText = "INSERT INTO Emprestimos (dataEmprestimo, dataDevolucao, livroId) VALUES (@dataEmprestimo, @dataDevolucao, @livroId)";
                SqlCommand insertCommand = new SqlCommand(commandText, connection);
                insertCommand.Parameters.AddWithValue("@dataEmprestimo", emprestimo.dataEmprestimo);
                insertCommand.Parameters.AddWithValue("@dataDevolucao", emprestimo.dataDevolucao);
                insertCommand.Parameters.AddWithValue("@livroId", emprestimo.livroId);
                
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