namespace LandingRadar
{
    public class RocketPosition
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public RocketPosition(int pX, int pY)
        {
            PositionX = pX;
            PositionY = pY; 
        }

        public RocketPosition(int[] intArray)
        {
            PositionX = intArray[0];
            PositionY = intArray[1];
        }
    }
}
