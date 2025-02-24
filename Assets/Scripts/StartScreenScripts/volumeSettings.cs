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
        float volumemusic = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volumemusic) * 20);
    }

    public void SetSfxVolume()
    {
        float volumesfx = sfxSlider.value;
        myMixer.SetFloat("Sfx", Mathf.Log10(volumesfx) * 20);
    }

    public void SetMasterVolume()
    {
        float volumemaster = masterSlider.value;
        myMixer.SetFloat("Master", Mathf.Log10(volumemaster) * 20);
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
