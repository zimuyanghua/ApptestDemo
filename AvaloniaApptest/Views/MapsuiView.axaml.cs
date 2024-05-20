using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Markup.Xaml;
using AvaloniaApptest.ViewModels;
using BruTile.Predefined;
using BruTile.Web;
using CommunityToolkit.Mvvm.Messaging;
using Mapsui.Extensions;
using Mapsui.Projections;
using Mapsui.Tiling.Layers;
using Mapsui.UI.Avalonia;
using Mapsui.UI.Avalonia.Extensions;
using Mapsui.Widgets.ScaleBar;
using System;

namespace AvaloniaApptest.Views;

public partial class MapsuiView : UserControl
{
    private WindowNotificationManager? _manager;
    public MapsuiView()
    {
        InitializeComponent();
        InitMap();
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        var topLevel = TopLevel.GetTopLevel(this);
        _manager = new WindowNotificationManager(topLevel) { MaxItems = 1, Position = NotificationPosition.TopRight };
    }

    private void InitMap()
    {
        var tileSource = KnownTileSources.Create(KnownTileSource.BingAerial);
        var tileLayer = new TileLayer(tileSource)
        {
            Name = "tileLayer"
        };
        mapControl.Map?.Layers.Add(tileLayer);
        ScaleBarWidget scaleBarWidget = new ScaleBarWidget(mapControl.Map)
        {
            HorizontalAlignment = Mapsui.Widgets.HorizontalAlignment.Left,
            VerticalAlignment = Mapsui.Widgets.VerticalAlignment.Bottom,
        };
        mapControl.Map?.Widgets.Add(scaleBarWidget);

        mapControl.AddHandler(MapControl.PointerPressedEvent, (s, e) =>
        {
            
            var position = e.GetPosition(mapControl).ToMapsui();
            var viewPort = mapControl.Map?.Navigator.Viewport;
           
            var geoPosition = viewPort?.ScreenToWorld(position);
            
            var lonlat = SphericalMercator.ToLonLat(geoPosition);
            WeakReferenceMessenger.Default.Send(new MapPointMessage(position.X, position.Y, lonlat.X, lonlat.Y));
        });
    }
}