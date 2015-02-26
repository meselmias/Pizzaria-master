using System.Web.Mvc;
using Projeto_Pim.Models;
using Projeto_Pim.Models.BLogic;

namespace Projeto_Pim.Controllers
{
    public class ClienteController : Controller
    {
        //lista clientes
        [HttpGet]
        public ActionResult Lista()
        {
            return View(ClienteBL.ListaClientes());
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Mensagem = "Ops!Ocorreu um erro ao Cadastrar!";
                return View();
            }
            var retorno = ClienteBL.Cadastrar(cliente);
            return RedirectToAction("Lista");
        }

        [HttpGet]
        public ActionResult Detalhe(int id = 0)
        {
            var cliente = ClienteBL.ResgatarDadosClientePorId(id);

            return View(cliente);
        }

        [HttpGet]
        public ActionResult Excluir(int id = 0)
        {
            var retorno = ClienteBL.ExcluiClientePorId(id);
            return Json(new
            {
                sucess = retorno,
                redirectUrl = Url.Action("Lista", "Cliente"),

            });


        }

        [HttpPost]
        public ActionResult Excluir(Cliente cliente)
        {
            TempData["cliente"] = cliente;
            return RedirectToAction("Detalhe", cliente);
        }

        public ActionResult Alterar(int id = 0)
        {
            var cliente = ClienteBL.ResgatarDadosClientePorId(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Alterar(Cliente cliente)
        {
            var retorno = ClienteBL.AtualizarCliente(cliente);
            ViewBag.Mensagem = retorno ? "Alterado com sucesso !!!" : "OPS! ocorreu algum erro com a alteração";
            return View(cliente);
        }
    }
}
