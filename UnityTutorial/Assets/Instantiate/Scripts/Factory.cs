using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] Transform spawnPosition;


    // Unit -> �Ҽ�����, ������, ����, ��ũ ��� �߰��ص� �Ʒ��ڵ�� ������ �Ͼ�� ����.
    public GameObject CreateUnit(Unit unit)
    {
        // ���� ������Ʈ�� �����մϴ�.
        GameObject monster = Instantiate(unit.gameObject, spawnPosition);

        // ���� ������Ʈ�� ��ȯ�մϴ�.
        return monster;

    }
}
