using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip[] animationClip;


    void Start()
    {
        for (int i = 0; i < animationClip.Length; i ++)
        {
            var data = AnimationUtility.GetAnimationClipSettings(animationClip[i]);

            data.loopTime = false;

            AnimationUtility.SetAnimationClipSettings(animationClip[i], data);
        }
    }

    void Update()
    {

        // GetCurrentAnimatorStateInfo(0).IsName("Close")
        // ���� �ִϸ��̼��� �̸��� "Close" ���.
        // 0�� ���̾� ������
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Close"))
        {
            // animator.GetCurrentAnimatorStateInfo(0).normalizedTime
            // ���� ������ �ִϸ��̼��� ���� ���¸� �ǹ��մϴ�.
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                // SetActive : ���� ������Ʈ�� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ�� �� �ִ� �Լ��Դϴ�.
                animator.gameObject.SetActive(false);
            }
        }
    }

    public void Open()
    {
        animator.gameObject.SetActive(true);
    }

    public void Close()
    {
        animator.SetTrigger("Close");
    }
    
}
