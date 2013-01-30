using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karol.Aplicacao;
using Karol.Dominio;

namespace Karol.UI.MsDos
{
    class Program
    {
        static void Main(string[] args)
        {
            var livro = new Livro();
            livro.LivroId = 1;
            livro.Nome = "APRENDA C#";
            livro.DataDaPublicacao = new DateTime(2013, 1, 29);
            livro.Autor = "Cleyton Ferrari";
            livro.Editora = "Faar Publicações";
            livro.Prefacio = "Aprenda a desenvolver aplicações em C#";

            var aplicacao = new LivroAplicacao();
            //aplicacao.Salvar(livro);
            aplicacao.Excluir(1);

            var lista = aplicacao.ListarTodos();
            foreach (var l in lista)
            {
                Console.Write("{0}{1}{2}{3}{4}{5}", l.LivroId, l.Autor, l.DataDaPublicacao, l.Editora, l.Nome, l.Prefacio);
            }
        }
    }
}
