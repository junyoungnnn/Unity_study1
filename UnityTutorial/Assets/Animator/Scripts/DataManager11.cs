using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager11 : MonoBehaviour
{

    // 중복이름으로 DataManager11 으로 수정
    public float[] times = null;

    public void Start()
    {
        for (int i = 0; i < times.Length; i++)
        {
            Debug.Log(times[i]);
        }
    }
}
