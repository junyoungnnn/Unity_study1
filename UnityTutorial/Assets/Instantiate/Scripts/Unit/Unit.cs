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
        // 1. Target�� ���� - �ڽ��� ��ġ ���� = �ڽ��� ������ �ϴ� ����
        direction = target.transform.position - transform.position;

        // 2. ������ ����ȭ
        direction.Normalize();

        // 3. LookAt() : Ư���� ����� �ٶ󺸴� �Լ��Դϴ�.
        transform.LookAt(target.transform);

        // 4. ���� ���͸� ���� ���� ������ �̵��� �մϴ�.
        transform.position += direction * speed * Time.deltaTime;
    }


    // ��ü�� ���� ������ ������ �� �ִµ�, ȣ���ϴ� ���� ��ü�� �����ڿ�
    // ���� �����ϰ� ������ ���߿� ����Ǿ��� �� �����Ǿ�� �ϴ� �ڵ尡 ���� �߻��մϴ�.
}
