using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandingRadar
{
    public class LandingSizes
    {
        public int PlatformAreaSide { get; set; }
        public int LandingAreaSide { get; set; }
        public int PlatformXOrigin { get; set; }
        public int PlatformYOrigin { get; set; }

        public LandingSizes(int pX, int pY)
        {
            PlatformXOrigin = pX;
            PlatformYOrigin = pY;
        }
        public LandingSizes()
        {

        }

        public LandingSizes(int[] intArray)
        {
            PlatformAreaSide = intArray[0];
            LandingAreaSide = intArray[1];
            PlatformXOrigin = intArray[2];
            PlatformYOrigin = intArray[3];
        }
    }
}
