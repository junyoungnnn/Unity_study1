using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] Unit unit;

    [SerializeField] List<GameObject> unitList;

    [SerializeField] Factory factory;

    [SerializeField] int createCount = 5;
    [SerializeField] int activeCount = 0;


    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        unitList.Capacity = 20;
        CreatePool();
    }

    public void CreatePool()
    {
        for(int i = 0; i< createCount; i++)
        {
            //unitList.Add(factory.CreateUnit(unit));

            // 1. 게임 오브젝트를 생성합니다.
            GameObject obj = factory.CreateUnit(unit);

            // 2. 게임 오브젝트를 비활성화합니다.
            obj.SetActive(false);

            // 3. List에 게임오브젝트를 넣어줍니다.
            unitList.Add(obj);

        }
    }
    public GameObject GetObject()
    {
        // 1. activeCount 변수의 값을 증가시킵니다.
        activeCount = activeCount % unitList.Count;

        // 2. activeCount 인덱스로 접근한 게임 오브젝트가 비활성화되어 있는지 확인합니다.
        if (unitList[activeCount].activeSelf == false)
        {
            // 3. activeCount 인덱스로 접근한 게임 오브젝트가 비활성화 되어 있다면 활성화시킵니다.
            GameObject obj = unitList[activeCount++];

            obj.gameObject.SetActive(true);

            // 4. activeCount 인덱스로 접근한 게임오브젝트를 반환합니다
            return obj;
        }
        return null;
    }
}
