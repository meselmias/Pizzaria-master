using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto_Pim.Models.DAL;

namespace Projeto_Pim.Models.BLogic
{
    public class PedidoBL
    {
        public static List<Pedido> ListaPedidos()
        {
            return PedidoDB.ListaDePedidos();
        }

        public static int Cadastrar(Pedido pedido)
        {
            return PedidoDB.Cadastrar(pedido);
        }

        public static Pedido ResgatarPedidoPorId(int id)
        {
            return PedidoDB.ResgatarPorId(id);
        }

        public static bool Atualizar(Pedido pedido)
        {
            return PedidoDB.PedidoAtualizar(pedido);
        }

        public static Pedido ExcluiPedidoPorId(int id)
        {
            return PedidoDB.ExcluirPorId(id);
        }
    }
}