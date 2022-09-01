using System.Net;
using System.Web.Mvc;
using LH.GestaoDePessoas.Application;
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
        private readonly ClienteAppService _clienteAppService;

        public ClientesController()
        {
            _clienteAppService = new ClienteAppService();
        }

        // GET: Clientes
        [ClaimsAuthorize("PermissoesCliente", "CL")]
        [Route("listar-clientes")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterTodosClientes());
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

            var clienteViewModel = _clienteAppService.ObterClientePorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        [ClaimsAuthorize("PermissoesCliente", "CI")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsAuthorize("PermissoesCliente", "CI")]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.AdicionarClienteEndereco(clienteEnderecoViewModel);
                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        // GET: Clientes/Edit/5
        [ClaimsAuthorize("PermissoesCliente", "CE")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterClientePorId(id.Value);

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
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.AtualizarCliente(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        // GET: Clientes/Delete/5
        [ClaimsAuthorize("PermissoesCliente", "CX")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterClientePorId(id.Value);

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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [ClaimsAuthorize("PermissoesCliente", "CX")]
        public ActionResult DeleteConfirmed(int id)
        {
            _clienteAppService.RemoverCliente(id);
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
