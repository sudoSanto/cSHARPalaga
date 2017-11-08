using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading;
using System.Threading.Tasks;

namespace cSHARPalaga
{
    class Tasks
    {
        public Tasks() { }

        calagaControl tControl = new calagaControl();

        public void RunTasks()
        {
            var taskControl = new Task(MainLoop);
            var taskKeys = new Task(ReadKeys);

            taskControl.Start();
            taskKeys.Start();

            var tasks = new[] { taskKeys };
            Task.WaitAll(tasks);
        }//end RunTasks

        //Runs the Game through Tasks to allow asynchronous activity.
        public void MainLoop()
        {
            tControl.mainLoop();
        }//end MainLoop

        public void ReadKeys()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            while (tControl.KeyOn == 1)//(!Console.KeyAvailable)// && key.Key != ConsoleKey.Escape)
            {
                if (tControl.KeyLock == 0)
                {
                    key = Console.ReadKey(true);
                    if (tControl.DoKey == 0)
                    {
                        switch (key.Key)
                        {
                            case ConsoleKey.UpArrow:
                                tControl.DoKey = 1;
                                tControl.PMoveY = -1;
                                break;

                            case ConsoleKey.DownArrow:
                                tControl.DoKey = 1;
                                tControl.PMoveY = 1;
                                break;

                            case ConsoleKey.RightArrow:
                                tControl.DoKey = 1;
                                tControl.PMoveX = 2;
                                break;

                            case ConsoleKey.LeftArrow:
                                tControl.DoKey = 1;
                                tControl.PMoveX = -2;
                                break;

                            case ConsoleKey.Q:
                                tControl.DoKey = 2;
                                break;

                            case ConsoleKey.P:
                                tControl.DoKey = 3;
                                break;

                            case ConsoleKey.O:
                                tControl.DoKey = 4;
                                break;

                            case ConsoleKey.Escape:
                                break;

                            default:
                                //if (Console.CapsLock)
                                //{
                                //    Console.WriteLine(key.KeyChar);
                                //}
                                break;
                        }//case
                    }//tControl.DoKey
                }//KeyLock
            }//End of loop that watches keypress.
        }//end ReadKeys
    }//end Class
}//end Namespace
