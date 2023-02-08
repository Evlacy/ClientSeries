using ClientSeries.Models;
using ClientSeries.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSeries.ViewModels
{
    public class AddSerieViewModel : SerieViewModel, ISerieViewModel
    {
        public AddSerieViewModel()
        {
            GetDataOnLoadAsync();
            BtnPostSerie = new RelayCommand(ActionPostSerie);
            SerieToAdd = new Serie();
        }

        public IRelayCommand BtnPostSerie { get; }

        public async void ActionPostSerie()
        {
            WSService Service = new WSService("https://apiseriesevlacy.azurewebsites.net");

            if (SerieToAdd.Titre == null)
                MessageAsync("Erreur", "Il faut un titre !");
            else
            {
                await Service.PostSerieAsync(SerieToAdd);
                MessageAsync("Informations", "La série a bien été ajouté.");
            }
        }
    }
}
