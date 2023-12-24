using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioClip[] audioClip;
    [SerializeField] AudioSource audioSource;

    public void Search()
    {
        // Drone 오브젝트를 찾고
        GameObject objectSearched = GameObject.Find("Drone");

        // Drone의 첫번째 자식오브젝트
        objectSearched.transform.GetChild(0).gameObject.SetActive(true);

        AudioSource.PlayClipAtPoint(audioClip[0], objectSearched.transform.position);

    }

    public void Signal()
    {
        audioSource.PlayOneShot(audioClip[1]);
    }
    
}
