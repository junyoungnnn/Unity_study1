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

// �ڵ����� ������Ʈ�� �־���
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

        // 1. Target�� ���� - �ڽ��� ��ġ ���� = �ڽ��� ������ �ϴ� ����
        direction = target.transform.position - transform.position;
        targetDirection = target.transform.position;

        // 2. y���� 0���� �����մϴ�.
        direction.y = 0;
        targetDirection.y = 0;

        // 3. ������ ����ȭ
        direction.Normalize();

        // 4. LookAt() : Ư���� ����� �ٶ󺸴� �Լ��Դϴ�.
        transform.LookAt(targetDirection);

        // 5. ���� ���͸� ���� ���� ������ �̵��� �մϴ�.
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

    // ��ü�� ���� ������ ������ �� �ִµ�, ȣ���ϴ� ���� ��ü�� �����ڿ�
    // ���� �����ϰ� ������ ���߿� ����Ǿ��� �� �����Ǿ�� �ϴ� �ڵ尡 ���� �߻��մϴ�.

    // Collision �浹 : �������� �浹
    // Trigger   �浹 : ���� ����� ������ �ʴ� �浹

    // OnTriggerEnter() : Trigger �浹�� �Ǿ��� �� �̺�Ʈ�� ȣ���ϴ� �Լ��Դϴ�.
    private void OnTriggerEnter(Collider other)
    {
        state = State.Attack;
    }

    // OnTriggerStay() : Trigger �浹 ���� �� �̺�Ʈ�� ȣ���ϴ� �Լ��Դϴ�.
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    // OnTriggerExit() : Trigger �浹�� ������ �� �̺�Ʈ�� ȣ���ϴ� �Լ��Դϴ�.
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
