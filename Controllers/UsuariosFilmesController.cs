using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaRelacionamento.Controllers
{
    public class UsuariosFilmesController : Controller
    {
        private readonly Contexto db;

        public UsuariosFilmesController(Contexto contexto)

        {
            db = contexto;
        }

        [HttpGet("[controller]/[action]/{usuarioId}/{filmeId}")]
        public ActionResult Favoritar(int usuarioId, int filmeId)
        {
            Entidades.Usuarios_Filmes novoRegistro =
                new Entidades.Usuarios_Filmes();
            novoRegistro.FilmeId = filmeId;
            novoRegistro.UsuarioId = usuarioId;
            db.USUARIOS_FILMES.Add(novoRegistro);
            db.SaveChanges();
            return Redirect("/Usuarios");
        }
        public ActionResult RemoverFavorito (int id)
            {
                db.USUARIOS_FILMES.Remove(
                db.USUARIOS_FILMES.Find(id)
                );
                db.SaveChanges();
                return Redirect("/Usuarios");
            }
        }
    }

