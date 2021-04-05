using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    public GameObject am;
    Slider audioSlider;

    void Start()
    {
        am = GameObject.FindGameObjectWithTag("AM");
        audioSlider = GetComponent<Slider>();
    }

    void Update()
    {
        audioSlider.value = PlayerPrefs.GetFloat("volume");
    }

    public void AdjustBGM(float volume)
    {
        am.GetComponent<AudioSource>().volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }
}
