using CaelumEstoque.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.App_Start
{
    //obs: Global.asax tem todas configurações globais da aplicacao
    //nele chamaremos essa classe FilterConfig 
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //adicionando um filtro global
            //filters.Add(new AutorizacaoFilterAttribute());
        }
        
    }
}