using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class volumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider masterSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();      
        }
        
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetSfxVolume();    
        }
        
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMasterVolume();      
        }        
    }    
    
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }

    public void SetSfxVolume()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("Sfx", Mathf.Log10(volume) * 20);
    }

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        myMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }
    
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        
        SetMusicVolume();
        
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        
        SetSfxVolume();
        
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        
        SetMasterVolume();
    }
}
