using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
//By：明明鸭！

public class AudioActivation : UdonSharpBehaviour
{
    public AudioSource audioSource1; // 音频源1
    public AudioSource audioSource2; // 音频源2
    public Transform transformToToggle;

    private bool isAudioActive = true;

    private void Start()
    {
        isAudioActive = audioSource1.isPlaying || audioSource2.isPlaying;
        ToggleTransform();
        transformToToggle.gameObject.SetActive(true); // 将层级更改为默认开启状态
    }

    private void Update()
    {
        bool newAudioActive = audioSource1.isPlaying || audioSource2.isPlaying;
        if (newAudioActive != isAudioActive)
        {
            isAudioActive = newAudioActive;
            ToggleTransform();
        }
    }

    private void ToggleTransform()
    {
        transformToToggle.gameObject.SetActive(!isAudioActive);
    }
}
