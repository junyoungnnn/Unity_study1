using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Drone : MonoBehaviour
{

    public float speed = 55f;
    public Vector3 direction;
    
    void Start()
    {
        direction = transform.position;

        // InvokeRepeating() : 특수한 함수를 특정한 시간이 지난후에
        //                     특정한 시간마다 반복적으로 호출하는 함수입니다.

        // 첫번째 매개변수 : 실행할 함수의 이름

        // 두번째 매개변수 : 특정한 시간이 지난 후 실행할 시간

        // 세번쨰 매개변수 : 특정한 시간마다 반복적으로 함수를 호출하는 시간

        // nameof() : 좀 더 안정적으로 함수를 찾음. 
        InvokeRepeating(nameof(NewPosition), 5, 5);
    }

    
    
    void Update()
    {
        transform.Translate
            (Vector3.forward * speed * Time.deltaTime);
    }

    private void NewPosition()
    {
        transform.position = direction;
        transform.Find("Canvas").gameObject.SetActive(false);
    
    }

}
