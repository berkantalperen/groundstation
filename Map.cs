using System.Drawing;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace groundstation
{
    partial class MainForm
    {
        private void init_map()
        {
            map.DragButton = System.Windows.Forms.MouseButtons.Left;
            map.ShowCenter = false;
            map.MapProvider = GoogleSatelliteMapProvider.Instance;
            map.CacheLocation = DocsFilePath + "\\map_cache";
            map.Position = new PointLatLng(_ortPos[0], _ortPos[1]);
        }
        private void MapFromObject(object data)
        {
            if (data.GetType().GetProperty(GpsPropName) != null && data.GetType().GetProperty(GpsPropName)?.GetValue(data) != null)
            {
                var posObject = data.GetType().GetProperty(GpsPropName)?.GetValue(data);
                dynamic lat = posObject?.GetType().GetProperty(GpsLatPropName)?.GetValue(posObject);
                dynamic lon = posObject?.GetType().GetProperty(GpsLonPropName)?.GetValue(posObject);
                if (data.GetType().GetProperty(ComPropName) != null && data.GetType().GetProperty(ComPropName)?.GetValue(data) != null)
                {
                    UpdateMarker((string)data.GetType().GetProperty(ComPropName)?.GetValue(data), lat, lon);
                }
                else
                {
                    UpdateMarker("unknown", lat, lon);
                }
                noGPSLabel.Visible = false;
            }
            else
            {
                noGPSLabel.Visible = true;
            }
        }
        private void UpdateMarker(string markerId, double lat, double lon)
        {
            var pos = new PointLatLng(lat, lon);
            map.Position = pos;
            GMapMarker marker = markerId == "Container" ? new GMarkerGoogle(pos, (Bitmap)Image.FromFile("")) : markerId == "Probe" ? new GMarkerGoogle(pos, (Bitmap)Image.FromFile("")) : new GMarkerGoogle(pos, GMarkerGoogleType.red);
            var overlayExists = false;
            foreach (var overlay in map.Overlays)
            {
                if (overlay.Id != $"{markerId}Overlay") continue;
                overlay.Clear();
                overlayExists = true;
                overlay.Markers.Add(marker);
            }
            if (!overlayExists)
            {
                var markers = new GMapOverlay($"{markerId}Overlay");
                markers.Markers.Add(marker);
                map.Overlays.Add(markers);
            }
            map.Zoom++;
            map.Zoom--;
        }
    }
}
