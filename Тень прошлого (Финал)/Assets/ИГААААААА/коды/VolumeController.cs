using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider; // Ссылка на слайдер
    public AudioSource audioSource1; // Ссылка на AudioSource
    public AudioSource audioSource2;
    void Start()
    {
        // Установите начальное значение громкости
        volumeSlider.value = audioSource1.volume;
        volumeSlider.value = audioSource2.volume;
        // Подпишитесь на изменение значения слайдера
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    void ChangeVolume(float value)
    {
        audioSource1.volume = value;
        audioSource2.volume = value;
    }
}
