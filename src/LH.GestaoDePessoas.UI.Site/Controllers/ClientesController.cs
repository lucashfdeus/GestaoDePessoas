using System.Net;
using System.Web.Mvc;
using LH.GestaoDePessoas.Application;
using LH.GestaoDePessoas.Application.Interfaces;
using LH.GestaoDePessoas.Application.ViewModels;
using LH.GestaoDePessoas.CrossCutting.MvcFilters;

namespace LH.GestaoDePessoas.UI.Site.Controllers
{
    //PermissõesCliente 
    //CL - Listar Todos
    //CI - Incluir
    //CE - Editar
    //CD - Detalhar
    //CX - Excluir

    [Authorize]
    [Route]
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService ;
        }

        // GET: Clientes
        [ClaimsAuthorize("PermissoesCliente", "CL")]
        [Route("listar-clientes")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterTodos());
        }

        // GET: Clientes/Details/5
        [ClaimsAuthorize("PermissoesCliente", "CD")]
        [Route("detalhes-cliente/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        [ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("novo-cliente")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("novo-cliente")]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                clienteEnderecoViewModel = _clienteAppService.Adicionar(clienteEnderecoViewModel);
                if (!clienteEnderecoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in clienteEnderecoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    return View(clienteEnderecoViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        // GET: Clientes/Edit/5
        [ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("{id}/editar-cliente")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("{id}/editar-cliente")]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        // GET: Clientes/Delete/5
        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("{id}/excluir-cliente")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }

            if(!clienteViewModel.Ativo)
            {
                ModelState.AddModelError(string.Empty,"Cliente inativo.");
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("{id}/excluir-cliente")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _clienteAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
