using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] GameObject unit;
    [SerializeField] Transform createPosition;

    [Tooltip("���͸� �����ϴ� ����")]
    [SerializeField] int createCount = 5;
   
    private void Start()
    {
        // Instantiate : ���� ������Ʈ�� �����ϴ� �Լ��Դϴ�.
        
        for(int i = 0; i< createCount; i++)
        {
            // 1. ���� ������Ʈ�� ������Ų��.
            GameObject monster = Instantiate(unit, createPosition);

            // 2. ������ ���� ������Ʈ�� ��ġ�� �����մϴ�.
            monster.transform.position = new Vector3(i * 5, 0, createPosition.position.z);

            Debug.Log("World Position : " + monster.transform.position);
            Debug.Log("Local Position : " + monster.transform.localPosition);
        }
        
    }
}
