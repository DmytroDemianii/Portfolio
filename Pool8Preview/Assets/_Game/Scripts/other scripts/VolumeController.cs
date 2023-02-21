using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource musicSource;

    private const string VolumePrefName = "MusicVolume";


    private void Start()
    {
        if (PlayerPrefs.HasKey(VolumePrefName))
        {
            float volume = PlayerPrefs.GetFloat(VolumePrefName);
            musicSource.volume = volume;
            volumeSlider.value = volume;
        }
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat(VolumePrefName, volume);
        PlayerPrefs.Save();
    }
}