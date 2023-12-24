using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioClip[] audioClip;
    [SerializeField] AudioSource audioSource;

    public void Search()
    {
        // Drone ������Ʈ�� ã��
        GameObject objectSearched = GameObject.Find("Drone");

        // Drone�� ù��° �ڽĿ�����Ʈ
        objectSearched.transform.GetChild(0).gameObject.SetActive(true);

        AudioSource.PlayClipAtPoint(audioClip[0], objectSearched.transform.position);

    }

    public void Signal()
    {
        audioSource.PlayOneShot(audioClip[1]);
    }
    
}
