using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //   [0]         [1]
    // �Ҽ�����     ������
    [SerializeField] List<Unit> listUnits;
    // [SerializeField] Transform createPosition;
    [SerializeField] Factory factory;

    //[Tooltip("���͸� �����ϴ� ����")]
    //[SerializeField] int createCount = 5;

    float timer = 0;

    public IEnumerator CreateRoutime()
    {
        while (true)
        {
            // Random.Range(0, listUnits.Count);
            // 0 ~ �ִ� -1 �� ���� ��ȯ�ϴ� �Լ��Դϴ�.
            factory.CreateUnit(listUnits[Random.Range(0, listUnits.Count)]);

            // new WaitForSeconds(5f) : Ư���� �ð����� �ڷ�ƾ�� ����մϴ�.
            yield return new WaitForSeconds(5f);
        }
    }

    public IEnumerator LogRoutine()
    {
        yield return new WaitForSeconds(1f);

        Debug.Log("Attack");
    }
   
    //public void UseFactory()
    //{
    //    factory.CreateUnit(listUnits[Random.Range(0,listUnits.Count)]);
    //}

    protected virtual void Start()
    {
        StartCoroutine(CreateRoutime());

        // UseFactory();

        // Instantiate : ���� ������Ʈ�� �����ϴ� �Լ��Դϴ�.

        //for(int i = 0; i< createCount; i++)
        //{
        //    // 1. ���� ������Ʈ�� ������Ų��.
        //    GameObject monster = Instantiate(unit, createPosition);

        //    // 2. ������ ���� ������Ʈ�� ��ġ�� �����մϴ�.
        //    monster.transform.position = new Vector3(i * 5, 0, createPosition.position.z);

        //    Debug.Log("World Position : " + monster.transform.position);
        //    Debug.Log("Local Position : " + monster.transform.localPosition);
        //}

    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LogRoutine());
        }
    }

    //private void Update()
    //{
    //    timer += Time.deltaTime;
    //    if(timer >= 5)
    //    {
    //        UseFactory();
    //        timer = 0;
    //    }
    //}
}
