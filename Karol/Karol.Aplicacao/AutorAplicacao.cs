using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Karol.Dominio;
using Karol.Repositorio;

namespace Karol.Aplicacao
{
    public class AutorAplicacao
    {
        private readonly Contexto contexto = new Contexto();

        private void Inserir(Autor autor)
        {
            var strQuery = " ";
            strQuery += " INSERT INTO AUTOR (Nome, Email, Biografia) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}') ",
                autor.Nome, autor.Email, autor.Biografia);
            contexto.ExecutaComando(strQuery);
        }

        private void Alterar(Autor autor)
        {
            var strQuery = " ";
            strQuery += " UPDATE AUTOR SET ";
            strQuery += string.Format(" Nome = '{0}', ", autor.Nome);
            strQuery += string.Format(" Email = '{0}', ", autor.Email);
            strQuery += string.Format(" Biografia = '{0}' ", autor.Biografia);
            strQuery += string.Format(" WHERE AutorId = {0}", autor.AutorId);
            contexto.ExecutaComando(strQuery);
        }

        public void Salvar(Autor autor)
        {
            if (autor.AutorId > 0)
                Alterar(autor);
            else
                Inserir(autor);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM AUTOR WHERE AutorId = {0} ", id);
            contexto.ExecutaComando(strQuery);
        }

        public List<Autor> ListarTodos()
        {
            var strQuery = " SELECT * FROM AUTOR ";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public Autor ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM AUTOR WHERE AutorId = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }

        private List<Autor> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var autor = new List<Autor>();
            while (reader.Read())
            {
                var tempObjeto = new Autor
                                     {
                                         AutorId = int.Parse(reader["AutorId"].ToString()),
                                         Nome = reader["Nome"].ToString(),
                                         Email = reader["Email"].ToString(),
                                         Biografia = reader["Biografia"].ToString()
                                     };
                autor.Add(tempObjeto);
            }
            return autor;
        }
    }
}

