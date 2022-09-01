using System.Web.Mvc;
namespace LH.GestaoDePessoas.CrossCutting.MvcFilters
{
	public class GlobalErrorHandler : ActionFilterAttribute
	{
		public GlobalErrorHandler()
		{
				
		}

		public override void OnResultExecuted(ResultExecutedContext filterContext)
		{
			if(filterContext.Exception != null)
			{
				//O que pode ser feito como tratativa.
				// -> Manipular a Exeção.
				// -> Injetar libs de tratamento de erro.
				// -> Gravar Log do Erro.
				// - Retornar cod do erro amigavel.
				filterContext.Controller.TempData["ErrorCode"] = "000555";

			}
			base.OnResultExecuted(filterContext);
		}
	}
}