using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class Clock
    {
        private int Sec;
        private int Min;
        private int Hr;

        public int Second
        {
            get
            {
                return Sec;
            }
            set
            {
                if(value >= 0 && value <= 60)
                {
                    Sec = value;
                }
                else
                {
                    Console.WriteLine("Invalid value. setting default value");
                }
            }
        }
        public int Hour
        {
            get
            {
                return Hr;
            }
            set
            {
                if(value >= 0 && value <= 24)
                {
                    Hr = value;
                }
                else
                {
                    Console.WriteLine("Invalid value. setting default value");
                }
            }
        }
        public int Minute
        {
            get
            {
                return Min;
            }
            set
            {
                if(value >= 0 && value < 60)
                {
                    Min = value;
                }
                else
                {
                    Console.WriteLine("Invalid value. setting default value");
                }
            }
        }
        






        public void AddMinute()
        {
            if(Min == 59)
            {
                Min = 0;
                AddHour();
            }
            else
            {
                Min++;
            }
        }
        public void AddHour()
        {
            if(Hr == 23)
            {
                Hr = 0;
            }
            else
            {
                Hr++;
            }
        }
        public void AddSecond()
        {
            if(Sec == 59)
            {
                Sec = 0;
                AddMinute();
            }
            else
            {
                Sec++;
            }
        }
        public void getCurrentTime()
        {
            string Hours = string.Empty;
            string Minutes = string.Empty;
            string Seconds = string.Empty;
            if(Hr < 10)
            {
                Hours = "0" + Hr;
            }
            else
            {
                Hours = Convert.ToString(Hr);
            }

            if(Min < 10)
            {
                Minutes = "0" + Min;
            }
            else
            {
                Minutes = Convert.ToString(Min);
            }

            if(Sec < 10)
            {
                Seconds = "0" + Sec;
            }
            else
            {
                Seconds= Convert.ToString(Sec);
            }

            Console.WriteLine($"{Hours}:{Minutes}:{Seconds}");
        }
    }
}
