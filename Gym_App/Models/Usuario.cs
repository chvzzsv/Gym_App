using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

public class Usuario
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Contraseña { get; set; }
    public string CodigoRecuperacion { get; set; }
}