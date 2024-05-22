using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using Xamarin.Essentials;
using Gym_App.Models;

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
        }
    }

    public static SQLiteConnection Instance => db;
}
