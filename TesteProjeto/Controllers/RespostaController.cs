using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteProjeto.Models;

namespace TesteProjeto.Controllers
{
    public class RespostaController : Controller
    {
        private readonly List<Comentario> comentarios = new List<Comentario>();
        // Adicionar resposta ao comentário
        [HttpGet]
        public ActionResult Criar(int comentarioId)
        {
            ViewBag.ComentarioId = comentarioId;
            return View();
        }

        [HttpPost]
        public ActionResult Criar(Resposta resposta)
        {
            if (ModelState.IsValid)
            {
                resposta.DataCriacao = DateTime.Now;
                var comentario = comentarios.FirstOrDefault(c => c.Id == resposta.ComentarioId);
                if (comentario != null)
                {
                    comentario.Respostas.Add(resposta);
                    return RedirectToAction("Detalhes", "Comentario", new { id = resposta.ComentarioId });
                }
            }
            return View(resposta);
        }

        // Excluir resposta
        public ActionResult Excluir(int id, int comentarioId)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == comentarioId);
            if (comentario != null)
            {
                var resposta = comentario.Respostas.FirstOrDefault(r => r.Id == id);
                if (resposta != null)
                {
                    comentario.Respostas.Remove(resposta);
                    return RedirectToAction("Detalhes", "Comentario", new { id = comentarioId });
                }
            }
            return HttpNotFound();
        }
    }

}