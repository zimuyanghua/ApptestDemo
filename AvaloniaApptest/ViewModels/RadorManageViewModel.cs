using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApptest.ViewModels
{
    public partial class RadorManageViewModel : ViewModelBase
    {
        [ObservableProperty]
        public ViewModelBase _activeContent;

        [ObservableProperty]
        private double positionX = 0;
        [ObservableProperty]
        private double positionY = 0;
        [ObservableProperty]
        private double lon = 0;
        [ObservableProperty]
        private double lat = 0;

        [ObservableProperty]
        private string positon = "0,0";
        [ObservableProperty]
        private string latlon = "0,0";

        public RadorManageViewModel(MapsuiViewModel mapsuiViewModel)
        {

            _activeContent = mapsuiViewModel;

            WeakReferenceMessenger.Default.Register<MapPointMessage>(this, (r, m) =>
            {
                PositionX = m.positionX;
                PositionY = m.positionY;
                Lon = m.lon;
                Lat = m.lat;
                //Positon = m.positionX + "," + m.positionY;
                //保留小数点后两位
                Positon = Math.Round(m.positionX, 2) + ", " + Math.Round(m.positionY, 2);
                //Latlon = m.lat + "," + m.lon;
                //保留小数点后两位
                Latlon = Math.Round(m.lat, 2) + ", " + Math.Round(m.lon, 2);
            });
        }
    }
}
