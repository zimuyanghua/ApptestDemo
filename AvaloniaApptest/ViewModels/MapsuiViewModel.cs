using BruTile.Predefined;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Projections;
using Mapsui.Tiling.Layers;
using Mapsui.UI;
using Mapsui.UI.Avalonia;
using Mapsui.UI.Avalonia.Extensions;
using Mapsui.Widgets.ScaleBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApptest.ViewModels
{
    public record MapPointMessage(double positionX, double positionY, double lon, double lat);

    public partial class MapsuiViewModel : ViewModelBase
    {
        //[ObservableProperty]
        //private object _map;

        public MapsuiViewModel()
        {
            //var mapContol = new MapControl();

            //var tileSource = KnownTileSources.Create(KnownTileSource.BingAerial);
            //var tileLayer = new TileLayer(tileSource)
            //{
            //    Name = "tileLayer"
            //};
            //mapContol.Map?.Layers.Add(tileLayer);
            //ScaleBarWidget scaleBarWidget = new ScaleBarWidget(mapContol.Map)
            //{
            //    HorizontalAlignment = Mapsui.Widgets.HorizontalAlignment.Left,
            //    VerticalAlignment = Mapsui.Widgets.VerticalAlignment.Bottom,
            //};
            //mapContol.Map?.Widgets.Add(scaleBarWidget);

            //mapContol.AddHandler(MapControl.PointerPressedEvent, (s, e) =>
            //{
            //    //屏幕坐标
            //    var position = e.GetPosition(mapContol).ToMapsui();
            //    var viewPort = mapContol.Map?.Navigator.Viewport;
            //    //世界坐标
            //    var geoPosition = viewPort?.ScreenToWorld(position);
            //    //经纬度坐标
            //    var lonlat = SphericalMercator.ToLonLat(geoPosition);
            //    Messenger.Send(new MapPointMessage(position.X, position.Y, lonlat.X, lonlat.Y)); ;
            //});
            //Map = mapContol;
        }
    }
}
