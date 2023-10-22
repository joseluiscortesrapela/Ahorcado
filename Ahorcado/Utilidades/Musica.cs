using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado.Utilidades
{
    public class Musica
    {
        private static Musica instance;
        private IWavePlayer player;
        private AudioFileReader audioFile;

        private Musica()
        {
            player = new WaveOut();
        }
 

        public void LoadMusic(string rutaMp3)
        {
            audioFile = new AudioFileReader(rutaMp3);
        }

        public void Play()
        {
            if (audioFile != null)
            {
                player.Init(audioFile);
                player.Play();
            }
        }

        public void Stop()
        {
            player.Stop();
        }
    }


}
