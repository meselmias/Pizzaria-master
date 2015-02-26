using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Projeto_Pim.Models.DAL
{
    public class ClienteDB
    {
        public static int Cadastrar(Cliente cliente)
        {
            var nome = new SqlParameter("@NOME", SqlDbType.VarChar) { Value = cliente.Nome, Direction = ParameterDirection.Input };
            var cpf = new SqlParameter("@CPF", SqlDbType.VarChar) { Value = cliente.Cpf, Direction = ParameterDirection.Input };
            var dataNascimento = new SqlParameter("@DATANASCIMENTO", SqlDbType.DateTime) { Value = cliente.DataNascimento, Direction = ParameterDirection.Input };
            var endereco = new SqlParameter("@ENDERECO", SqlDbType.VarChar) { Value = cliente.Endereco, Direction = ParameterDirection.Input };
            var cep = new SqlParameter("@CEP", SqlDbType.VarChar) { Value = cliente.Cep, Direction = ParameterDirection.Input };
            var complemento = new SqlParameter("@COMPLEMENTO", SqlDbType.VarChar) { Value = cliente.Complemento, Direction = ParameterDirection.Input };
            var email = new SqlParameter("@EMAIL", SqlDbType.VarChar) { Value = cliente.Email, Direction = ParameterDirection.Input };
            var bairro = new SqlParameter("@BAIRRO", SqlDbType.VarChar) { Value = cliente.Bairro, Direction = ParameterDirection.Input };
            var pontoReferencia = new SqlParameter("@PONTOREFERENCIA", SqlDbType.VarChar) { Value = cliente.PontoReferencia, Direction = ParameterDirection.Input };
            var telefone = new SqlParameter("@TELEFONE", SqlDbType.VarChar) { Value = cliente.Telefone, Direction = ParameterDirection.Input };

            var codCliente = new SqlParameter("@CODCLIENTE", SqlDbType.Int) { Direction = ParameterDirection.Output };

            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString))
            {
                var myCommand = new SqlCommand("SP_CADASTRAR_CLIENTE", myConnection) { CommandType = CommandType.StoredProcedure };

                myCommand.Parameters.Add(nome);
                myCommand.Parameters.Add(cpf);
                myCommand.Parameters.Add(dataNascimento);
                myCommand.Parameters.Add(endereco);
                myCommand.Parameters.Add(cep);
                myCommand.Parameters.Add(complemento);
                myCommand.Parameters.Add(email);
                myCommand.Parameters.Add(bairro);
                myCommand.Parameters.Add(pontoReferencia);
                myCommand.Parameters.Add(telefone);
                myCommand.Parameters.Add(codCliente);

                try
                {
                    myConnection.Open();

                    myCommand.ExecuteNonQuery();

                    int clienteId = Int16.Parse(myCommand.Parameters["@CODCLIENTE"].Value.ToString());

                    return clienteId;

                }
                catch (Exception ex)
                {

                    return -1;
                }
                finally
                {
                    myConnection.Close();
                }

            }
        }


        public static List<Cliente> ListaDeClientes()
        {

            var lstCliente = new List<Cliente>();


            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString))
            {
                var myCommand = new SqlCommand("SP_CLIENTE_LISTA", myConnection) { CommandType = CommandType.StoredProcedure };

                try
                {
                    myConnection.Open();

                    using (var myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                lstCliente.Add(new Cliente
                                {
                                    Id = int.Parse(myReader["ID_CLIENTE"].ToString()),
                                    Nome = myReader["NOME"].ToString(),
                                    Cpf = myReader["CPF"].ToString(),
                                    DataNascimento = DateTime.Parse(myReader["DATANASCIMENTO"].ToString()),
                                    Endereco = myReader["ENDERECO"].ToString(),
                                    Cep = myReader["CEP"].ToString(),
                                    Complemento = myReader["COMPLEMENTO"].ToString(),
                                    Bairro = myReader["BAIRRO"].ToString(),
                                    PontoReferencia = myReader["PONTOREFERENCIA"].ToString(),
                                    Email = myReader["EMAIL"].ToString(),
                                    Telefone = myReader["TELEFONE"].ToString()
                                });

                            }
                        }
                    }

                    return lstCliente;

                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    myConnection.Close();
                }

            }
        }


        public static Cliente ResgatarPorId(int id)
        {

            var cliente = new Cliente();

            var Id = new SqlParameter("@ID", SqlDbType.Int) { Value = id, Direction = ParameterDirection.Input };

            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString))
            {
                var myCommand = new SqlCommand("SP_CLIENTE_RESGATAPORID", myConnection) { CommandType = CommandType.StoredProcedure };

                myCommand.Parameters.Add(Id);

                try
                {
                    myConnection.Open();

                    using (var myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                cliente.Id = int.Parse(myReader["ID"].ToString());
                                cliente.Nome = myReader["NOME"].ToString();
                                cliente.Cpf = myReader["CPF"].ToString();
                                cliente.DataNascimento = DateTime.Parse(myReader["DATANASCIMENTO"].ToString());
                                cliente.Endereco = myReader["ENDERECO"].ToString();
                                cliente.Cep = myReader["CEP"].ToString();
                                cliente.Complemento = myReader["COMPLEMENTO"].ToString();
                                cliente.Bairro = myReader["BAIRRO"].ToString();
                                cliente.PontoReferencia = myReader["PONTOREFERENCIA"].ToString();
                                cliente.Email = myReader["EMAIL"].ToString();
                                cliente.Telefone = myReader["TELEFONE"].ToString();

                            }
                        }
                    }

                    return cliente;

                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    myConnection.Close();
                }

            }
        }




        public static bool Atualiza(Cliente cliente)
        {
            var nome = new SqlParameter("@NOME", SqlDbType.VarChar) { Value = cliente.Nome, Direction = ParameterDirection.Input };
            var cpf = new SqlParameter("@CPF", SqlDbType.VarChar) { Value = cliente.Cpf, Direction = ParameterDirection.Input };
            var dataNascimento = new SqlParameter("@DATANASCIMENTO", SqlDbType.DateTime) { Value = cliente.DataNascimento, Direction = ParameterDirection.Input };
            var endereco = new SqlParameter("@ENDERECO", SqlDbType.VarChar) { Value = cliente.Endereco, Direction = ParameterDirection.Input };
            var cep = new SqlParameter("@CEP", SqlDbType.VarChar) { Value = cliente.Cep, Direction = ParameterDirection.Input };
            var complemento = new SqlParameter("@COMPLEMENTO", SqlDbType.VarChar) { Value = cliente.Complemento, Direction = ParameterDirection.Input };
            var email = new SqlParameter("@EMAIL", SqlDbType.VarChar) { Value = cliente.Email, Direction = ParameterDirection.Input };
            var bairro = new SqlParameter("@BAIRRO", SqlDbType.VarChar) { Value = cliente.Bairro, Direction = ParameterDirection.Input };
            var pontoReferencia = new SqlParameter("@PONTOREFERENCIA", SqlDbType.VarChar) { Value = cliente.PontoReferencia, Direction = ParameterDirection.Input };
            var telefone = new SqlParameter("@TELEFONE", SqlDbType.VarChar) { Value = cliente.Telefone, Direction = ParameterDirection.Input };
            var id = new SqlParameter("@ID", SqlDbType.Int) { Value = cliente.Id, Direction = ParameterDirection.Input };

            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString))
            {
                var myCommand = new SqlCommand("SP_CLIENTEATUALIZAPORID", myConnection) { CommandType = CommandType.StoredProcedure };

                myCommand.Parameters.Add(nome);
                myCommand.Parameters.Add(cpf);
                myCommand.Parameters.Add(dataNascimento);
                myCommand.Parameters.Add(endereco);
                myCommand.Parameters.Add(cep);
                myCommand.Parameters.Add(complemento);
                myCommand.Parameters.Add(email);
                myCommand.Parameters.Add(bairro);
                myCommand.Parameters.Add(pontoReferencia);
                myCommand.Parameters.Add(telefone);
                myCommand.Parameters.Add(id);

                try
                {
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    return true;

                }
                catch (Exception ex)
                {

                    return false;
                }
                finally
                {
                    myConnection.Close();
                }

            }
        }


        public static Cliente ExcluiPorId(int id)
        {

            var cliente = new Cliente();

            var Id = new SqlParameter("@ID", SqlDbType.Int) { Value = id, Direction = ParameterDirection.Input };

            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString))
            {
                var myCommand = new SqlCommand("SP_CLIENTE_EXCLUI_POR_ID", myConnection) { CommandType = CommandType.StoredProcedure };

                myCommand.Parameters.Add(Id);

                try
                {
                    myConnection.Open();

                    using (var myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                cliente.Id = int.Parse(myReader["ID_CLIENTE"].ToString());
                                cliente.Nome = myReader["NOME"].ToString();
                                cliente.Cpf = myReader["CPF"].ToString();
                                cliente.DataNascimento = DateTime.Parse(myReader["DATANASCIMENTO"].ToString());
                                cliente.Endereco = myReader["ENDERECO"].ToString();
                                cliente.Cep = myReader["CEP"].ToString();
                                cliente.Complemento = myReader["COMPLEMENTO"].ToString();
                                cliente.Bairro = myReader["BAIRRO"].ToString();
                                cliente.PontoReferencia = myReader["PONTOREFERENCIA"].ToString();
                                cliente.Email = myReader["EMAIL"].ToString();
                                cliente.Telefone = myReader["TELEFONE"].ToString();

                            }
                        }
                    }

                    return cliente;

                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    myConnection.Close();
                }

            }
        }

    }
}