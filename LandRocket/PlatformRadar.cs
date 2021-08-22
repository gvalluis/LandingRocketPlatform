using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LandingRadar.RadarLandingCodes;

namespace LandingRadar
{
    public static class PlatformRadar
    {
        private static int[] platformMatrixDimension;
        private static int landingMatrixDimension;
        private static bool FirstExecution = true;

        public static int[,] LandingPlaformMatrix;
        public static List<RocketPosition> usedPlatformSpace = new List<RocketPosition>();

        public static int[,] CalculatePlatformMatrix(List<RocketPosition> rocketPositions)
        {

            foreach (var landingPoint in rocketPositions)
                AddUsedLandingSpaceToRadar(landingPoint);

                for (int x = 0; x < landingMatrixDimension; x++)

                    for (int y = 0; y < landingMatrixDimension; y++)

                        CategorizePoint(x, y);


            return LandingPlaformMatrix;
        }

        public static LandingCodes VerifySlotAvailability(ref List<RocketPosition> rocketPositionsRequest, ref LandingSizes landingSizes, bool erase, RocketPosition rocketPositionRequest)
        {
            if (FirstExecution || erase)
                SetParameters(landingSizes);

            var rocketAreaRequest = CalculateRocketUsedSpace(rocketPositionRequest);

            if (IsOutsidePlatform(rocketPositionRequest))
                return LandingCodes.OutOfPlatform;
            else if (SlotAreaAvailable(rocketAreaRequest))
            {
                rocketPositionsRequest.Add(rocketPositionRequest);
                return LandingCodes.OkToLand;
            }
            else
                return LandingCodes.Clash;
        }

        private static void SetParameters(LandingSizes landingSizes)
        {
            platformMatrixDimension = new[] { (landingSizes.PlatformXOrigin - 1), (landingSizes.PlatformXOrigin + landingSizes.PlatformAreaSide - 2) };
            landingMatrixDimension = landingSizes.LandingAreaSide;
            LandingPlaformMatrix = new int[landingMatrixDimension, landingMatrixDimension];
            usedPlatformSpace = new List<RocketPosition>();
            FirstExecution = false;
        }

        public static bool IsOutsidePlatform(RocketPosition rocketPositionRequest)
        {
            return rocketPositionRequest.PositionX < platformMatrixDimension[0] ||
                rocketPositionRequest.PositionX > platformMatrixDimension[1] ||
                rocketPositionRequest.PositionY < platformMatrixDimension[0] ||
                rocketPositionRequest.PositionY > platformMatrixDimension[1];
        }

        public static void AddUsedLandingSpaceToRadar(RocketPosition landingPoint)
        {
            if (SlotAreaAvailable(CalculateRocketUsedSpace(landingPoint)))
                usedPlatformSpace.AddRange(CalculateRocketUsedSpace(landingPoint));
        }

        public static List<RocketPosition> CalculateRocketUsedSpace(RocketPosition p)
        {
            List<RocketPosition> pointList = new List<RocketPosition>();
            for (int x = p.PositionX - 1; x <= p.PositionX + 1; x++)
                for (int y = p.PositionY - 1; y <= p.PositionY + 1; y++)
                    pointList.Add(new RocketPosition(x, y));

            return pointList;
        }

        public static void CategorizePoint(int x, int y)
        {
            RocketPosition rocketPosition = new RocketPosition(x, y);

            if (usedPlatformSpace.Any(pos => pos.PositionX == x && pos.PositionY == y))
                LandingPlaformMatrix[x, y] = 7;

            else if (InsidePlatformArea(x) && InsidePlatformArea(y) && SlotAvailable(x,y))
                LandingPlaformMatrix[x, y] = 0;

            else
                LandingPlaformMatrix[x, y] = 1;
        }

        public static bool InsidePlatformArea(int coordinate) => coordinate >= platformMatrixDimension[0] && coordinate <= platformMatrixDimension[1];

        public static bool SlotAvailable(int x, int y) => !usedPlatformSpace.Any(pos => pos.PositionX == x && pos.PositionY == y);

        public static bool SlotAreaAvailable(List<RocketPosition> rocketPositions) => !rocketPositions.Any(x => usedPlatformSpace.Any(xp => xp.PositionX == x.PositionX && xp.PositionY == x.PositionY));

    }
}
