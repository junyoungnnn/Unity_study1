using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] Transform spawnPosition;


    // Unit -> 소서리스, 마법사, 전사, 오크 등등 추가해도 아래코드는 변경이 일어나지 않음.
    public GameObject CreateUnit(Unit unit)
    {
        // 게임 오브젝트를 생성합니다.
        GameObject monster = Instantiate(unit.gameObject, spawnPosition);

        // 게임 오브젝트를 반환합니다.
        return monster;

    }
}
