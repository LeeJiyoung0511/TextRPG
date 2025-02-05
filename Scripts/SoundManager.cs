using NAudio.Wave;

namespace TextRPG
{
    internal class SoundManager
    {
        private static readonly string FILENAME_BGM = "BGM.mp3";

        public static void PlayBGM()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sound", FILENAME_BGM);

            if (!File.Exists(filePath))
            {
                Console.WriteLine("파일을 찾을 수 없습니다: " + filePath);
                return;
            }

            var audioFile = new MediaFoundationReader(filePath);
            var outputDevice = new DirectSoundOut();

            outputDevice.Init(audioFile);
            outputDevice.Play();

            outputDevice.PlaybackStopped += (sender, args) =>
            {
                audioFile.Position = 0;
                outputDevice.Play();
            };
        }

    }
}
