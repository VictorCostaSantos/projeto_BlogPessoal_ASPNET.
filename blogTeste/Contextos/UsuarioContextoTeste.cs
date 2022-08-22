using BlogAPI.Src.Contextos;
using BlogAPI.Src.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BlogTeste.Contextos
{
    /// <summary>
    /// <para>Resumo: Classe para texte unitario de contexto de usuario</para>
    /// <para>Criado por: Generation</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 17/07/2022</para>
    /// </summary>
    [TestClass]
    public class UsuarioContextoTeste
    {
        #region Atributos
        private BlogPessoalContexto _contexto;
        #endregion
        #region Métodos
        [TestMethod]
        public void LerListaDeUsuariosRetornaTresUsuarios()
        {
            // Ambiente
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT2")
            .Options;
            _contexto = new BlogPessoalContexto(opt);
            // DADO - Dado que adiciono 3 usuarios novos no sistema
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Pamela Boaz",
                Email = "pamela@email.com",
                Senha = "134652",
                Foto = "URLFOTOPAMELABOAZ",
            });
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Mallu Boaz",
                Email = "mallu@email.com",
                Senha = "134652",
                Foto = "URLFOTOMALLUBOAZ",
            });
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Catarina Boaz",
                Email = "catarina@email.com",
                Senha = "134652",
                Foto = "URLFOTOCATARINABOAZ",
            });
            _contexto.SaveChanges();
            // QUANDO - Quando eu pesquisar por todos os usuarios
            var resultado = _contexto.Usuarios.ToList();
            // ENTÃO - Então deve retornar uma lista com 3 usuarios
            Assert.AreEqual(3, resultado.Count);
        }

    }

    #endregion
}



