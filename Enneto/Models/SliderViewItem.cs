using System;
using System.Collections.Generic;
using System.Text;

namespace Enneto.Models
{
    public class SliderViewItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int Step { get; set; }
        public Xamarin.Forms.Color BackgroundColor { get; set; }
    }
}
