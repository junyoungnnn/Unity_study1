using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 5f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // Input.GetAxis() : 특정한 key를 누를 때 -1 ~ 1 사이의 값을 반환하는 함수입니다.
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        // 백터의 정규화
        direction.Normalize();

        // Time.deltaTime : 이전 프레임이 완료되는 데까지 걸린 시간을 의미합니다.
        transform.position += direction * speed * Time.deltaTime;
    }
}
