using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karol.Aplicacao;
using Karol.Dominio;

namespace Karol.UI.Web.Controllers
{
    public class AutorController : Controller
    {

        public ActionResult Index()
        {
            var aplicacao = new AutorAplicacao();
            var lista = aplicacao.ListarTodos();
            return View(lista);
        }

        public ActionResult Detalhes(int id)
        {
            var aplicacao = new AutorAplicacao();
            var autor = aplicacao.ListarPorId(id);
            if (autor == null)
                return HttpNotFound();
            return View(autor);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Autor autor)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new AutorAplicacao();
                aplicacao.Salvar(autor);
                return RedirectToAction("Index");
            }

            return View(autor);
        }

        public ActionResult Editar(int id)
        {
            var aplicacao = new AutorAplicacao();
            var autor = aplicacao.ListarPorId(id);
            if (autor == null)
                return HttpNotFound();

            return View(autor);
        }

        [HttpPost]
        public ActionResult Editar(Autor autor)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new AutorAplicacao();
                aplicacao.Salvar(autor);
                return RedirectToAction("Index");
            }

            return View(autor);
        }


        public ActionResult Excluir(int id)
        {
            var aplicacao = new AutorAplicacao();
            var autor = aplicacao.ListarPorId(id);
            if (autor == null)
                return HttpNotFound();

            return View(autor);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var aplicacao = new AutorAplicacao();
            aplicacao.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
