using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Gym_App
{
    public class ShadowEffect : RoutingEffect
    {
        public Color ShadowColor { get; set; }
        public double ShadowRadius { get; set; }
        public Point Offset { get; set; }

        public ShadowEffect() : base("GymApp.ShadowEffect")
        {
        }
    }
}
