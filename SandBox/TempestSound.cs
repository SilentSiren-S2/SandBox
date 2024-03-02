using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace SandBox
{
    internal class TempestSound
    {
        private WindowsMediaPlayer wmp;

        public TempestSound()
        {
            InitializeMediaPlayer();
        }

        private void InitializeMediaPlayer()
        {
            wmp = new WindowsMediaPlayer();
        }

        public void Play(string fileName)
        {
            try
            {
                // Отримуємо абсолютний шлях до файлу, об'єднавши його з шляхом проекту
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                // Запускаємо програвання MP3-файлу
                wmp.URL = filePath;
                wmp.controls.play();
            }
            catch { }
        }

        public void Stop()
        {
            // Зупиняємо програвання
            wmp.controls.stop();
        }
    }
}
