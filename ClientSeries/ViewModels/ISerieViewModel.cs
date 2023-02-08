using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSeries.ViewModels
{
    public interface ISerieViewModel
    {
        void GetDataOnLoadAsync();
        void MessageAsync(string title, string message);
    }
}
