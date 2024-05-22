using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_App.Models
{
    public class Cita
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
    }
}
