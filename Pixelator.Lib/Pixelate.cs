using System.Drawing;
using System.Drawing.Imaging;

namespace Pixelator.Lib
{
    public static class Pixelator
    {
        public static Bitmap Pixelate(Bitmap source, int targetHeight, double pixelSizePercent = .4 , bool average = true, double brighten = 1.2)
        {
            Bitmap target = new Bitmap(source.Width, source.Height, PixelFormat.Format24bppRgb);

            int step = source.Height / targetHeight;

            int pixelSize = (int)(step * pixelSizePercent);

            for (int y = step / 2; y < source.Height - 1; y += step)
            {
                for (int x = step / 2; x < source.Width - 1; x += step)
                {
                    // Averaging gives a smoother result.
                    Color color;
                    if (average)
                    {
                        color = AverageColor(source, x, y, step, step);
                    }
                    else
                    {
                        color = source.GetPixel(x, y);
                    }

                    // Brighten the color
                    color = Color.FromArgb(0, Skew(color.R, brighten), Skew(color.G, brighten), Skew(color.B, brighten));

                    // Make a larger pixel of a single color
                    for (int yd = -pixelSize / 2; yd <= pixelSize / 2; yd++)
                    {
                        for (int xd = -pixelSize / 2; xd <= pixelSize / 2; xd++)
                        {
                            if (x + xd >= 0 && x + xd < source.Width && y + yd >= 0 && y + yd < source.Height)
                            {
                                target.SetPixel(x + xd, y + yd, color);
                            }
                        }
                    }
                }
            }

            return target;
        }

        private static byte Skew(byte x, double amount)
        {
            var result = (x * amount);
            if (result > 255) return 255;
            return (byte)result;
            //byte headroom = (byte)(255 - x);
            //byte delta = (byte)(headroom * (1 - 1 / amount));
            //return (byte)(x + delta);
        }

        private static Color AverageColor(Bitmap source, int x, int y, int xStep, int yStep)
        {
            // Thanks to CoPilot for this
            int r = 0, g = 0, b = 0;
            int count = 0;

            for (int yd = -yStep / 2; yd <= yStep / 2; yd++)
            {
                for (int xd = -xStep / 2; xd <= xStep / 2; xd++)
                {
                    if (x + xd >= 0 && x + xd < source.Width && y + yd >= 0 && y + yd < source.Height)
                    {
                        var color = source.GetPixel(x + xd, y + yd);
                        r += color.R;
                        g += color.G;
                        b += color.B;
                        count++;
                    }
                }
            }

            return Color.FromArgb(r / count, g / count, b / count);
        }
    }
}
