using System;
using System.Drawing;
using System.Drawing.Imaging;
using Macaroni.Models.Abstractions;

namespace Macaroni.Models.EventTriggers
{
    public class PixelEventTrigger : IEventTrigger
    {
        private readonly int _sensitivity;

        private readonly Point _point;

        private readonly Color _colorMatch;


        public PixelEventTrigger(Point point, Color colorMatch, int sensitivity)
        {
            _sensitivity = sensitivity;

            _point = point;

            _colorMatch = colorMatch;
        }

        public bool IsTriggering()
        {
            var pixelColor = GetPixelColorAtPoint();

            if (IsMatch(pixelColor))
            {
                return true;
            }

            return false;
        }

        private bool IsMatch(Color pixelColor)
            => pixelColor.R + _sensitivity > _colorMatch.R &&
            pixelColor.R - _sensitivity < _colorMatch.R &&
            pixelColor.G + _sensitivity > _colorMatch.G &&
            pixelColor.G - _sensitivity < _colorMatch.R &&
            pixelColor.B + _sensitivity > _colorMatch.B &&
            pixelColor.B - _sensitivity < _colorMatch.B;

        private Color GetPixelColorAtPoint()
        {
            var bounds = new Rectangle(_point.X, _point.Y, 10, 10);

            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
                bitmap.Save("text.jpg", ImageFormat.Jpeg);
                return bitmap.GetPixel(0, 0);
            }
        }
    }
}
