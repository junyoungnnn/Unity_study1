using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public abstract void Move();

    // 객체는 여러 곳에서 생성될 수 있는데, 호출하는 쪽이 객체의 생성자에
    // 직접 의존하고 있으면 나중에 변경되었을 때 수정되어야 하는 코드가 많이 발생합니다.
}
