using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CHIP_8_Emulator.Emulator
{
    class Display
    {
        public Canvas DisplayCanvas { get; set; }

        private const int horizontalSize = 64;
        private const int verticalSize = 32;
        private bool[,] screenPixels = new bool[horizontalSize, verticalSize];

        public Display(Canvas displayCanvas)
        {
            DisplayCanvas = displayCanvas;
        }

        public int SetPixel(int x, int y, int value)
        {
            int pixelWasTurnedOff = 0;
            if (value > 0)
            {
                if (screenPixels[x, y])
                {
                    screenPixels[x, y] = false;
                    pixelWasTurnedOff = 1;
                }
                else
                {
                    screenPixels[x, y] = true;
                }
            }

            return pixelWasTurnedOff;
        }

        public void ClearDisplay()
        {
            DisplayCanvas.Children.Clear();
        }

        public void RedrawDisplay()
        {
            ClearDisplay();

            for (int y = 0; y < verticalSize; y++) 
            {
                for (int x = 0; x < horizontalSize; x++)
                {                    
                    if (screenPixels[x,y])
                    {
                        Rectangle pixel = new Rectangle();

                        pixel.Stroke = new SolidColorBrush(Colors.Black);
                        pixel.Fill = new SolidColorBrush(Colors.Black);
                        pixel.Width = DisplayCanvas.Width / horizontalSize;
                        pixel.Height = DisplayCanvas.Height / verticalSize;

                        Canvas.SetLeft(pixel, (DisplayCanvas.Width / horizontalSize) * (x));
                        Canvas.SetTop(pixel, (DisplayCanvas.Height / verticalSize) * (y));

                        DisplayCanvas.Children.Add(pixel);                        
                    }                    
                }
            }

            DisplayCanvas.InvalidateVisual();
        }
    }
}
