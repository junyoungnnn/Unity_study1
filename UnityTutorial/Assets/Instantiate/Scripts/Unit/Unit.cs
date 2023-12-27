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

        // 2. y���� 0���� �����մϴ�.
        direction.y = 0;

        // 3. ������ ����ȭ
        direction.Normalize();

        // 4. LookAt() : Ư���� ����� �ٶ󺸴� �Լ��Դϴ�.
        transform.LookAt(target.transform);

        // 5. ���� ���͸� ���� ���� ������ �̵��� �մϴ�.
        transform.position += direction * speed * Time.deltaTime;
    }


    // ��ü�� ���� ������ ������ �� �ִµ�, ȣ���ϴ� ���� ��ü�� �����ڿ�
    // ���� �����ϰ� ������ ���߿� ����Ǿ��� �� �����Ǿ�� �ϴ� �ڵ尡 ���� �߻��մϴ�.

    // Collision �浹 : �������� �浹
    // Trigger   �浹 : ���� ����� ������ �ʴ� �浹

    // OnTriggerEnter() : Trigger �浹�� �Ǿ��� �� �̺�Ʈ�� ȣ���ϴ� �Լ��Դϴ�.
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");

        speed = 0;
    }

    // OnTriggerStay() : Trigger �浹 ���� �� �̺�Ʈ�� ȣ���ϴ� �Լ��Դϴ�.
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    // OnTriggerExit() : Trigger �浹�� ������ �� �̺�Ʈ�� ȣ���ϴ� �Լ��Դϴ�.
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
    }
}
