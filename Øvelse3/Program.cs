using System;
using System.Threading;

namespace Øvelse3
{
    class Program
    {

        static Thread t1 = new Thread(CheckTemp);
        static Thread t2 = new Thread(CheckThread);

        static int warningNumber = 0;

        static void Main(string[] args)
        {

            t1.Name = "[Thread1]";
            t1.Start();

            t2.Name = "[Thread2]";
            t2.Start();


        }

        static void CheckTemp()
        {
            bool tempOff = false;
            while (tempOff == false)
            {
                Random rnd = new Random();
                int temp = rnd.Next(-20, 121);

                if(temp > 100 || temp < 0)
                {
                    warningNumber++;
                }

                if(warningNumber >= 3)
                {
                    tempOff = true;
                }

                Console.WriteLine("{0} Temp is " + temp, Thread.CurrentThread.Name);


                if (warningNumber < 3)
                {
                    Thread.CurrentThread.Join(2000);
                }
            }
        }

        static void CheckThread()
        {
            while (t1.IsAlive)
            {
                Thread.CurrentThread.Join(10000);
                if(t1.IsAlive)
                Console.WriteLine("{0} Thread1 is still going... and is currently at " + warningNumber +" warnings", Thread.CurrentThread.Name);
            }
            if(t1.IsAlive == false)
            {
                Console.WriteLine("{0} Thread1 has been terminated, Thread2 will now stop", Thread.CurrentThread.Name);
            }
        }
    }
}