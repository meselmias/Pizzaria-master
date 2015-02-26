using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Projeto_Pim.Models.DAL
{
    public class PedidoDB
    {
        #region cadastro pedido

        public static int Cadastrar(Pedido pedido)
        {
            var cliente = new SqlParameter("@IDCLIENTE", SqlDbType.Int) { Value = pedido.ClienteId, Direction = ParameterDirection.Input };
            var produto = new SqlParameter("@PRODUTO", SqlDbType.VarChar) { Value = pedido.Produto, Direction = ParameterDirection.Input };
            var observacao = new SqlParameter("@OBSERVACAO", SqlDbType.VarChar) { Value = pedido.Observacao, Direction = ParameterDirection.Input };
            var pedidoId = new SqlParameter("@IDPEDIDO", SqlDbType.Int) { Direction = ParameterDirection.Output };


            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString))
            {
                var myCommand = new SqlCommand("SP_PEDIDO_CADASTRAR", myConnection) { CommandType = CommandType.StoredProcedure };

                myCommand.Parameters.Add(cliente);
                myCommand.Parameters.Add(produto);
                myCommand.Parameters.Add(observacao);
                myCommand.Parameters.Add(pedidoId);


                try
                {
                    myConnection.Open();

                    myCommand.ExecuteNonQuery();

                    int retornoPedido = Int16.Parse(myCommand.Parameters["@IDPEDIDO"].Value.ToString());

                    return retornoPedido;

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

        #endregion

        #region Lista


        public static List<Pedido> ListaDePedidos()
        {

            var lstPedidos = new List<Pedido>();


            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString))
            {
                var myCommand = new SqlCommand("PEDIDO_LISTA_CLIENTE", myConnection) { CommandType = CommandType.StoredProcedure };

                try
                {
                    myConnection.Open();

                    using (var myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                lstPedidos.Add(new Pedido
                                {
                                    Id = int.Parse(myReader["ID_PEDIDO"].ToString()),
                                    ClienteId = myReader["NOME"].ToString(),
                                    Produto = myReader["PRODUTO"].ToString(),
                                    DataRegistro = DateTime.Parse(myReader["DATA"].ToString()),
                                    Observacao = myReader["OBSERVACAO"].ToString(),
                                    Endereco = myReader["ENDERECO"].ToString()

                                });

                            }
                        }
                    }

                    return lstPedidos;

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


        #endregion

        #region resgata pedido pelo id


        public static Pedido ResgatarPorId(int id)
        {

            var pedido = new Pedido();

            var idPedido = new SqlParameter("@ID", SqlDbType.Int) { Value = id, Direction = ParameterDirection.Input };

            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString))
            {
                var myCommand = new SqlCommand("CLIENTE_RESGATA_ENDERECO", myConnection) { CommandType = CommandType.StoredProcedure };

                myCommand.Parameters.Add(idPedido);

                try
                {
                    myConnection.Open();

                    using (var myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                pedido.Id = int.Parse(myReader["ID_PEDIDO"].ToString());
                                pedido.ClienteId = myReader["NOME"].ToString();
                                pedido.Produto = myReader["PRODUTO"].ToString();
                                pedido.Observacao = myReader["OBSERVACAO"].ToString();
                                pedido.DataRegistro = DateTime.Parse(myReader["DATA"].ToString());
                                pedido.Endereco = myReader["ENDERECO"].ToString();
                            }
                        }
                    }

                    return pedido;

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


        #endregion

        #region Atualiza

        public static bool PedidoAtualizar(Pedido pedido)
        {
            var id = new SqlParameter("@IDPEDIDO", SqlDbType.Int) { Value = pedido.Id, Direction = ParameterDirection.Input };
            var produto = new SqlParameter("@PRODUTO", SqlDbType.VarChar) { Value = pedido.Produto, Direction = ParameterDirection.Input };
            var observacao = new SqlParameter("@OBSERVACAO", SqlDbType.VarChar) { Value = pedido.Observacao, Direction = ParameterDirection.Input };
            var cliente = new SqlParameter("@IDCLIENTE", SqlDbType.VarChar) { Value = pedido.ClienteId, Direction = ParameterDirection.Input };
          

            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString))
            {

                var myCommand = new SqlCommand("SP_PEDIDO_ATUALIZA_POR_ID", myConnection) { CommandType = CommandType.StoredProcedure };

                myCommand.Parameters.Add(id);
                myCommand.Parameters.Add(produto);
                myCommand.Parameters.Add(observacao);
                myCommand.Parameters.Add(cliente);
            

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
        


        #endregion

        #region excluir

        public static Pedido ExcluirPorId(int id)
        {

            var pedido = new Pedido();

            var idPedido = new SqlParameter("@ID", SqlDbType.Int) { Value = id, Direction = ParameterDirection.Input };

            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString))
            {
                var myCommand = new SqlCommand("SP_PEDIDO_EXCLUI_POR_ID", myConnection) { CommandType = CommandType.StoredProcedure };

                myCommand.Parameters.Add(idPedido);

                try
                {
                    myConnection.Open();

                    using (var myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                pedido.Id = int.Parse(myReader["ID_PEDIDO"].ToString());
                                pedido.ClienteId = myReader["ID"].ToString();
                                pedido.Produto = myReader["PRODUTO"].ToString();
                                pedido.Observacao = myReader["OBSERVACAO"].ToString();
                                pedido.DataRegistro = DateTime.Parse(myReader["DATA"].ToString());
                                //pedido.Clientes.Endereco = myReader["ENDERECO"].ToString();
                            }
                        }
                    }

                    return pedido;

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


        #endregion

    }
}