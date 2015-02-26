using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto_Pim.Models.DAL;

namespace Projeto_Pim.Models.BLogic
{
    public class ClienteBL
    {
        public static int Cadastrar(Cliente cliente)
        {
            return ClienteDB.Cadastrar(cliente);
        }

        public static List<Cliente> ListaClientes()
        {
            return ClienteDB.ListaDeClientes();
        }

        public static Cliente ResgatarDadosClientePorId(int id)
        {
            return ClienteDB.ResgatarPorId(id);
        }

        public static bool AtualizarCliente(Cliente cliente)
        {
            return ClienteDB.Atualiza(cliente);
        }

        public static Cliente ExcluiClientePorId(int id)
        {
            return ClienteDB.ExcluiPorId(id);
        }
    }
}