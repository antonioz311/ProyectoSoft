using GestionInventario.Models;
using System.Collections.Generic;
using System.Linq;

namespace GestionInventario.Repositories
{
    public class UsuarioRepositorio
    {
        public static List<Usuario> Usuarios { get; private set; } = new List<Usuario>();

        // Crear usuario
        public void CrearUsuario(Usuario usuario)
        {
            if (Usuarios.Any(u => u.NumeroDocumento == usuario.NumeroDocumento))
            {
                throw new ArgumentException("El usuario ya existe con el mismo número de documento.");
            }
            Usuarios.Add(usuario);
        }

        // Modificar usuario
        public void ModificarUsuario(Usuario usuarioModificado)
        {
            var usuario = Usuarios.FirstOrDefault(u => u.Id == usuarioModificado.Id);
            if (usuario != null)
            {
                usuario.Nombre = usuarioModificado.Nombre;
                usuario.Apellido = usuarioModificado.Apellido;
                usuario.TipoDocumento = usuarioModificado.TipoDocumento;
                usuario.NumeroDocumento = usuarioModificado.NumeroDocumento;
                usuario.Direccion = usuarioModificado.Direccion;
                usuario.Telefono = usuarioModificado.Telefono;
                usuario.EstadoActivo = usuarioModificado.EstadoActivo;
                usuario.Password = usuarioModificado.Password;
            }
            else
            {
                throw new ArgumentException("Usuario no encontrado.");
            }
        }

        // Obtener usuario por email
        public Usuario ObtenerUsuarioPorEmail(string email)
        {
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return Usuarios.FirstOrDefault(u => u.NumeroDocumento == email);
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        // Obtener todos los usuarios
        public List<Usuario> ObtenerUsuarios()
        {
            return Usuarios;
        }

        // Activar/Inactivar usuario
        public void CambiarEstadoUsuario(int id, bool estado)
        {
            var usuario = Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                usuario.EstadoActivo = estado;
            }
            else
            {
                throw new ArgumentException("Usuario no encontrado.");
            }
        }
    }
}
