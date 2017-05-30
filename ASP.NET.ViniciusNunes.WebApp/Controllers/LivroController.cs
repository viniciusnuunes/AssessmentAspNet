using ASP.NET.ViniciusNunes.WebApp.Domain;
using ASP.NET.ViniciusNunes.WebApp.Models;
using ASP.NET.ViniciusNunes.WebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.ViniciusNunes.WebApp.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepository repository;

        public LivroController (ILivroRepository repository)
        {
            this.repository = repository;
        }

        LivroRepository contexto = new LivroRepository();

        // GET: Livro
        public ActionResult Index()
        {
            var livro = contexto.GetAllBooks();

            return View(
                livro.Select(a => new LivroViewModel()
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    Autor = a.Autor,
                    Editora = a.Editora,
                    Ano = a.Ano
                }));
        }

        // GET: Livro/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var editar = contexto.GetAllBooks().Find(a => a.Id == id);

                LivroViewModel livro = new LivroViewModel()
                {
                    Id = editar.Id,
                    Nome = editar.Nome,
                    Autor = editar.Autor,
                    Editora = editar.Editora,
                    Ano = editar.Ano
                };
                return View(livro = new LivroViewModel()
                {
                    Id = livro.Id,
                    Nome = livro.Nome,
                    Autor = livro.Autor,
                    Editora = livro.Editora,
                    Ano = livro.Ano
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Errro teste", ex);
            }
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livro/Create
        [HttpPost]
        public ActionResult Create(LivroViewModel livro)
        {
            if (ModelState.IsValid)
            {
                contexto.AdicionarLivro(new Livro()
                {
                    Nome = livro.Nome,
                    Autor = livro.Autor,
                    Editora = livro.Editora,
                    Ano = livro.Ano
                });
                return RedirectToAction("Index");
            }
            return View(livro);
        }        

        // GET: Livro/Edit/5
        public ActionResult Edit(int Id = 1)
        {
            try
            {
                var editar = contexto.GetAllBooks().Find(a => a.Id == Id);

                LivroViewModel livro = new LivroViewModel()
                {
                    Id = editar.Id,
                    Nome = editar.Nome,
                    Autor = editar.Autor,
                    Editora = editar.Editora,
                    Ano = editar.Ano
                };
                return View(livro = new LivroViewModel()
                {
                    Id = livro.Id,
                    Nome = livro.Nome,
                    Autor = livro.Autor,
                    Editora = livro.Editora,
                    Ano = livro.Ano
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Errro teste", ex);
            }
        }

        // POST: Livro/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id, Livro livro)
        {
            if (ModelState.IsValid)
            {
                contexto.AtualizarLivro(Id, livro);
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                contexto.DeletarLivro(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }            
        }

        // POST: Livro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LivroViewModel livro)
        {
            livro.Id = id;
            contexto.DeletarLivro(livro.Id);
            return RedirectToAction("Index");
        }
    }
}
