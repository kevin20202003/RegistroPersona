using RegistroPersona.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using RegistroPersona.DataBase;

namespace RegistroPersona
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void OnAddClicked(object sender, EventArgs e)
        {
            var persona = new Persona
            {
                Cedula = CedulaEntry.Text,
                NombreCompleto = NombreEntry.Text
            };
            await App.Database.SavePersonaAsync(persona);
            CedulaEntry.Text = NombreEntry.Text = string.Empty;
            await DisplayAlert("Success", "Persona añadida correctamente", "OK");
            await LoadPersonasAsync();
        }

        async void OnUpdateClicked(object sender, EventArgs e)
        {
            var persona = await App.Database.GetPersonaAsync(CedulaEntry.Text);
            if (persona != null)
            {
                persona.NombreCompleto = NombreEntry.Text;
                await App.Database.UpdatePersonaAsync(persona);
                CedulaEntry.Text = NombreEntry.Text = string.Empty;
                await DisplayAlert("Success", "Persona actualizada correctamente", "OK");
                await LoadPersonasAsync();
            }
            else
            {
                await DisplayAlert("Error", "Persona no encontrada", "OK");
            }
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var persona = await App.Database.GetPersonaAsync(CedulaEntry.Text);
            if (persona != null)
            {
                await App.Database.DeletePersonaAsync(persona);
                CedulaEntry.Text = NombreEntry.Text = string.Empty;
                await DisplayAlert("Success", "Persona eliminada correctamente", "OK");
                await LoadPersonasAsync();
            }
            else
            {
                await DisplayAlert("Error", "Persona no encontrada", "OK");
            }
        }

        async void OnShowClicked(object sender, EventArgs e)
        {
            await LoadPersonasAsync();
        }

        async void OnActualizarRegistroClicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var persona = button?.CommandParameter as Persona;

            if (persona != null)
            {
                CedulaEntry.Text = persona.Cedula;
                NombreEntry.Text = persona.NombreCompleto;
            }
        }

        async Task LoadPersonasAsync()
        {
            PersonasListView.ItemsSource = await App.Database.GetPersonasAsync();
        }
    
}
}
