using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    private Ray ray;
    private RaycastHit rayCastHit;
    [SerializeField] LayerMask layerMask;
    [SerializeField] int bulletDamage = 10;
    [SerializeField] Sound sound = new Sound();

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SoundManager.instance.Sound(sound.audioClips[0]);

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out rayCastHit, Mathf.Infinity, layerMask))
            {
                rayCastHit.collider.GetComponent<Unit>().OnHit(bulletDamage);
            }
        }
    }
}
