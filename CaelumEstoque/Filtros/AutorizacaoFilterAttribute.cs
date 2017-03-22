using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaelumEstoque.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        //escrever um método antes da Action
        //OnActionExecuted: executa antes da action do Controller
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //filterContext: acessa a session do mvc
            //HttpContext: guarda os dados da requisição atual
            object usuario = filterContext.HttpContext.Session["usuarioLogado"];

            if (usuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Login", action = "Index" }
                        )
                   );
            }
        }
    }
}