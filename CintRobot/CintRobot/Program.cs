using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CintRobot
{
    class Program
    {
        public class Robotics
        {
            private readonly IRobot _robot;

            public Robotics(IRobot robot)
            {
                _robot = robot;
            }

            public int CountCleanedSpots()
            {
               return _robot.GetCleanedCount();
            }
        }

        static void Main(string[] args)
        {
           // Console.WriteLine("Please insert the number of instructions:");
            
            int instructionsCount = Convert.ToInt32(Console.ReadLine());

           // Console.WriteLine("Please insert the starting coordinates");
            string[] coordinates = Console.ReadLine().Split(' ');

            int x;
            int.TryParse(coordinates[0], out x);

            int y;
            int.TryParse(coordinates[1], out y);

            int[] coordinate = new[] { x, y };


           // Console.WriteLine("Please insert the Direction and Steps:");

            List<Tuple<string,int>> directionList = new List<Tuple<string, int>>();

            int counter = 0;
            while (counter < instructionsCount)
            {
                
                var direction = Console.ReadLine().Split(' ');
                string compassDirection = direction[0];
                int steps = Convert.ToInt32(direction[1]);
                directionList.Add(new Tuple<string, int>(compassDirection, steps));
                counter++;
            }

            Robot cintRobot = new Robot(coordinate,directionList);

            Robotics robotics = new Robotics(cintRobot);

            int cleanedCount = robotics.CountCleanedSpots();

            Console.WriteLine("=> Cleaned: {0}",cleanedCount);

            Console.Read();
        }
    }
}
