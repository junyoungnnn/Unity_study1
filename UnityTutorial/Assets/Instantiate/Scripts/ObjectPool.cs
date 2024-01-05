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
        unitList.Capacity = 20;
        CreatePool();
    }

    private void Start()
    {
        
    }

    public void CreatePool()
    {
        for(int i = 0; i< createCount; i++)
        {
            //unitList.Add(factory.CreateUnit(unit));

            // 1. ���� ������Ʈ�� �����մϴ�.
            GameObject obj = factory.CreateUnit(unit);

            // 2. ���� ������Ʈ�� ��Ȱ��ȭ�մϴ�.
            obj.SetActive(false);

            // 3. List�� ���ӿ�����Ʈ�� �־��ݴϴ�.
            unitList.Add(obj);

        }
    }
    public GameObject GetObject()
    {
        // 1. activeCount ������ ���� unitList�� ũ�⺸�� ũ�ų� ���ٸ�
        if(activeCount >= unitList.Count)
        {
            // activeCount ������ ���� 0���� �ʱ�ȭ�մϴ�.
            activeCount = 0;
        }

        // 2. activeCount �ε����� ������ ���� ������Ʈ�� ��Ȱ��ȭ�Ǿ� �ִ��� Ȯ���մϴ�.
        if (unitList[activeCount].activeSelf == false)
        {
            // 3. activeCount �ε����� ������ ���� ������Ʈ�� ��Ȱ��ȭ �Ǿ� �ִٸ� Ȱ��ȭ��ŵ�ϴ�.
            GameObject obj = unitList[activeCount++];

            obj.gameObject.SetActive(true);

            // 4. activeCount �ε����� ������ ���ӿ�����Ʈ�� ��ȯ�մϴ�
            return obj;
        }
        return null;
    }
    public void InsertObject(GameObject prefab)
    {
        prefab.SetActive(false);       
    }

}
