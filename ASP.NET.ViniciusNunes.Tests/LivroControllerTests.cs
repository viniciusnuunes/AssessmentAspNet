using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASP.NET.ViniciusNunes.WebApp.Repository;
using Moq;
using ASP.NET.ViniciusNunes.WebApp.Domain;
using ASP.NET.ViniciusNunes.WebApp.Controllers;
using ASP.NET.ViniciusNunes.WebApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace ASP.NET.ViniciusNunes.Tests
{
    /// <summary>
    /// Descrição resumida para LivroControllerTests
    /// </summary>
    [TestClass]
    public class LivroControllerTests
    {
        public LivroControllerTests()
        {
            //
            // TODO: Adicionar lógica de construtor aqui
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtém ou define o contexto do teste que provê
        ///informação e funcionalidade da execução de teste atual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de teste adicionais
        //
        // É possível usar os seguintes atributos adicionais enquanto escreve os testes:
        //
        // Use ClassInitialize para executar código antes de executar o primeiro teste na classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para executar código após a execução de todos os testes em uma classe
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize para executar código antes de executar cada teste 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para executar código após execução de cada teste
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateLivroTestMethod()
        {
            // Arrange
            var MockRepository = new Mock<ILivroRepository>();

            var LivroCreate = new LivroViewModel() { Id = 1, Nome = "Teste Moq Create 1", Autor = "Vinicius Nunes", Editora = "Pessoal", Ano = "1990" };
            
            var controller = new LivroController(MockRepository.Object);

            // Act
            var result = controller.Create(LivroCreate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));

            var viewResult = result as RedirectToRouteResult;
            var model = viewResult.RouteValues.Values.First();
            Assert.IsTrue(model.Equals("Index"));            
        }

        [TestMethod]
        public void EditLivroTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<ILivroRepository>();

            var LivroEdit = new Livro() { Id = 1, Nome = "Teste Moq Edit 1", Autor = "Nunes Vinicius", Editora = "Informal", Ano = "2000" };
            mockRepository.Setup(repository => repository.AtualizarLivro(LivroEdit));
            var controller = new LivroController(mockRepository.Object);

            // Act
            var result = controller.Edit(LivroEdit);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            var viewResult = result as RedirectToRouteResult;
            var model = viewResult.RouteValues.Values.First();
            Assert.IsTrue(model.Equals("Index"));
        }
    }
}
