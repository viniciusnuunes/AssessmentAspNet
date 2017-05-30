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
        public void IndexTestMethod()
        {
            // Arrange
            var MockRepository = new Mock<ILivroRepository>();
            MockRepository.Setup(repository => repository.GetAllBooks()).Returns(new List<Livro>()
            {
                new Livro() {Nome = "Teste Moq 1", Autor = "Vinicius Nunes", Editora = "Pessoal", Ano = "1990"},
                new Livro() {Nome = "Teste Moq 2", Autor = "Vinicius Pereira", Editora = "Eu Mesmo", Ano = "1993"}
            });

            var controller = new LivroController(MockRepository.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = result as ViewResult;
            var model = viewResult.ViewData.Model;
            Assert.IsInstanceOfType(model, typeof(IEnumerable<LivroViewModel>));

            var livros = model as IEnumerable<LivroViewModel>;
            Assert.AreEqual(2, livros.Count());
        }
    }
}
