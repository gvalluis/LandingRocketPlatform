using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandingRadar
{
    public class RadarLandingCodes
    {
        public static void PrintMessage(LandingCodes landingCodes)
        {
            switch (landingCodes)
            {
                case LandingCodes.OkToLand:
                    FormatMessage("Ok for landing");
                    break;
                case LandingCodes.OutOfPlatform:
                    FormatMessage("Out of platform");
                    break;
                case LandingCodes.Clash:
                    FormatMessage("Clash");
                    break;
                default:
                    break;
            }
        }

        private static void FormatMessage(string message)
        {
            Console.WriteLine("_____________________________________________");
            Console.WriteLine($"##### {message} #####");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine();
        }

        public enum LandingCodes
        {
            OkToLand = 0,
            OutOfPlatform = 1,
            Clash = 2
        }
    }
}
