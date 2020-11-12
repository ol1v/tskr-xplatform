
using Xamarin.Essentials;

namespace Taskerino.ViewModel
{
    public class NewTaskViewModel
    {
        public static async System.Threading.Tasks.Task ReadTask()
        {
            await TextToSpeech.SpeakAsync("Added Task");

            // This method will block until utterance finishes.
        }
    }
}