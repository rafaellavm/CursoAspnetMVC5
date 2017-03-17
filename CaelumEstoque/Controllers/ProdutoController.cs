using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;

namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();
            ViewBag.Produtos = produtos;

            return View();
        }

        public ActionResult Form()
        {
            CategoriasDAO categoriasDao = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = categoriasDao.Lista();
            ViewBag.Categorias = categorias;
            ViewBag.Produto = new Produto();

            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            int idDaInformatica = 1;
            if(produto.CategoriaId.Equals(idDaInformatica) && produto.Preco < 100){

                //"produto.Invalido": chave que é chamada na view
                ModelState.AddModelError("produto.Invalido", "Iformática com preço abaixo de 100 reais");
            }
            
            if (ModelState.IsValid)
            {
                ProdutosDAO dao = new ProdutosDAO();
                dao.Adiciona(produto);
                //mandar o usuário para o index de Produto(controller)
                return RedirectToAction("Index", "Produto");
            }
            else
            {
                //pra deixar os campos preenchidos
                ViewBag.Produto = produto;
                CategoriasDAO categoriasdao = new CategoriasDAO();
                ViewBag.Categorias = categoriasdao.Lista();

                return View("Form");
            }

        }
    }
}