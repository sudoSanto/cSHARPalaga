using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;

namespace cSHARPalaga
{
    class calagaSound
    {
        public calagaSound() { }

        public void PlaySound(int selectSound)
        {
            System.Media.SoundPlayer wavpShoot = new System.Media.SoundPlayer();
            wavpShoot.SoundLocation = @".\pShoot.wav";

            System.Media.SoundPlayer waveShoot = new System.Media.SoundPlayer();
            waveShoot.SoundLocation = @".\eShoot.wav";

            System.Media.SoundPlayer wavBip = new System.Media.SoundPlayer();
            wavBip.SoundLocation = @".\bip.wav";

            System.Media.SoundPlayer wavBoom1 = new System.Media.SoundPlayer();
            wavBoom1.SoundLocation = @".\boom1.wav";

            switch (selectSound)
                {
                    case 1:
                        wavpShoot.Play();
                        selectSound = 0;
                        break;

                    /*case 2:
                        waveShoot.Play();
                        selectSound = 0;
                        break;*/

                    case 3:
                        wavBip.Play();
                        selectSound = 0;
                        break;

                    case 4:
                        wavBoom1.Play();
                        selectSound = 0;
                        break;

                    default:
                            break;
                }
            
        }//end PlaySound

    }
}
