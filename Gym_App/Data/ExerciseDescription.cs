using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_App.Data
{
    public class ExerciseDescription
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string ExerciseName { get; set; }
        public string Description { get; set; }
    }
}
