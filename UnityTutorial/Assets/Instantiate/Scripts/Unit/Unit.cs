using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 direction;
    [SerializeField] float speed = 5.0f;

    private void Awake()
    {
        target = GameObject.Find("Player");
    }

    public void Update()
    {
        Move();
    }
    public virtual void Move()
    {
        // 1. Target의 벡터 - 자신의 위치 벡터 = 자신이 가고자 하는 방향
        direction = target.transform.position - transform.position;

        // 2. 벡터의 정규화
        direction.Normalize();

        // 3. LookAt() : 특정한 대상을 바라보는 함수입니다.
        transform.LookAt(target.transform);

        // 4. 방향 벡터를 구한 값을 가지고 이동을 합니다.
        transform.position += direction * speed * Time.deltaTime;
    }


    // 객체는 여러 곳에서 생성될 수 있는데, 호출하는 쪽이 객체의 생성자에
    // 직접 의존하고 있으면 나중에 변경되었을 때 수정되어야 하는 코드가 많이 발생합니다.
}
