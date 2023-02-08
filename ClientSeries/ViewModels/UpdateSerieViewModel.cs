using ClientSeries.Models;
using ClientSeries.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSeries.ViewModels
{
    public class UpdateSerieViewModel : SerieViewModel, ISerieViewModel
    {
        public UpdateSerieViewModel()
        {
            GetDataOnLoadAsync();
            BtnSearchSerie = new RelayCommand(ActionSearchSerie);
            BtnUpdateSerie = new RelayCommand(ActionUpdateSerie);
            BtnDeleteSerie = new RelayCommand(ActionDeleteSerie);
            ActualSerie = new Serie();
        }

        public IRelayCommand BtnSearchSerie { get; }
        public IRelayCommand BtnUpdateSerie { get; }
        public IRelayCommand BtnDeleteSerie { get; }

        public async void ActionSearchSerie()
        {
            WSService Service = new WSService("https://apiseriesevlacy.azurewebsites.net");
            ActualSerie = await Service.GetSerieAsync(ActualSerie.Serieid);
        }

        public async void ActionUpdateSerie()
        {
            WSService Service = new WSService("https://apiseriesevlacy.azurewebsites.net");
            Serie result = Service.GetSerieAsync(ActualSerie.Serieid).Result;
            result = ActualSerie;
            await Service.PutSerieAsync(result, ActualSerie.Serieid);
            MessageAsync("Informations", "La série a été modifié !");
        }
        
        public async void ActionDeleteSerie()
        {
            WSService Service = new WSService("https://apiseriesevlacy.azurewebsites.net");
            await Service.DeleteSerieAsync(ActualSerie.Serieid);
            MessageAsync("Informations", "La série a été supprimé !");
            ActualSerie = null;
        }
    }
}
