using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSHARPalaga
{
    class calagaView
    {
        public calagaView() { }

        public void drawPlayer(int x, int y)
        {
            Console.SetCursorPosition(x - 2, y - 1);
            Console.Write("  ^  ");
            Console.SetCursorPosition(x - 2, y);
            Console.Write("\\_U_/");
            Console.SetCursorPosition(x - 2, y + 1);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(" ' ' ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
        }

        public void clearPlayer(int x, int y)
        {
            Console.SetCursorPosition(x - 2, y - 1);
            Console.Write("     ");
            Console.SetCursorPosition(x - 2, y);
            Console.Write("     ");
            Console.SetCursorPosition(x - 2, y + 1);
            Console.Write("     ");
            Console.SetCursorPosition(0, 0);
        }

        public void drawEnemy(int x, int y)
        {
            Console.SetCursorPosition(x - 2, y - 1);
            Console.Write("/   \\");
            Console.SetCursorPosition(x - 2, y);
            Console.Write("|-o-|");
            Console.SetCursorPosition(x - 2, y + 1);
            Console.Write("\\   /");  
            Console.SetCursorPosition(0, 0);
        }

        public void clearEnemy(int x, int y)
        {
            Console.SetCursorPosition(x - 2, y - 1);
            Console.Write("     ");
            Console.SetCursorPosition(x - 2, y);
            Console.Write("     ");
            Console.SetCursorPosition(x - 2, y + 1);
            Console.Write("     ");
            Console.SetCursorPosition(0, 0);
        }

        public void drawBoom(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x - 2, y - 1);
            Console.Write("\\ | /");
            Console.SetCursorPosition(x - 2, y);
            Console.Write("- o -");
            Console.SetCursorPosition(x - 2, y + 1);
            Console.Write("/ | \\");
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public void drawProj(int x, int y, int color)
        {
            switch (color)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.SetCursorPosition(x, y);
            Console.Write("+");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
        }

        public void clearProj(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            Console.SetCursorPosition(0, 0);
        }

        public void drawColScore(int p, int e)
        {
            Console.SetCursorPosition(10, 0);
            Console.Write("Player Collisions: " + p + "  Enemy Collisions: " + e);
        }

    }
}
