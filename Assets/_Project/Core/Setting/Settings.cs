using UnityEngine;
using UnityEngine.UI;

namespace Core.Setting
{
    public class Settings : MonoBehaviour
    {
        public AudioSource backgroundMusic;
        public bool vbr;
        private void Start()
        {
            backgroundMusic.Play();
        }
        public void MuteSound()
        {
            AudioListener.volume = 0;
        }

        public void UnmuteSound()
        {
            AudioListener.volume = 1;
        }
        public void vibrationpusk()
        {
            if (vbr)
            {
                Handheld.Vibrate();
            } 
        }
    }
}
