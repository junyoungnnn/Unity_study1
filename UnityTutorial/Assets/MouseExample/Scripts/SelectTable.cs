using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SelectTable : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] ParticleSystem particle;

    private bool select;

    void Start()
    {
        select = true;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        particle.Play();
      //  rigidbody.useGravity = false;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3
        (
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.WorldToScreenPoint(gameObject.transform.position).z
        );

        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void OnMouseExit()
    {
        //  rigidbody.useGravity = true;
        select = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        string selectObject = transform.name;
        string collisionObject = other.transform.name;

        if(selectObject == collisionObject)
        {
            int add = int.Parse(collisionObject.Substring(collisionObject.Length-1)) + int.Parse(selectObject.Substring(selectObject.Length - 1));

            if (select)
            {
                Instantiate(Resources.Load<GameObject>("Container " + add));
            }
            Destroy(gameObject);
            Destroy(other.gameObject);
        }    
        
    }
}
