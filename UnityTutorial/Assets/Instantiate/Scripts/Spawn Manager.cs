using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //   [0]         [1]
    // 소서리스     마법사
    [SerializeField] List<Unit> listUnits;
    // [SerializeField] Transform createPosition;
    [SerializeField] Factory factory;

    //[Tooltip("몬스터를 생성하는 변수")]
    //[SerializeField] int createCount = 5;

    float timer = 0;

    public IEnumerator CreateRoutime()
    {
        while (true)
        {
            // Random.Range(0, listUnits.Count);
            // 0 ~ 최댓값 -1 의 값을 반환하는 함수입니다.
            factory.CreateUnit(listUnits[Random.Range(0, listUnits.Count)]);

            // new WaitForSeconds(5f) : 특정한 시간동안 코루틴을 대기합니다.
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

        // Instantiate : 게임 오브젝트를 생성하는 함수입니다.

        //for(int i = 0; i< createCount; i++)
        //{
        //    // 1. 게임 오브젝트를 생성시킨다.
        //    GameObject monster = Instantiate(unit, createPosition);

        //    // 2. 생성된 게임 오브젝트의 위치를 설정합니다.
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
