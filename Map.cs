using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using System.Drawing;
using GMap.NET.MapProviders;

namespace groundstation
{
    partial class MainForm
    {
        public void init_map()
        {
            map.DragButton = System.Windows.Forms.MouseButtons.Left;
            map.ShowCenter = false;
            map.MapProvider = GoogleSatelliteMapProvider.Instance;
            map.CacheLocation = "map_cache";
            map.Position = new PointLatLng(ort_pos[0], ort_pos[1]);
        }
        public void updateMarker(string markerId, double lat, double lon)
        {
            PointLatLng pos = new PointLatLng(lat, lon);
            map.Position = pos;
            GMapMarker marker = markerId == "Container" ? new GMarkerGoogle(pos, (Bitmap)Image.FromFile("")) : markerId == "Probe" ? new GMarkerGoogle(pos, (Bitmap)Image.FromFile("")) : new GMarkerGoogle(pos, GMarkerGoogleType.red);
            bool overlayExists = false;
            foreach (GMapOverlay overlay in map.Overlays)
            {
                if (overlay.Id == $"{markerId}Overlay")
                {
                    overlay.Clear();
                    overlayExists = true;
                    overlay.Markers.Add(marker);
                }
            }
            if (!overlayExists)
            {
                GMapOverlay markers = new GMapOverlay($"{markerId}Overlay");
                markers.Markers.Add(marker);
                map.Overlays.Add(markers);
            }
            map.Zoom--;
            map.Zoom++;
        }
    }
}
