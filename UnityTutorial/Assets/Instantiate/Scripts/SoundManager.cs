using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip[] audioClips;
}


public class SoundManager : MonoBehaviour
{

    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource sfxSource;

    public static SoundManager instance = null;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            //Destroy(gameObject);
        }
    }

    public void Sound(AudioClip audioClip)
    {
        // PlayOneShot : ���ÿ� ���� ��ġ���� ���带 ȣ���ϴ� �Լ��Դϴ�.
        sfxSource.PlayOneShot(audioClip);
    }

}
