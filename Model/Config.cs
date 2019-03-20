using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Config
    {
        public static List<int> roomNum = new List<int>();
        public static List<double> spanTime = new List<double>();
        public static List<double> score = new List<double>();
        static Config()
        {
            roomNum.Add(40);
            roomNum.Add(120);
            roomNum.Add(500);
            roomNum.Add(3000);

            spanTime.Add(0.5);
            spanTime.Add(1);
            spanTime.Add(1.5);
            spanTime.Add(2);
            spanTime.Add(3);
            spanTime.Add(5);
            spanTime.Add(10);

            score.Add(0.1);
            score.Add(0.3);
            score.Add(0.5);
            score.Add(1);
            score.Add(1.5);
            score.Add(2);
        }
    }
}

