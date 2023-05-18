using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AudioActivation : UdonSharpBehaviour
{
    [Header("鸭鸭讨厌Bug")]
    
    [Header("检测的声音源")]
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    [Header("关闭的层级")]
    public Transform transformToToggle;

    private bool isAudioActive = true;

    private void Start()
    {
        isAudioActive = audioSource1.isPlaying || audioSource2.isPlaying || audioSource3.isPlaying;
        ToggleTransform();
        transformToToggle.gameObject.SetActive(true);  // 将层级更改为默认开启状态
    }

    private void Update()
    {
        bool newAudioActive = audioSource1.isPlaying || audioSource2.isPlaying || audioSource3.isPlaying;
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
