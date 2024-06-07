using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider; // ������ �� �������
    public AudioSource audioSource1; // ������ �� AudioSource
    public AudioSource audioSource2;
    void Start()
    {
        // ���������� ��������� �������� ���������
        volumeSlider.value = audioSource1.volume;
        volumeSlider.value = audioSource2.volume;
        // ����������� �� ��������� �������� ��������
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    void ChangeVolume(float value)
    {
        audioSource1.volume = value;
        audioSource2.volume = value;
    }
}
