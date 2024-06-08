using Gym_App.Data;
using Gym_App.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

public class DatabaseService
{
    private readonly SQLiteConnection db;
    public static Usuario UsuarioActual { get; private set; }

    public DatabaseService()
    {
        db = Database.Instance;
        AgregarDescripcionesDeEjerciciosPredeterminadas();

    }
    public List<ExerciseDescription> ObtenerDescripcionesDeEjercicios()
    {
        return db.Table<ExerciseDescription>().ToList();
    }
    public bool ValidarCredenciales(string nombre, string contraseña)
    {
        var usuario = db.Table<Usuario>().FirstOrDefault(u => u.Nombre == nombre);
        if (usuario != null && contraseña == usuario.Contraseña)
        {
            UsuarioActual = usuario;
            return true;
        }
        return false;
    }

    public void CerrarSesion()
    {
        UsuarioActual = null;
    }

    public void AgregarUsuario(Usuario usuario)
    {
        db.Insert(usuario);
    }

    public void AgregarCita(Cita cita)
    {
        cita.UsuarioId = UsuarioActual.Id;
        db.Insert(cita);
    }

    public List<Cita> ObtenerCitas()
    {
        return db.Table<Cita>().Where(c => c.UsuarioId == UsuarioActual.Id).ToList();
    }

    public void AgregarUsuarioDePrueba()
    {
        var usuario = new Usuario { Nombre = "admin", Contraseña = "1234" };
        db.Insert(usuario);
        var usuario2 = new Usuario { Nombre = "u20210861", Contraseña = "123" };
        db.Insert(usuario2);
        var usuario3 = new Usuario { Nombre = "adonis", Contraseña = "roxy" };
        db.Insert(usuario3);
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

    public void ActualizarCita(Cita cita)
    {
        db.Update(cita);
    }

    public void EliminarCita(Cita cita)
    {
        db.Delete(cita);
    }
    public static class ExerciseNames
    {
        public const string PressDeBancaConBarra = "PRESS DE BANCA CON BARRA";
        public const string PressDeBancaInclinadoConMancuernas = "PRESS DE BANCA INCLINADO CON MANCUERNAS";
        // Puedes agregar más nombres de ejercicios aquí si es necesario
    }
    public ExerciseDescription ObtenerDescripcionDeEjercicio(string exerciseName)
    {
        return db.Table<ExerciseDescription>().FirstOrDefault(e => e.ExerciseName == exerciseName);
    }
    private void AgregarDescripcionesDeEjerciciosPredeterminadas()
    {
        if (!db.Table<ExerciseDescription>().Any())
        {
            db.Insert(new ExerciseDescription
            {
                ExerciseName = "PRESS DE BANCA CON BARRA",
                Description = "Este es uno de los ejercicios más efectivos para desarrollar los pectorales. Acuéstate en un banco plano con los pies apoyados en el suelo. Agarra la barra con las manos ligeramente más anchas que el ancho de los hombros y bájala lentamente hacia el pecho. Luego, empuja la barra hacia arriba hasta que los brazos estén completamente extendidos."
            });

            db.Insert(new ExerciseDescription
            {
                ExerciseName = "PRESS DE BANCA INCLINADO CON MANCUERNAS",
                Description = "Este ejercicio se realiza en un banco inclinado y es ideal para trabajar la parte superior de los pectorales. Acuéstate en el banco inclinado con una mancuerna en cada mano. Baja las mancuernas lentamente hasta que estén a la altura de tus hombros y luego empújalas hacia arriba hasta que tus brazos estén completamente extendidos."
            });

            db.Insert(new ExerciseDescription
            {
                ExerciseName = "Remo con Mancuernas (Dumbbell Row)",
                Description = "El remo con mancuernas es un ejercicio eficaz para fortalecer los músculos de la espalda. Coloca una rodilla y una mano sobre un banco para estabilizarte. Con la otra mano, toma una mancuerna y déjala colgar hacia abajo. Levanta la mancuerna hacia tu torso, manteniendo el codo cerca del cuerpo. Baja la mancuerna de forma controlada para volver a la posición inicial."
            });
            db.Insert(new ExerciseDescription
            {
                ExerciseName = "Jalón al pecho (Lat Pulldown)",
                Description = "El jalón al pecho es un ejercicio fundamental para desarrollar la espalda. Siéntate en la máquina de jalón y agarra la barra con un agarre amplio. Tira de la barra hacia abajo hasta que toque la parte superior del pecho, asegurándote de mantener la espalda recta. Luego, deja que la barra suba de manera controlada para volver a la posición inicial."
            });

        }
    }

}



