using System;
using System.Collections.Generic;

namespace CintRobot
{
    public class Robot : IRobot
    {
        private int CommandCount { get; set; }

        private List<Tuple<string, int>> Directions { get; set; }

        private readonly HashSet<Tuple<int,int>>  UniqueCleanedSpots = new HashSet<Tuple<int, int>>();

        private readonly int[] NewSpot = new int[2];

        public Robot(int commandCount, int[] initialCoordinates, List<Tuple<string, int>> directions)
        {
            this.CommandCount = commandCount;
            this.Directions = directions;
            this.NewSpot = initialCoordinates;
            this.UniqueCleanedSpots.Add(new Tuple<int, int>(initialCoordinates[0], initialCoordinates[1]));
        }

        public int GetCleanedCount()
        {


            foreach (Tuple<string, int> direction in Directions)
            {
               
                    UniqeVisit(direction);
                
            }

            return this.UniqueCleanedSpots.Count;
        }


        private void UniqeVisit(Tuple<string, int> direction)
        {

            for (int i = 0; i < direction.Item2; i++)
            {

                int[] newPosition = new int[2];
                newPosition[0] = NewSpot[0];
                newPosition[1] = NewSpot[1];

                switch (direction.Item1)
                {
                    case "E":
                        newPosition[0]++;
                        break;
                    case "N":
                        newPosition[1]++;
                        break;
                    case "W":
                        newPosition[0]--;
                        break;
                    case "S":
                        newPosition[1]--;
                        break;
                }

                //update the values of new spot
                NewSpot[0] = newPosition[0];
                NewSpot[1] = newPosition[1];

                Tuple<int, int> spot = new Tuple<int, int>(newPosition[0], newPosition[1]);
                    if (!this.UniqueCleanedSpots.Contains(spot)) this.UniqueCleanedSpots.Add(spot);

            }
        }

    }

}
