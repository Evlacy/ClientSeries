using ClientSeries.Models;
using ClientSeries.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSeries.ViewModels
{
    public abstract class SerieViewModel : ObservableObject
    {
        public async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://apiseriesevlacy.azurewebsites.net");
            List<Serie> result = await service.GetSeriesAsync();
            if (result == null)
                MessageAsync("Erreur", "API non disponible !");
            else
                Series = new ObservableCollection<Serie>(result);
            Series = new ObservableCollection<Serie>(result);
        }

        public async void MessageAsync(string title, string message)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = "Ok"
            };

            dialog.XamlRoot = App.MainRoot.XamlRoot; // Erreurs
            await dialog.ShowAsync();
        }

        private Serie serieToAdd;

        public Serie SerieToAdd
        {
            get { return serieToAdd; }
            set { serieToAdd = value; }
        }


        private ObservableCollection<Serie> series;

        public ObservableCollection<Serie> Series
        {
            get { return series; }
            set
            {
                series = value;
                OnPropertyChanged();
            }
        }

        private int serieid;
        public int Serieid {
            get { return serieid; }
            set
            {
                serieid = value;
                OnPropertyChanged();
            }
        }

        private string titre;
        public string Titre {
            get { return titre; }
            set
            {
                titre = value;
                OnPropertyChanged();
            }
        } 

        private string resume;
        public string Resume {
            get { return resume; }
            set
            {
                resume = value;
                OnPropertyChanged();
            }
        }
        private int nbsaisons;
        public int Nbsaisons {
            get { return nbsaisons; }
            set
            {
                nbsaisons = value;
                OnPropertyChanged();
            }
        }
        private int nbepisodes;
        public int Nbepisodes {
            get { return nbepisodes; }
            set
            {
                nbepisodes = value;
                OnPropertyChanged();
            }
        }
        private int anneecreation;
        public int Anneecreation {
            get { return anneecreation; }
            set
            {
                anneecreation = value;
                OnPropertyChanged();
            }
        }
        private string network;
        public string Network {
            get { return network; }
            set
            {
                network = value;
                OnPropertyChanged();
            }
        }
    }
}
