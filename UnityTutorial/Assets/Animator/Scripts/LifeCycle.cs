using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

// Awake() : ��ü�� �ν��Ͻ� �� �Ŀ� ȣ��Ǵ� �̺�Ʈ �Լ�, �� ������ ��Ȱ
// ex) �������� �����͸� �޾ƿ���
// start() : �Լ����� �����͸� �ʱ�ȭ ��Ų��.
// OnEnable() : ��ü�� Ȱ��ȭ �Ǿ��� �� ȣ��Ǵ� �̺�Ʈ �Լ�

// Start() : awake() �� ����ѵ�,
//          ��ũ��Ʈ�� Ȱ��ȭ �Ǿ��� �� ȣ��Ǵ� �̺�Ʈ �Լ�
public class LifeCycle : MonoBehaviour
{
    private void Awake()
    {
        // Awake() �Լ��� ���� ������Ʈ�� ������ ��
        // �� �ѹ��� ȣ��Ǹ�, ��ũ��Ʈ�� ��Ȱ��ȭ ������ ����
        // ȣ��Ǵ� �̺�Ʈ �Լ��Դϴ�.
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        // OnEnable() �Լ��� ���� ������Ʈ�� Ȱ��ȭ ��
        // ������ ȣ��Ǵ� �̺�Ʈ �Լ��Դϴ�.
        Debug.Log("OnEnable");
    }

    private void Start()
    {
        // Start() �Լ��� ���� ������Ʈ�� ������ ��
        // �� �ѹ��� ȣ��Ǹ�, ��ũ��Ʈ�� ��Ȱ��ȭ ������ ����
        // ȣ����� �ʴ� �̺�Ʈ �Լ��Դϴ�.
        Debug.Log("Start");
    }

    private void FixedUpdate()
    {
        // FixedUpdate(() �Լ��� timeStep�� ������ ���� ����
        // ������ �������� ȣ��Ǵ� �̺�Ʈ �Լ��Դϴ�.
        Debug.Log("FixedUpdate");
    }

    private void Update()
    {
        // Update() �Լ��� framerate�� �ұ�Ģ�� ��������
        // �� �����Ӹ��� ȣ��Ǵ� �̺�Ʈ �Լ��Դϴ�.
        Debug.Log("Update");
    }

    private void LateUpdate()
    {
        // LateUpdate() �Լ��� Update() �Լ��� ȣ��� ��
        // �ѹ��� ȣ��Ǵ� �̺�Ʈ �Լ��Դϴ�.
        Debug.Log("LateUpdate");
    }

    private void OnDisable()
    {
        // OnDisable() �Լ��� ���� ������Ʈ�� ��Ȱ��ȭ
        // �Ǿ��� �� ȣ��Ǵ� �̺�Ʈ �Լ��Դϴ�.
        Debug.Log("OnDisable");
    }

    private void OnDestroy()
    {
        // OnDestroy() �Լ��� ���� ������Ʈ�� ���� �Ǿ�����
        // ȣ��Ǵ� �Լ��Դϴ�.
        Debug.Log("OnDestroy");
    }
}
