using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Simulator
{
    public class Building
    {
        public Position position { get; private set; }
        public int width { get; private set; }
        public int height { get; private set; }
        public Image Texture { get; private set; }

        public Building(Position position, int width, int height)
        {
            this.position = position;
            this.width = width;
            this.height = height;

            this.Texture.Width = width;
            this.Texture.Height = height;

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("smiley_stackpanel.PNG", UriKind.Relative);
            bi.EndInit();

            this.Texture.Source = bi;
        }
    }
}
