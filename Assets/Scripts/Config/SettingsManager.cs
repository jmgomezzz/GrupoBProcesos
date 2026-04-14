using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("volume", value);
    }

    void Start()
    {
        float vol = PlayerPrefs.GetFloat("volume", 0.5f);
        volumeSlider.value = vol;
        SetVolume(vol);
    }
    void Awake()
{
    DontDestroyOnLoad(gameObject);
}
}