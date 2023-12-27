using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Move,
    Attack,
    Die
}


public abstract class Unit : MonoBehaviour
{
    [SerializeField] State state;

    [SerializeField] Animator animator;

    [SerializeField] GameObject target;

    [SerializeField] Vector3 direction;
    [SerializeField] Vector3 targetDirection;

    [SerializeField] float speed = 5.0f;

    private void Awake()
    {
        target = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        switch (state)
        {
            case State.Move: Move();
                break;

            case State.Attack: Attack();
                break;

            case State.Die: Die();
                break;
        }

    }
    public virtual void Move()
    {
        animator.SetBool("Attack", false);

        // 1. Target의 벡터 - 자신의 위치 벡터 = 자신이 가고자 하는 방향
        direction = target.transform.position - transform.position;
        targetDirection = target.transform.position;

        // 2. y축을 0으로 설정합니다.
        direction.y = 0;
        direction.y = 0;

        // 3. 벡터의 정규화
        direction.Normalize();

        // 4. LookAt() : 특정한 대상을 바라보는 함수입니다.
        transform.LookAt(targetDirection);

        // 5. 방향 벡터를 구한 값을 가지고 이동을 합니다.
        transform.position += direction * speed * Time.deltaTime;
    }

    public virtual void Attack() 
    {
        animator.SetBool("Attack", true);
    }

    public virtual void Die()
    {

    }

    // 객체는 여러 곳에서 생성될 수 있는데, 호출하는 쪽이 객체의 생성자에
    // 직접 의존하고 있으면 나중에 변경되었을 때 수정되어야 하는 코드가 많이 발생합니다.

    // Collision 충돌 : 물리적인 충돌
    // Trigger   충돌 : 물리 계산이 사용되지 않는 충돌

    // OnTriggerEnter() : Trigger 충돌이 되었을 때 이벤트를 호출하는 함수입니다.
    private void OnTriggerEnter(Collider other)
    {
        state = State.Attack;

    }

    // OnTriggerStay() : Trigger 충돌 중일 때 이벤트를 호출하는 함수입니다.
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    // OnTriggerExit() : Trigger 충돌이 끝났을 때 이벤트를 호출하는 함수입니다.
    private void OnTriggerExit(Collider other)
    {
        state = State.Move;
    }
}
