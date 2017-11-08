using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cSHARPalaga
{
    class calagaControl
    {
        public calagaControl() { }

        calagaModel cModel = new calagaModel();
        calagaView cView = new calagaView();
        calagaSound cSound = new calagaSound();

        private int keyOn = 1;
        public int KeyOn { get { return keyOn; } set { keyOn = value; } }
        private int doKey = 0;
        public int DoKey { get { return doKey; } set { doKey = value; } }
        private int keyLock = 0;
        public int KeyLock { get { return keyLock; } set { keyLock = value; } }
        private int pMoveX = 0;
        public int PMoveX { get { return pMoveX; } set { pMoveX = value; } }
        private int pMoveY = 0;
        public int PMoveY { get { return pMoveY; } set { pMoveY = value; } }

        public void mainLoop()
        {

            cView.drawPlayer(cModel.PX, cModel.PY);

            while (cModel.RunOn == 1)
            {
                if (cModel.timerCheck(cModel.KeyTimer, cModel.KeyDelay)) { KeyLock = 0; }
                if (DoKey > 0 && KeyLock == 0)
                {
                    if (DoKey == 1 && cModel.timerCheck(cModel.PMoveTimer, cModel.PMoveSpeed))
                    {
                        if (cModel.checkBorder(cModel.PX + 4, cModel.PY))
                        {
                            PMoveX = -2;
                            PMoveY = 0;
                        }
                        if (cModel.checkBorder(cModel.PX, cModel.PY + 2))
                        {
                            PMoveX = 0;
                            PMoveY = -1;
                        }
                        if (cModel.PX == 2)
                        {
                            PMoveX = 2;
                            PMoveY = 0;
                        }
                        if (cModel.PY == 2)
                        {
                            PMoveX = 0;
                            PMoveY = 1;
                        }
                        cModel.TempInt = cModel.checkPonECollision();
                        if (cModel.TempInt > -1)
                        {
                            cModel.ECol[cModel.TempInt] = 1;
                            cModel.PCol = 1;
                        }
                        cModel.playerMove(PMoveX, PMoveY);
                        cView.clearPlayer(cModel.PrevPX, cModel.PrevPY);
                        cView.drawPlayer(cModel.PX, cModel.PY);
                        PMoveX = 0;
                        PMoveY = 0;
                    }
                    if (DoKey == 2 && cModel.timerCheck(cModel.PShootTimer, cModel.PShootSpeed))
                    {
                        cModel.TempInt = cModel.playerShoot();
                        cView.drawProj(cModel.ProjPX[cModel.TempInt], cModel.ProjPY[cModel.TempInt], 1);
                        cSound.PlaySound(1);
                    }
                    if (DoKey == 3)
                    {
                        for (int i = 0; i < cModel.Enemy.Length; i++)
                        {
                            if (cModel.Enemy[i] == 1) { cView.clearEnemy(cModel.EX[i], cModel.EY[i]); }
                        }
                        cModel.pWBomb();
                        cSound.PlaySound(4);

                        //cModel.ECurMoveSpeed = cModel.ECurMoveSpeed - 10;
                        //cModel.EMoveSpeed[0] = cModel.ECurMoveSpeed;
                        //cModel.test();
                    }
                    if (DoKey == 4)
                    {
                        //cModel.ECurMoveSpeed = cModel.ECurMoveSpeed + 10;
                        //cModel.EMoveSpeed[0] = cModel.ECurMoveSpeed;
                        //cModel.test2();
                    }
                    cModel.setKeyLockTimer();
                    KeyLock = 1;
                    DoKey = 0;
                }//end Key Listener Do

                //Init Actors
                //for (int i = 0; i < cModel.ProjPInit.Length; i++)
                //{
                    //if (cModel.ProjP[i] == 1 && cModel.ProjPInit[i] == 1)
                    //{
                        //cView.drawProj(cModel.ProjPX[i], cModel.ProjPY[i], 1);
                        //cModel.ProjPInit[i] = 0;
                    //}
                //}
                //for (int i = 0; i < cModel.ProjEInit.Length; i++)
                //{
                    //if (cModel.ProjE[i] == 1 && cModel.ProjEInit[i] == 1)
                    //{
                        //cView.drawProj(cModel.ProjEX[i], cModel.ProjEY[i], 2);
                        //cModel.ProjEInit[i] = 0;
                    //}
                //}
                //for (int i = 0; i < cModel.EInit.Length; i++)
                //{
                    //if (cModel.Enemy[i] == 1 && cModel.EInit[i] == 1)
                    //{
                        //cView.drawEnemy(cModel.EX[i], cModel.EY[i]);
                        //cModel.EInit[i] = 0;
                    //}
                //}
                
                //Player Projectile Loop
                //Player Projectile Movement
                //cModel.playerProjectiles();
                for (int i = 0; i < cModel.ProjP.Length; i++)
                {
                    if (cModel.ProjP[i] == 1 && cModel.timerCheck(cModel.PProjTimer[i], cModel.PProjSpeed[i]))
                    {
                        cModel.TempInt = cModel.checkECollision(cModel.ProjPX[i], cModel.ProjPY[i], -1);
                        if (cModel.ProjPY[i] < 2)
                        {
                            cModel.ProjP[i] = 0;
                            cView.clearProj(cModel.ProjPX[i], cModel.ProjPY[i]);
                        }
                        else if (cModel.TempInt > -1)
                        {
                            cModel.ECol[cModel.TempInt] = 1;
                            cModel.ProjP[i] = 0;
                            cView.clearProj(cModel.ProjPX[i], cModel.ProjPY[i]);
                        }
                        else
                        {
                            cView.clearProj(cModel.ProjPX[i], cModel.ProjPY[i]);
                            cModel.ProjPY[i] = cModel.ProjPY[i] - 1;
                            cView.drawProj(cModel.ProjPX[i], cModel.ProjPY[i], 1);
                            cModel.playerProjectiles(i);
                            //cModel.ProjPMove[i] = 0;
                        }
                    }
                }

                //Enemy Loop
                //Enemy Collision
                for (int i = 0; i < cModel.ECol.Length; i++)
                {
                    cModel.enemySpawn(i);
                    //Enemy Move
                    if (cModel.Enemy[i] == 1 && cModel.timerCheck(cModel.EMoveTimer[i], cModel.EMoveSpeed[i]))//cModel.EMove[i] == 1)
                    {
                        cView.clearEnemy(cModel.EX[i], cModel.EY[i]);
                        cModel.enemyMoveDir(i);
                        cView.drawEnemy(cModel.EX[i], cModel.EY[i]);
                        //cModel.EMove[i] = 0;
                    }
                    //Enemy Shoot
                    if (cModel.Enemy[i] == 1 && cModel.timerCheck(cModel.EShootTimer[i], cModel.EShootSpeed[i]))
                    {
                        cModel.enemyShoot(i);
                        cSound.PlaySound(2);
                    }
                    //Enemy Collision
                    if (cModel.ECol[i] == 1)
                    {
                        cSound.PlaySound(4);
                        cView.clearEnemy(cModel.EX[i], cModel.EY[i]);
                        cView.drawPlayer(cModel.PX, cModel.PY);
                        cModel.ECol[i] = 0;
                        cModel.Enemy[i] = 0;
                        cModel.EColCount++;
                        cView.drawColScore(cModel.PColCount, cModel.EColCount);
                        //cView.drawBoom(cModel.EX[i], cModel.EY[i]);
                        //Redraw Actors
                        for (int i2 = 0; i2 < cModel.Enemy.Length; i2++)
                        {
                            if (cModel.Enemy[i2] == 1)
                            {
                                cView.drawEnemy(cModel.EX[i2], cModel.EY[i2]);
                                //cModel.EInit[i2] = 0;
                            }
                        }
                        //if (cModel.ESpawnSpeed > 200) { cModel.ESpawnSpeed = cModel.ESpawnSpeed - 10; }
                    }
                }

                //Enemy Loop
                //Enemy Movement
                //cModel.enemyMove();
                //for (int i = 0; i < cModel.Enemy.Length; i++)
                //{
                    //if (cModel.Enemy[i] == 1 && cModel.timerCheck(cModel.EMoveTimer[i], cModel.EMoveSpeed[i]))//cModel.EMove[i] == 1)
                    //{
                        //cView.clearEnemy(cModel.EX[i], cModel.EY[i]);
                        //cModel.enemyMoveDir(i);
                        //cView.drawEnemy(cModel.EX[i], cModel.EY[i]);
                        //cModel.EMove[i] = 0;
                    //}
                //}
                
                //Enemy Loop
                //Enemy Shoot
                //for (int i = 0; i < cModel.Enemy.Length; i++)
                //{
                    //if (cModel.Enemy[i] == 1 && cModel.timerCheck(cModel.EShootTimer[i], cModel.EShootSpeed[i]))
                    //{
                        //cModel.enemyShoot(i);
                        //cSound.PlaySound(2);
                    //}
                //}

                //Enemy Projectile Loop
                //Enemy Projectile Movement
                for (int i = 0; i < cModel.ProjE.Length; i++)
                {
                    if (cModel.ProjE[i] == 1 && cModel.timerCheck(cModel.EProjTimer[i], cModel.EProjSpeed[i]))
                    {
                        if (cModel.checkBorder(cModel.ProjEX[i], cModel.ProjEY[i] + 2))
                        {
                            cModel.ProjE[i] = 0;
                            cView.clearProj(cModel.ProjEX[i], cModel.ProjEY[i]);
                        }
                        else if (cModel.checkPCollision(cModel.ProjEX[i], cModel.ProjEY[i]))
                        {
                            cModel.PCol = 1;
                            cModel.ProjE[i] = 0;
                            cView.clearProj(cModel.ProjEX[i], cModel.ProjEY[i]);
                        }
                        else
                        {
                            cView.clearProj(cModel.ProjEX[i], cModel.ProjEY[i]);
                            cModel.enemyProjHoming(i);
                            cView.drawProj(cModel.ProjEX[i], cModel.ProjEY[i], 2);
                            cModel.enemyProjectiles(i);
                            //cModel.ProjEMove[i] = 0;
                        }
                    }
                }

                //Player Collision
                if (cModel.PCol == 1)
                {
                    cSound.PlaySound(3);
                    cView.drawPlayer(cModel.PX, cModel.PY);
                    cModel.PCol = 0;
                    cModel.PColCount++;
                    cView.drawColScore(cModel.PColCount, cModel.EColCount);
                }

                //Enemy Spawn
                //cModel.enemySpawn();
                 

            }//end mainLoop while
        }//end mainLoop
    }
}
