using ASP.NET.ViniciusNunes.WebApp.Models;
using ASP.NET.ViniciusNunes.WebApp.Repository;
using System.Linq;
using System.Web.Mvc;

namespace ASP.NET.ViniciusNunes.WebApp.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoRepository repository;

        public EmprestimoController(IEmprestimoRepository repository)
        {
            this.repository = repository;
        }

        EmprestimoRepository contexto = new EmprestimoRepository();

        // GET: Emprestimo
        public ActionResult Index()
        {
            var emprestimos = contexto.GetAllEmprestimos();

            return View(emprestimos.Select(a => new EmprestimoViewModel()
            {
                Id = a.Id,
                dataEmprestimo = a.dataEmprestimo,
                dataDevolucao = a.dataDevolucao,
                livroId = a.livroId
            }));
        }

        // GET: Emprestimo/Details/5
        public ActionResult Details(int id)
        {
            var emprestimo = contexto.GetEmprestimosDetails(id);
            var emprestimoView = new EmprestimoViewModel()
            {
                Id = emprestimo.Id,
                dataEmprestimo = emprestimo.dataEmprestimo,
                dataDevolucao = emprestimo.dataDevolucao,
                livroId = emprestimo.livroId
            };
            return View(emprestimoView);
        }

        // GET: Emprestimo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emprestimo/Create
        [HttpPost]
        public ActionResult Create(EmprestimoViewModel collection)
        {
            try
            {
                contexto.AdicionarEmprestimo(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emprestimo/Edit/5
        public ActionResult Edit(int id)
        {
            var emprestimo = contexto.GetEmprestimosDetails(id);
            var emprestimoView = new EmprestimoViewModel()
            {
                Id = emprestimo.Id,
                dataEmprestimo = emprestimo.dataEmprestimo,
                dataDevolucao = emprestimo.dataDevolucao,
                livroId = emprestimo.livroId
            };
            return View(emprestimoView);
        }

        // POST: Emprestimo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var emprestimo = contexto.GetEmprestimosDetails(id);
                contexto.AtualizarEmprestimo(emprestimo);
                return RedirectToAction("Index");
            }
            catch   
            {
                return View();
            }
        }

        // GET: Emprestimo/Delete/5
        public ActionResult Delete(int id)
        {
            var emprestimo = contexto.GetEmprestimosDetails(id);
            var emprestimoView = new EmprestimoViewModel()
            {
                Id = emprestimo.Id,
                dataEmprestimo = emprestimo.dataEmprestimo,
                dataDevolucao = emprestimo.dataDevolucao,
                livroId = emprestimo.livroId
            };
            return View(emprestimoView);
        }

        // POST: Emprestimo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                contexto.DeletarEmprestimo(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
