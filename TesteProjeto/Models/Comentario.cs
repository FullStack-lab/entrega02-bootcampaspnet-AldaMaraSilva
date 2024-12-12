using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteProjeto.Models
{
    
    public class Comentario
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string Autor { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<Resposta> Respostas { get; set; }
    }

    public class Resposta
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string Autor { get; set; }
        public DateTime DataCriacao { get; set; }
        public int ComentarioId { get; set; }
    }
    

}

