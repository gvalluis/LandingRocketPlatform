using LandingRadar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace TestUnit;
[TestClass]
public class PlatformRadar
{

    [TestMethod]
    public void TestPlatformRadarMatrix()
    {
        [Fact]
        void MatrixIsSquare_InputIsMatrixLimit_ReturnFalse()
        {
            List<RocketPosition> rocketPositions = new List<RocketPosition> { new RocketPosition(5, 1), new RocketPosition(5, 5), new RocketPosition(10, 10) };

            var matrix = LandingRadar.PlatformRadar.CalculatePlatformMatrix(rocketPositions);
            bool result = matrix[(int)Math.Sqrt(matrix.Length), 0] == matrix[0, (int)Math.Sqrt(matrix.Length)];
            Assert.IsFalse(result, "The matrix must be square");
        }
    }

    [TestMethod]
    public void TestPlatformRadarUsedSpace()
    {
        [Fact]
        void UsedSpaceIs9_InputAnyPoint_ReturnFalse()
        {
            var usedSpace = LandingRadar.PlatformRadar.CalculateRocketUsedSpace(new RocketPosition(5, 5));
            bool result = usedSpace.Count == 9;
            Assert.IsFalse(result, "The used space for landing must be 9");
        }
    }



}