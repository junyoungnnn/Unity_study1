using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager11 : MonoBehaviour
{

    // �ߺ��̸����� DataManager11 ���� ����
    public float[] times = null;

    public void Start()
    {
        for (int i = 0; i < times.Length; i++)
        {
            Debug.Log(times[i]);
        }
    }
}
