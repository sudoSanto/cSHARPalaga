using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSHARPalaga
{
    class calagaModel
    {
        public calagaModel() { }

        Random rnd = new Random();
        DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        //Loop Init
        private int runOn = 1;
        public int RunOn { get { return runOn; } set { runOn = value; } }
        private int keyDelay = 1;
        public int KeyDelay { get{ return keyDelay; } set { keyDelay = value; } }
        private int tempInt = 0;
        public int TempInt { get { return tempInt; } set { tempInt = value; } }


        //Array Sizes
        //-max player projectiles
        private static int maxPProj = 20;
        public int MaxPProj { get { return maxPProj; } set { maxPProj = value; } }
        //-max enemy projectiles
        private static int maxEProj = 200;
        public int MaxEProj { get { return maxEProj; } set { maxEProj = value; } }
        //-max enemies
        private static int maxE = 50;
        public int MaxE { get { return maxE; } set { maxE = value; } }

        //XY Coords
        //-player
        private int pX = 20;
        public int PX { get { return pX; } set { pX = value; } }
        private int pY = 20;
        public int PY { get { return pY; } set { pY = value; } }

        private int prevPX = 0;
        public int PrevPX { get { return prevPX; } set { prevPX = value; } }
        private int prevPY = 0;
        public int PrevPY { get { return prevPY; } set { prevPY = value; } }
        //-enemny
        private int[] eX = new int[maxE];
        public int[] EX { get { return eX; } set { eX = value; } }
        private int[] eY = new int[maxE];
        public int[] EY { get { return eY; } set { eY = value; } }
        //-player projectile
        private int[] projPX = new int[maxPProj];
        public int[] ProjPX { get { return projPX; } set { projPX = value; } }
        private int[] projPY = new int[maxPProj];
        public int[] ProjPY { get { return projPY; } set { projPY = value; } }
        //-enemy projectile
        private int[] projEX = new int[maxEProj];
        public int[] ProjEX { get { return projEX; } set { projEX = value; } }
        private int[] projEY = new int[maxEProj];
        public int[] ProjEY { get { return projEY; } set { projEY = value; } }
        private int[] projTarEX = new int[maxEProj];
        public int[] ProjTarEX { get { return projTarEX; } set { projTarEX = value; } }


        //Actors
        //-player projectile
        private int[] projP = new int[maxPProj];
        public int[] ProjP { get { return projP; } set { projP = value; } }

        //private int[] projPInit = new int[maxPProj];
        //public int[] ProjPInit { get { return projPInit; } set { projPInit = value; } }

        private int[] projPMove = new int[maxPProj];
        public int[] ProjPMove { get { return projPMove; } set { projPMove = value; } }
        //-enemy
        private int[] enemy = new int[maxE];
        public int[] Enemy { get { return enemy; } set { enemy = value; } }

        //private int[] eInit = new int[maxE];
        //public int[] EInit { get { return eInit; } set { eInit = value; } }

        private int[] eMove = new int[maxE];
        public int[] EMove { get { return eMove; } set { eMove = value; } }
        private int[] eMoveDirX = new int[maxE];
        public int[] EMoveDirX { get { return eMoveDirX; } set { eMoveDirX = value; } }
        private int[] eMoveDirY = new int[maxE];
        public int[] EMoveDirY { get { return eMoveDirY; } set { eMoveDirY = value; } }
        private int[] eMoveDur = new int[maxE];
        public int[] EMoveDur { get { return eMoveDur; } set { eMoveDur = value; } }

        //-enemy projectile
        private int[] projE = new int[maxEProj];
        public int[] ProjE { get { return projE; } set { projE = value; } }

        //private int[] projEInit = new int[maxEProj];
        //public int[] ProjEInit { get { return projEInit; } set { projEInit = value; } }

        private int[] projEMove = new int[maxEProj];
        public int[] ProjEMove { get { return projEMove; } set { projEMove = value; } }

        //Actor Collision
        private int[] eCol = new int[maxE];
        public int[] ECol { get { return eCol; } set { eCol = value; } }
        private int pCol = 0;
        public int PCol { get { return pCol; } set { pCol = value; } }


        //Actor Limits
        //-max player projectiles
        private int curMaxPProj = maxPProj;
        public int CurMaxPProj { get { return curMaxPProj; } set { curMaxPProj = value; } }
        //-max enemy projectiles
        private int curMaxEProj = maxEProj;
        public int CurMaxEProj { get { return curMaxEProj; } set { curMaxEProj = value; } }
        //-max enemies
        private int curMaxE = maxE;
        public int CurMaxE { get { return CurMaxE; } set { CurMaxE = value; } }

        //Counters
        private int eColCount = 0;
        public int EColCount { get { return eColCount; } set { eColCount = value; } }
        private int pColCount = 0;
        public int PColCount { get { return pColCount; } set { pColCount = value; } }

        //Timers & Limiters
        //-keyboard listener limiter
        private double keyTimer = 0;
        public double KeyTimer { get { return keyTimer; } set { keyTimer = value; } }
        //-player move
        private double pMoveTimer = 0;
        public double PMoveTimer { get { return pMoveTimer; } set { pMoveTimer = value; } }
        private int pMoveSpeed = 1;
        public int PMoveSpeed { get { return pMoveSpeed; } set { pMoveSpeed = value; } }
        //-player shoot
        private double pShootTimer = 0;
        public double PShootTimer { get { return pShootTimer; } set { pShootTimer = value; } }
        private int pShootSpeed = 50;
        public int PShootSpeed { get { return pShootSpeed; } set { pShootSpeed = value; } }
        //-player projectiles
        private double[] pProjTimer = new double[maxPProj];
        public double[] PProjTimer { get { return pProjTimer; } set { pProjTimer = value; } }
        private int[] pProjSpeed = new int[maxPProj];
        public int[] PProjSpeed { get { return pProjSpeed; } set { pProjSpeed = value; } }
        private int pCurProjSpeed = 50;
        public int PCurProjSpeed { get { return pCurProjSpeed; } set { pCurProjSpeed = value; } }
        //-enemy move
        private double[] eMoveTimer = new double[maxE];
        public double[] EMoveTimer { get { return eMoveTimer; } set { eMoveTimer = value; } }
        private int[] eMoveSpeed = new int[maxE];
        public int[] EMoveSpeed { get { return eMoveSpeed; } set { eMoveSpeed = value; } }
        private int eCurMoveSpeed = 50;
        public int ECurMoveSpeed { get { return eCurMoveSpeed; } set { eCurMoveSpeed = value; } }
        //-enemy shoot
        private double[] eShootTimer = new double[maxE];
        public double[] EShootTimer { get { return eShootTimer; } set { eShootTimer = value; } }
        private int[] eShootSpeed = new int[maxE];
        public int[] EShootSpeed { get { return eShootSpeed; } set { eShootSpeed = value; } }
        private int eCurShootSpeed = 1000;
        public int ECurShootSpeed { get { return eCurShootSpeed; } set { eCurShootSpeed = value; } }
        //-enemy spawn
        private double eSpawnTimer = 0;
        public double ESpawnTimer { get { return eSpawnTimer; } set { eSpawnTimer = value; } }
        private int eSpawnSpeed = 50;
        public int ESpawnSpeed { get { return eSpawnSpeed; } set { eSpawnSpeed = value; } }
        //-enemy projectiles
        private double[] eProjTimer = new double[maxEProj];
        public double[] EProjTimer { get { return eProjTimer; } set { eProjTimer = value; } }
        private int[] eProjSpeed = new int[maxEProj];
        public int[] EProjSpeed { get { return eProjSpeed; } set { eProjSpeed = value; } }
        private int eCurProjSpeed = 30;
        public int ECurProjSpeed { get { return eCurProjSpeed; } set { eCurProjSpeed = value; } }


        public void test()
        {
        }

        public void test2()
        {
        }

        public void setKeyLockTimer()
        {
            KeyTimer = (DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
        }

        public Boolean checkBorder(int x, int y)
        {
            if (x >= Console.WindowWidth) { return true; }
            if (y >= Console.WindowHeight) { return true; }
            return false;
        }

        public void playerMove(int x, int y)
        {
            PrevPX = PX;
            PrevPY = PY;
            PX = PX + x;
            PY = PY + y;
            PMoveTimer = (DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
        }

        public int playerShoot()
        {
            for (int i = 0; i < ProjP.Length; i++)
            {
                if (ProjP[i] == 0 && i < CurMaxPProj)
                {
                    ProjP[i] = 1;
                    //ProjPInit[i] = 1;
                    ProjPMove[i] = 0;
                    ProjPX[i] = PX;
                    ProjPY[i] = PY - 2;
                    PProjSpeed[i] = PCurProjSpeed;
                    PProjTimer[i] = (DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
                    PShootTimer = (DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
                    return i;
                }
            }
            return -1;
        }

        public void playerProjectiles(int i)
        {
            //for (int i = 0; i < ProjP.Length; i++)
            //{
                //if (ProjP[i] == 1 && timerCheck(PProjTimer[i], PProjSpeed[i]))
                //{
                   // ProjPMove[i] = 1;
                    PProjTimer[i] = (DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
                //}
            //}
        }

        public void enemyMove()
        {
            for (int i = 0; i < Enemy.Length; i++)
            {
                if (Enemy[i] == 1 && timerCheck(EMoveTimer[i], EMoveSpeed[i]))
                {
                    EMove[i] = 1;
                    EMoveTimer[i] = (DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
                }
            }
        }

        public void enemyMoveDir(int i)
        {
            TempInt = checkEonECollision(i);
            if (TempInt > -1) {ECol[TempInt] = 1; }
            TempInt = checkPonECollision();
            if (TempInt > -1) { ECol[TempInt] = 1; PCol = 1; }
            if (EMoveDur[i] <= 0)
            {
                EMoveDirX[i] = (rnd.Next(1, 4) - 2)*2;
                EMoveDirY[i] = rnd.Next(1, 4) - 2;
                EMoveDur[i] = rnd.Next(1, 101);
                EMoveSpeed[i] = rnd.Next(10, 500);
            }
            EX[i] = EX[i] + EMoveDirX[i];
            EY[i] = EY[i] + EMoveDirY[i];
            EMoveDur[i] = EMoveDur[i] - 1;
            EMoveTimer[i] = (DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
            if (EX[i] >= (Console.WindowWidth - 2))
            {
                EX[i] = EX[i] - EMoveDirX[i];
                EMoveDirX[i] = EMoveDirX[i] * -1;
                //EX[i] = 3;
            }
            if (EY[i] >= (Console.WindowHeight - 10))
            {
                EY[i] = EY[i] - EMoveDirY[i];
                EMoveDirY[i] = EMoveDirY[i] * -1;
                //EY[i] = 3;
            }
            if (EX[i] <= 1)
            {
                EX[i] = EX[i] - EMoveDirX[i];
                EMoveDirX[i] = EMoveDirX[i] * -1;
                //EX[i] = Console.WindowWidth - 5;
            }
            if (EY[i] <= 1)
            {
                EY[i] = EY[i] - EMoveDirY[i];
                EMoveDirY[i] = EMoveDirY[i] * -1;
                //EY[i] = Console.WindowHeight - 12;
            }
        }

        public void enemyShoot(int enemyIndex)
        {
            for (int i = 0; i < ProjE.Length; i++)
            {
                if (Enemy[enemyIndex] == 1 && ProjE[i] == 0 && i < CurMaxEProj)
                {
                    ProjE[i] = 1;
                    //ProjEInit[i] = 1;
                    ProjTarEX[i] = PX;
                    ProjEMove[i] = 0;
                    ProjEX[i] = EX[enemyIndex];
                    ProjEY[i] = EY[enemyIndex] + 1;
                    ECurShootSpeed = rnd.Next(30, 500);
                    EShootSpeed[enemyIndex] = ECurShootSpeed;
                    EProjSpeed[i] = ECurProjSpeed;
                    EProjTimer[i] = (DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
                    EShootTimer[enemyIndex] = (DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
                    break;
                }
            }
        }

        public void enemyProjHoming(int i)
        {
            if (rnd.Next(1, 101) > 50)
            {
                if (ProjEX[i] > ProjTarEX[i] && ProjEY[i] < PY) { ProjEX[i] = ProjEX[i] - 1; }
                if (ProjEX[i] < ProjTarEX[i] && ProjEY[i] < PY) { ProjEX[i] = ProjEX[i] + 1; }
                //if (ProjEY[i] > PY) { ProjEY[i] = ProjEY[i] - 1; }
                //if (ProjEY[i] < PY) { ProjEY[i] = ProjEY[i] + 1; }
            }
            ProjEY[i] = ProjEY[i] + 1;
        }

        public void enemyProjectiles(int i)
        {
            //for (int i = 0; i < ProjE.Length; i++)
            //{
                //if (ProjE[i] == 1 && timerCheck(EProjTimer[i], EProjSpeed[i]))
                //{
                    //ProjEMove[i] = 1;
                    EProjTimer[i] = (DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
                //}
            //}
        }

        public void enemySpawn(int i)
        {
            //for (int i = 0; i < Enemy.Length; i++)
            //{
            if (Enemy[i] == 0 && timerCheck(ESpawnTimer, ESpawnSpeed))
            {
                Enemy[i] = 1;
                //EInit[i] = 1;
                //ECurShootSpeed = rnd.Next(50, 1000);
                EMoveSpeed[i] = ECurMoveSpeed;
                EShootSpeed[i] = rnd.Next(50, 1000);
                do
                {
                    EX[i] = (rnd.Next(5, (Console.WindowWidth - 5)));
                    EY[i] = (rnd.Next(2, (Console.WindowHeight - 10)));
                }
                while (checkEonECollision(i) < -1  || checkPonECollision() < -1);
                EMoveTimer[i] = ((DateTime.UtcNow - UnixEpoch).TotalMilliseconds + (EMoveSpeed[i] + 1));
                EShootTimer[i] = (DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
                ESpawnTimer = (DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
                //break;
            }
            //}
        }

        public void pWBomb()
        {
            for (int i = 0; i < Enemy.Length; i++)
            {
                Enemy[i] = 0;
            }
        }

        public Boolean checkPCollision(int x, int y)
        {
            if (hitBox(PX, PY, x, y, 5, 3))
            {
                return true;
            }
            return false;
        }
           
        //exclude & return: -1 is nobody
        public int checkECollision(int x, int y, int exclude)
        {
            for (int i = 0; i < Enemy.Length; i++)
            {
                if (i != exclude && Enemy[i] == 1 && hitBox(EX[i], EY[i], x, y, 5, 3))
                {
                    return i;
                }
            }
            return -1;
        }

        public int checkEonECollision(int i)
        {
            int xCount = -2;
            int yCount = -1;
//            for (int enemyIndex = 0; enemyIndex < Enemy.Length; enemyIndex++)
//            {
//                if (Enemy[enemyIndex] == 1 && enemyIndex != i)
//                {
                    while (xCount < 3)
                    {
                        while (yCount < 2)
                        {
                            TempInt = checkECollision((EX[i] + xCount), EY[i] + yCount, i);
                            if (TempInt > -1) { return TempInt; }
                            //if (TempInt > -1) { ECol[TempInt] = 1; }
                            yCount++;
                        }
                        yCount = -1;
                        xCount++;
                    }
//                }
//            }
            return -1;
        }

        public int checkPonECollision()
        {
            int xCount = -2;
            int yCount = -1;
            for (int i = 0; i < Enemy.Length; i++)
            {
                if (Enemy[i] == 1)
                {
                    while (xCount < 3)
                    {
                        while (yCount < 2)
                        {
                            TempInt = checkECollision((PX + xCount), PY + yCount, -1);
                            if (TempInt > -1) { return TempInt; }
                            yCount++;
                        }
                        yCount = -1;
                        xCount++;
                    }

                }
            }
            return -1;
        }

        public Boolean hitBox(int x, int y, int projX, int projY, int hitX, int hitY)
        {
            int xCount = -1 * ((hitX - 1) / 2);
            int yCount = -1 * ((hitY - 1) / 2);
            while (xCount < ((hitX - 1) / 2) + 1)
            {
                while (yCount < ((hitY - 1) / 2) + 1)
                {
                    if (x + xCount == projX && y + yCount == projY)
                    {
                        return true;
                    }
                    yCount++;
                }
                yCount = -1 * ((hitY - 1) / 2);
                xCount++;
            }
            return false;
        }

        public Boolean timerCheck(double timer, int speed)
        {
            if ((((DateTime.UtcNow - UnixEpoch).TotalMilliseconds) - timer) > speed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
