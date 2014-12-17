using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RobotTest
{
    using CintRobot;

    using NUnit.Framework;

    [TestFixture]
    public class CintRobotTest
    {
        [Test]
        public void Cleaned_Spots_Unique_Count()
        {
            int commandCount = 2;
            int[] initialCoordinate = new[] { 0, 0 };
            List<Tuple<string, int>> directions = new List<Tuple<string, int>>
                                                      {
                                                          new Tuple<string, int>("E", 1),
                                                          new Tuple<string, int>("W", 1)
                                                      };
            
            Robot robot = new Robot(commandCount,initialCoordinate,directions);
            int cleanedSpots = robot.GetCleanedCount();
            Assert.AreEqual(2,cleanedSpots);
        }

        [Test]
        public void Cleaned_Spots_NoMove_Count()
        {
            int commandCount = 2;
            int[] initialCoordinate = new[] { 0, 0 };
            List<Tuple<string, int>> directions = new List<Tuple<string, int>>
                                                      {
                                                          new Tuple<string, int>("E", 0),
                                                          new Tuple<string, int>("W", 0)
                                                      };

            Robot robot = new Robot(commandCount, initialCoordinate, directions);
            int cleanedSpots = robot.GetCleanedCount();
            Assert.AreEqual(1, cleanedSpots);
        }

        [Test]
        public void Cleaned_Spots_OnXAxis_Count()
        {
            int commandCount = 3;
            int[] initialCoordinate = new[] { 0, 0 };
            List<Tuple<string, int>> directions = new List<Tuple<string, int>>
                                                      {
                                                          new Tuple<string, int>("E", 5),
                                                          new Tuple<string, int>("W", 10),
                                                          new Tuple<string, int>("E",5)
                                                      };

            Robot robot = new Robot(commandCount, initialCoordinate, directions);
            int cleanedSpots = robot.GetCleanedCount();
            Assert.AreEqual(11, cleanedSpots);
        }

        [Test]
        public void Cleaned_Spots_OnYAxis_Count()
        {
            int commandCount = 3;
            int[] initialCoordinate = new[] { 0, 0 };
            List<Tuple<string, int>> directions = new List<Tuple<string, int>>
                                                      {
                                                          new Tuple<string, int>("N", 5),
                                                          new Tuple<string, int>("S", 10),
                                                          new Tuple<string, int>("N",5)
                                                      };

            Robot robot = new Robot(commandCount, initialCoordinate, directions);
            int cleanedSpots = robot.GetCleanedCount();
            Assert.AreEqual(11, cleanedSpots);
        }

        [Test]
        public void Cleaned_Spots_Random_Count()
        {
            int commandCount = 4;
            int[] initialCoordinate = new[] { 0, 0 };
            List<Tuple<string, int>> directions = new List<Tuple<string, int>>
                                                      {
                                                          new Tuple<string, int>("E", 5),
                                                          new Tuple<string, int>("N",1),
                                                          new Tuple<string, int>("W", 10),
                                                          new Tuple<string, int>("S",5)
                                                      };

            Robot robot = new Robot(commandCount, initialCoordinate, directions);
            int cleanedSpots = robot.GetCleanedCount();
            Assert.AreEqual(22, cleanedSpots);
        }
    }
}
