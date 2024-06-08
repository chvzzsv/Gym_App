using System;
using System.IO;
using SQLite;
using Xamarin.Essentials;
using Gym_App.Models;
using Gym_App.Data;
using System.Linq;

public static class Database
{
    private static SQLiteConnection db;

    public static void Initialize()
    {
        if (db == null)
        {
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "gymBD.db");
            db = new SQLiteConnection(databasePath);
            db.CreateTable<Usuario>();
            db.CreateTable<Cita>();
            db.CreateTable<ExerciseDescription>();

            // Si es necesario agregar la columna UsuarioId en una base de datos existente
            try
            {
                db.Execute("ALTER TABLE Cita ADD COLUMN UsuarioId INTEGER DEFAULT 0");
            }
            catch (Exception)
            {
                // Si la columna ya existe, ignorar el error
            }
         
        }
    }

    public static SQLiteConnection Instance => db;
}
