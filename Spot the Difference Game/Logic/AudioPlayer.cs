using NAudio.Wave;
using System.Threading.Tasks;

namespace Spot_the_Difference_Game.Logic
{
    public static class AudioPlayer
    {
        public static void PlaySoundAsync(string filePath)
        {
            Task.Run(() =>
            {
                using (var audioFile = new AudioFileReader(filePath))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(100);
                    }
                }
            });
        }
    }
}

