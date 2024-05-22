using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gym_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecuperarContraseña : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public RecuperarContraseña()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private void GuardarCambios_Clicked(object sender, EventArgs e)
        {
            string nombreUsuario = codigoEntry.Text;
            string nuevaContraseña = nuevaContraseñaEntry.Text;

            if (_databaseService.ActualizarContraseña(nombreUsuario, nuevaContraseña))
            {
                // La contraseña se actualizó correctamente
                DisplayAlert("Éxito", "Contraseña actualizada correctamente", "OK");
            }
            else
            {
                // El usuario no existe en la base de datos
                DisplayAlert("Error", "El usuario no existe en la base de datos.", "OK");
            }

            Navigation.PopAsync(); // Regresa a la página de inicio de sesión
        }
    }
}
