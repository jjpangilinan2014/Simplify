using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simplify
{
    public partial class Record : UserControl
    {
        

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int mciSendCommand(string command, string returnstring, int length, int hwndCallback);
        public static bool recording = false;

        public Record()
        {
            InitializeComponent();
        }
        //Stopwatch sw;
        int seconds = 0;
        int minute = 0;
        int millis = 0;
        public static string _fileName;
        public static string _result;
        public static async Task ContinuousRecognitionWithFileAsync()
        {
            var config = SpeechConfig.FromSubscription("a53408905bb2463bab441ae56f2c40db", "eastus");

            var stopRecognition = new TaskCompletionSource<int>();

            using (var audioInput = AudioConfig.FromWavFileInput(_fileName))
            {
                using (var recognizer = new SpeechRecognizer(config, audioInput))
                {

                    recognizer.Recognized += (s, e) =>
                    {
                        if (e.Result.Reason == ResultReason.RecognizedSpeech)
                        {

                            _result += e.Result.Text + " ";
                        }

                    };


                    recognizer.SessionStopped += async (s, e) =>
                    {
                        //MessageBox.Show(_result);
                        System.IO.File.WriteAllText("WriteText.txt", _result);
                        stopRecognition.TrySetResult(0);
                    };


                    await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);

                    Task.WaitAny(new[] { stopRecognition.Task });

                    await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);
                }
            }
            // </recognitionContinuousWithFile>
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {

            if (!recording)
            {
                _fileName = AppDomain.CurrentDomain.BaseDirectory + String.Format("AudioRecordings_{0}.wav", DateTime.Now.ToString("yyyy-MM-dd_T_HH_mm_ss"));
                mciSendCommand("open new Type waveaudio Alias recsound", "", 0, 0);
                mciSendCommand("record recsound", "", 0, 0);
                button1.Text = "Stop Recording";
                recording = true;
                timer1.Start();
                millis = 0;
                seconds = 0;
                minute = 0;
                _result = "";
                label2.Text = String.Format("{0:00}:{1:00}.{2:00}", minute, seconds, millis);
            }
            else
            {
                mciSendCommand("save recsound " + _fileName, "", 0, 0);
                mciSendCommand("close recsound", "", 0, 0);
                button1.Text = "Start Recording";
                recording = false;
                timer1.Stop();
                await ContinuousRecognitionWithFileAsync();
            }

            

        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            millis++;
            if(millis >= 100)
            {
                seconds++;
                millis = 0;
                if(seconds >= 60)
                {
                    minute++;
                    seconds = 0;
                }
            }
            label2.Text = String.Format("{0:00}:{1:00}.{2:00}", minute, seconds, millis);
        }
    }
}
