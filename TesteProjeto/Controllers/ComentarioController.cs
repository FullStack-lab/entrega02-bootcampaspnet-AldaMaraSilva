using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteProjeto.Models;

namespace TesteProjeto.Controllers
{
    public class ComentarioController : Controller
    {
        // Lista de comentários (simulação de banco de dados)
        private static List<Comentario> comentarios = new List<Comentario>();

        // Exibir lista de comentários
        public ActionResult Index()
        {
            return View(comentarios);
        }

        // Criar novo comentário
        [HttpGet]
        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                comentario.DataCriacao = DateTime.Now;
                comentario.Id = comentarios.Count + 1; // Atribui um ID simples
                comentarios.Add(comentario);
                return RedirectToAction("Index");
            }
            return View(comentario);
        }

        // Detalhar comentário com respostas
        public ActionResult Detalhes(int id)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == id);
            if (comentario != null)
            {
                return HttpNotFound();
            }
            
            return View(comentario);
        }

        // Editar comentário
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == id);
            if (comentario != null)
            {
                return View(comentario);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Editar(Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                var comentarioExistente = comentarios.FirstOrDefault(c => c.Id == comentario.Id);
                if (comentarioExistente != null)
                {
                    comentarioExistente.Texto = comentario.Texto;
                    return RedirectToAction("Index");
                }
            }
            return View(comentario);
        }

        // Excluir comentário
        public ActionResult Excluir(int id, int comentarioId)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == id);
            if (comentario != null)
            {
                comentarios.Remove(comentario);
                return RedirectToAction("Detalhes", "Comentario", new { id = comentarioId });
            }
            return HttpNotFound();
        }
    }

}