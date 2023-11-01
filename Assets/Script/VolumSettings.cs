    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.Audio;

    public class VolumSettings : MonoBehaviour
    {
        [SerializeField] private AudioMixer myMixer;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider SFXSlider;

        private void Start()
        {
           if(PlayerPrefs.HasKey("musicVolume"))
            {
                GetVolume();
            }
            else
            {
                SetMusic();
                SetSFX();
            }
        }

        public void SetMusic()
        {
            float volume = musicSlider.value;
            myMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("musicVolume", volume);
        }

        public void SetSFX()
        {
            float sfx = SFXSlider.value;
            myMixer.SetFloat("SFX", Mathf.Log10(sfx) * 20);
            PlayerPrefs.SetFloat("SFXVolume", sfx);
        }

        private void GetVolume()
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            SetMusic();
            SetSFX();
        }
        
        public void SetStartGame()
        {

        }
    }
