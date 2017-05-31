using ASP.NET.ViniciusNunes.WebApp.Controllers;
using ASP.NET.ViniciusNunes.WebApp.Domain;
using ASP.NET.ViniciusNunes.WebApp.Models;
using ASP.NET.ViniciusNunes.WebApp.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Web.Mvc;

namespace ASP.NET.ViniciusNunes.Tests
{
    /// <summary>
    /// Summary description for EmprestimoControllerTest
    /// </summary>
    [TestClass]
    public class EmprestimoControllerTest
    {
        public EmprestimoControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateEmprestimoTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<IEmprestimoRepository>();

            var EmprestimoCreate = new EmprestimoViewModel() { Id = 1, dataEmprestimo = "01/01/2017", dataDevolucao = "30/01/2017", livroId = 1 };

            mockRepository.Setup(repository => repository.AdicionarEmprestimo(EmprestimoCreate));

            var controller = new EmprestimoController(mockRepository.Object);

            // Act
            var result = controller.Create(EmprestimoCreate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));

            var viewResult = result as RedirectToRouteResult;
            var model = viewResult.RouteValues.Values.First();
            Assert.IsTrue(model.Equals("Index"));
        }

        public void EditEmprestimotestMethod()
        {
            //Arrange
            Mock<IEmprestimoRepository> mockRepository = new Mock<IEmprestimoRepository>();

            var EmprestimoEdit = new Emprestimo() { Id = 2, dataEmprestimo = "20/05/2017", dataDevolucao = "30/06/2017", livroId = 2 };

            mockRepository.Setup(repository => repository.AtualizarEmprestimo(EmprestimoEdit)
                );

            var controller = new EmprestimoController(mockRepository.Object);

            //act
            var result = controller.Edit(EmprestimoEdit);

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            var viewResult = result as RedirectToRouteResult;
            var model = viewResult.RouteValues.Values.First();
            Assert.IsTrue(model.Equals("ListaEmprestimo"));
        }
    }
}
