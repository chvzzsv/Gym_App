using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Gym_App.Models;

namespace Gym_App.Views
{
    public partial class AgendarPage : ContentPage
    {
        private ObservableCollection<Cita> citas = new ObservableCollection<Cita>();
        private DatabaseService dbService;

        public AgendarPage()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            dbService = new DatabaseService();
            HorariosTableView.Root = new TableRoot();
            CargarHorariosDesdeBaseDeDatos();
        }

        private void Agregar_Clicked(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var cita = new Cita
                {
                    Fecha = SemanaPicker.Date,
                    Rutina = NombreEntry.SelectedItem.ToString(),
                    Hora = ObtenerHoraCompleta(),  // Obtener la hora completa desde el Entry y Picker
                    UsuarioId = DatabaseService.UsuarioActual.Id // Asigna el ID del usuario actual
                };
                dbService.AgregarCita(cita);
                citas.Add(cita);
                ActualizarTabla();
            }
            else
            {
                MostrarMensajeError("Por favor, complete todos los campos.");
            }
        }

        private string ObtenerHoraCompleta()
        {
            return $"{HoraEntry.Text} {AmPmPicker.SelectedItem}";
        }

        private bool ValidarCampos()
        {
            return SemanaPicker.Date != null &&
                   NombreEntry.SelectedItem != null &&
                   !string.IsNullOrWhiteSpace(HoraEntry.Text) &&
                   AmPmPicker.SelectedItem != null;
        }

        private async void Modificar_Clicked(object sender, EventArgs e)
        {
            var cita = (Cita)((Button)sender).CommandParameter;
            if (cita != null)
            {
                string nuevaFechaStr = await DisplayPromptAsync("Modificar Fecha", "Ingrese la nueva fecha (dd/MM/yyyy):", initialValue: cita.Fecha.ToString("dd/MM/yyyy"));
                string nuevoDia = await DisplayPromptAsync("Modificar rutina", "Ingrese la nueva rutina:", initialValue: cita.Rutina);
                string nuevaHora = await DisplayPromptAsync("Modificar horario", "Ingrese el nuevo horario:", initialValue: cita.Hora);

                if (DateTime.TryParse(nuevaFechaStr, out DateTime nuevaFecha) && !string.IsNullOrWhiteSpace(nuevoDia) && !string.IsNullOrWhiteSpace(nuevaHora))
                {
                    cita.Fecha = nuevaFecha;
                    cita.Rutina = nuevoDia;
                    cita.Hora = nuevaHora;
                    dbService.ActualizarCita(cita);
                    ActualizarTabla();
                }
                else
                {
                    MostrarMensajeError("Datos inválidos. Por favor, inténtelo de nuevo.");
                }
            }
        }

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            var cita = (Cita)((Button)sender).CommandParameter;
            if (cita != null)
            {
                bool respuesta = await DisplayAlert("Confirmación", "¿Está seguro de que desea eliminar esta visita al Gym?", "Sí", "Cancelar");

                if (respuesta)
                {
                    dbService.EliminarCita(cita);
                    citas.Remove(cita);
                    ActualizarTabla();
                }
            }
        }

        private void ActualizarTabla()
        {
            var section = new TableSection();
            section.Add(new ViewCell
            {
                View = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(10),
                    BackgroundColor = Color.FromHex("#017BFF"),
                    Children =
                    {
                        new Label { Text = "  Fecha", FontAttributes = FontAttributes.Bold, TextColor = Color.White },
                        new Label { Text = "   Rutina", FontAttributes = FontAttributes.Bold, TextColor = Color.White },
                        new Label { Text = "   Hora", FontAttributes = FontAttributes.Bold, TextColor = Color.White }
                    }
                }
            });

            foreach (var cita in citas)
            {
                var viewCell = CrearViewCell(cita);
                section.Add(viewCell);
            }

            HorariosTableView.Root.Clear();
            HorariosTableView.Root.Add(section);
        }

        private ViewCell CrearViewCell(Cita cita)
        {
            var viewCell = new ViewCell
            {
                View = new Grid
                {
                    Padding = new Thickness(10, 5),
                    ColumnDefinitions = new ColumnDefinitionCollection
                    {
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) }
                    },
                    Children =
                    {
                        new Label
                        {
                            Text = cita.Fecha.ToShortDateString(),
                            VerticalOptions = LayoutOptions.Center
                        },
                        new Label
                        {
                            Text = cita.Rutina,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.CenterAndExpand
                        },
                        new Label
                        {
                            Text = cita.Hora,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.EndAndExpand
                        },
                        CrearBoton("Modificar", cita, Modificar_Clicked),
                        CrearBotonEliminar("Eliminar", cita, Eliminar_Clicked) // Utilizamos la función para crear el botón de eliminar
                    }
                }
            };

            Grid.SetColumn((viewCell.View as Grid).Children[0], 0);
            Grid.SetColumn((viewCell.View as Grid).Children[1], 1);
            Grid.SetColumn((viewCell.View as Grid).Children[2], 2);
            Grid.SetColumn((viewCell.View as Grid).Children[3], 3);
            Grid.SetColumn((viewCell.View as Grid).Children[4], 4);

            return viewCell;
        }

        private Button CrearBoton(string texto, Cita cita, EventHandler action)
        {
            var button = new Button
            {
                Text = texto,
                CommandParameter = cita,
                Style = (Style)Application.Current.Resources["PrimaryButton"]
            };
            button.Clicked += action;
            return button;
        }

        private Button CrearBotonEliminar(string texto, Cita cita, EventHandler action)
        {
            var button = new Button
            {
                Text = texto,
                CommandParameter = cita,
                Style = (Style)Application.Current.Resources["DangerButton"] // Utilizamos el estilo "DangerButton" definido en tus recursos de la aplicación
            };
            button.Clicked += action;
            return button;
        }

        private void CargarHorariosDesdeBaseDeDatos()
        {
            try
            {
                var citasDb = dbService.ObtenerCitas();
                foreach (var cita in citasDb)
                {
                    citas.Add(cita);
                }
                ActualizarTabla();
            }
            catch (Exception ex)
            {
                MostrarMensajeError("Error al cargar las citas desde la base de datos: " + ex.Message);
            }
        }

        private void MostrarMensajeError(string mensaje)
        {
            DisplayAlert("Error", mensaje, "Aceptar");
        }

        private void NombreEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NombreEntry.SelectedIndex != -1)
            {
                var picker = sender as Picker;
                var selectedTextColor = Color.Black;
                picker.TextColor = selectedTextColor;
            }
        }
        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Dashboard());

        }

    }
}