using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karol.Dominio;
using Karol.Repositorio;

namespace Karol.Aplicacao
{
    public class LivroAplicacao
    {
        private readonly Contexto contexto = new Contexto();

        private void Inserir(Livro livro)
        {
            var strQuery = " ";
            strQuery += " INSERT INTO LIVRO (Nome, DataDaPublicacao, Prefacio, Autor, Editora) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}','{4}') ",
                livro.Nome, livro.DataDaPublicacao, livro.Prefacio, livro.Autor, livro.Editora);
            contexto.ExecutaComando(strQuery);
        }

        private void Alterar(Livro livro)
        {
            var strQuery = " ";
            strQuery += " UPDATE LIVRO SET ";
            strQuery += string.Format(" Nome = '{0}', ", livro.Nome);
            strQuery += string.Format(" DataDaPublicacao = '{0}', ", livro.DataDaPublicacao);
            strQuery += string.Format(" Prefacio = '{0}', ", livro.Prefacio);
            strQuery += string.Format(" Editora = '{0}', ", livro.Editora);
            strQuery += string.Format(" Autor = '{0}' ", livro.Autor);
            strQuery += string.Format(" WHERE LivroId = {0}", livro.LivroId);
            contexto.ExecutaComando(strQuery);
        }

        public void Salvar(Livro livro)
        {
            if (livro.LivroId > 0)
                Alterar(livro);
            else
                Inserir(livro);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM LIVRO WHERE LivroId = {0} ", id);
            contexto.ExecutaComando(strQuery);
        }

        public List<Livro> ListarTodos()
        {
            var strQuery = " SELECT * FROM LIVRO ";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        private List<Livro> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var livros = new List<Livro>();
            while (reader.Read())
            {
                var tempObjeto = new Livro
                                     {
                                         LivroId = int.Parse(reader["LivroId"].ToString()),
                                         Nome = reader["Nome"].ToString(),
                                         DataDaPublicacao = DateTime.Parse(reader["DataDaPublicacao"].ToString()),
                                         Autor = reader["Autor"].ToString(),
                                         Editora = reader["Editora"].ToString(),
                                         Prefacio = reader["Prefacio"].ToString()
                                     };
                livros.Add(tempObjeto);
            }
            return livros;
        }
    }
}

