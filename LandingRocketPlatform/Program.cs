using LandingRadar;
using static LandingRadar.RadarLandingCodes;


List<RocketPosition> rocketPositions = new List<RocketPosition>();
Console.WriteLine("Write the platform and landing dimension followed by the platform starting point, like the example '20;100;5;5' respectively: ");
LandingSizes landingSizes = new LandingSizes(Console.ReadLine().Split(';').Select(n => Convert.ToInt32(n)).ToArray());
bool eraseLandingPoints = false;

while (true)
{
    Console.WriteLine("Type the point, like the example '5;5', to verify landing");


    var landingCode = PlatformRadar.VerifySlotAvailability(ref rocketPositions, ref landingSizes, eraseLandingPoints, new RocketPosition(Console.ReadLine().Split(';').Select(n => Convert.ToInt32(n)).ToArray()));
    var radarLandingMatrix = PlatformRadar.CalculatePlatformMatrix(rocketPositions);

    PrintArea.ShowLandingSpace(radarLandingMatrix);
    PrintMessage(landingCode);

    Console.WriteLine("Press any key for next point or 'E' to erase data");
    var a = Console.ReadLine();

    if (a.ToString().ToUpper() == "E")
    {
        rocketPositions = new List<RocketPosition>();
        eraseLandingPoints = true;
    }
    else
        eraseLandingPoints = false;

    Console.Clear();
}



