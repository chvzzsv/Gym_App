using Gym_App.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

public class DatabaseService
{
    private readonly SQLiteConnection db;

    public DatabaseService()
    {
        db = Database.Instance;
    }

    public bool ValidarCredenciales(string nombre, string contraseña)
    {
        var usuario = db.Table<Usuario>().FirstOrDefault(u => u.Nombre == nombre);
        if (usuario != null)
        {
            // Verificar la contraseña con la contraseña actualizada del usuario
            return contraseña == usuario.Contraseña;
        }
        return false;
    }

    public void AgregarUsuario(Usuario usuario)
    {
        db.Insert(usuario);
    }

    public void AgregarCita(Cita cita)
    {
        db.Insert(cita);
    }

    public List<Cita> ObtenerCitas()
    {
        return db.Table<Cita>().ToList();
    }
    public void AgregarUsuarioDePrueba()
    {
        var usuario = new Usuario { Nombre = "admin", Contraseña = "1234" };
        db.Insert(usuario);
        var usuario2 = new Usuario { Nombre = "u20210861", Contraseña = "123" };
        db.Insert(usuario2);
    }
    public Usuario ObtenerUsuarioPorNombre(string nombre)
    {
        return db.Table<Usuario>().FirstOrDefault(u => u.Nombre == nombre);
    }

    public void ActualizarUsuario(Usuario usuario)
    {
        db.Update(usuario);
    }

    public bool ActualizarContraseña(string nombreUsuario, string nuevaContraseña)
    {
        var usuario = ObtenerUsuarioPorNombre(nombreUsuario);
        if (usuario != null)
        {
            usuario.Contraseña = nuevaContraseña;
            ActualizarUsuario(usuario);
            return true; // Contraseña actualizada correctamente
        }
        else
        {
            return false; // El usuario no existe en la base de datos
        }
    }
}