using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Move,
    Attack,
    Die,
    None
}

// 자동으로 컴포넌트를 넣어줌
[RequireComponent(typeof(HPBar))]

public abstract class Unit : MonoBehaviour
{
    [SerializeField] GameObject target;

    [SerializeField] State state;

    [SerializeField] Animator animator;

    [SerializeField] Vector3 originDirection;

    [SerializeField] Vector3 direction;
    [SerializeField] Vector3 targetDirection;

    [SerializeField] float speed = 5.0f;

    [SerializeField] protected float health;
    [SerializeField] protected float maxHealth;

    [SerializeField] HPBar healthBar;
    [SerializeField] Sound sound = new Sound();



    private void Awake()
    {
        target = GameObject.Find("Player");
        healthBar = GetComponent<HPBar>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        state = State.Move;
        originDirection = transform.position;

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
        //healthBar.UpdateHP(health, maxHealth);
    }
    public void OnHit(float damage)
    {
        if (health <= 0)
        {
            return;
        }

        health -= damage;

        healthBar.UpdateHP(health, maxHealth);

        if (health <= 0)
        {
            state = State.Die;
        }
    }

    public virtual void Release()
    {
        //Destroy(gameObject);
        ObjectPool.instance.InsertObject(gameObject);
    }

    public virtual void Move()
    {
        animator.SetBool("Attack", false);

        // 1. Target의 벡터 - 자신의 위치 벡터 = 자신이 가고자 하는 방향
        direction = target.transform.position - transform.position;
        targetDirection = target.transform.position;

        // 2. y축을 0으로 설정합니다.
        direction.y = 0;
        targetDirection.y = 0;

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

    public void AttackSound()
    {
        SoundManager.instance.Sound(sound.audioClips[0]);
    }

    public virtual void Die()
    {
        animator.Play("Die");
        SoundManager.instance.Sound(sound.audioClips[1]);

        state = State.None;
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

    private void OnDisable()
    {
        transform.position = originDirection;
        health = maxHealth;
    }

}
