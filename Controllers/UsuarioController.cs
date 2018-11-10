using Dapper;
using SistemaEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace estoqueApi.Controllers
{
    public class UsuarioController : Controller
    {

        // GET: Produto
        [HttpGet]
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<Usuario>("VerTodosUsuarios"));
        }

        [HttpPost]
        public ActionResult AdicionarOuEditarUsuario(Usuario usuario)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id",usuario.Id);
            param.Add("@Nome", usuario.Nome);
            param.Add("@Cpf", usuario.Cpf);
            param.Add("@Login", usuario.Login);
            param.Add("@Senha", usuario.Senha);
            DapperORM.ExecuteWithoutReturn("AdicionarOuEditarUsuario", param);
            return RedirectToAction("Index");
        }

        public ActionResult DeletarUsuario(int Id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", Id);
            DapperORM.ExecuteWithoutReturn("DeletarUsuario", param);
            return RedirectToAction("Index");

        }


    }
}