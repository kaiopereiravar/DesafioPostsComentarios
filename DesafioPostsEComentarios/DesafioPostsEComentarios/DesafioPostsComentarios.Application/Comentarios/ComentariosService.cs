using DesafioPostsComentarios.Repository;
using DesafioPostsComentarios.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace DesafioPostsComentarios.Application.Comentarios
{
    public class ComentariosService
    {
        private readonly DesafioPostsComentariosContext _context;

        public ComentariosService(DesafioPostsComentariosContext context)
        {
            _context = context;
        }

        public bool AdicionarComentario(ComentariosRequest request)
        {
            try
            {
                var comentario = new TabPosts()
                {
                    NomeConta = request.NomeConta,
                    Comentarios = request.Comentarios
                };

                _context.TabPosts.Add(comentario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<TabPosts> BuscarComentarios()
        {
            try
            {
                var comentarios = _context.TabPosts.ToList();
                if (comentarios == null)
                {
                    return null;
                }
                else
                {
                    return comentarios;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public bool AtualizarComentario(int id, ComentariosRequest request)
        {
            try
            {
                var comentario = _context.TabPosts.FirstOrDefault(x => x.id == id);
                if (comentario == null)
                    return false;

                comentario.NomeConta = request.NomeConta;
                comentario.Comentarios = request.Comentarios;

                _context.TabPosts.Update(comentario);
                _context.SaveChanges();
                return true;
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarComentario(int id)
        {
            try
            {
                var comentario = _context.TabPosts.FirstOrDefault(x => x.id == id);
                if (comentario == null)
                    return false;
                _context.TabPosts.Remove(comentario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
