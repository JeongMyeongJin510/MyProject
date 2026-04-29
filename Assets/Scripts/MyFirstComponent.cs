using System;
using UnityEngine;

public class MyFirstComponent : MonoBehaviour
{
    private MyPureClass pureclass = new MyPureClass();

    private bool m_isFixedUpateFirstCall = false;
    private bool m_isUpateFirstCall = false;
    private bool m_isLateUpateFirstCall = false;


    private void Awake()
    {
        Debug.Log("크크크 어웨이크");
        Debug.Log("Awake 입니다");
        pureclass.Scratch();
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable 입니다");
    }

    private void Start()
    {
        Debug.Log("Start 입니다");
    }

    private void FixedUpdate()
    {
        if (m_isFixedUpateFirstCall  == true)
        {
            return;
        }
        m_isFixedUpateFirstCall = true;
        Debug.LogWarning("FixedUpdate 입니다");

    }

    private void Update()
    {
        if (m_isUpateFirstCall == true)
        {
            return;
        }
        m_isUpateFirstCall = true;
        Debug.LogWarning("Update 입니다");

    }

    private void LateUpdate()
    {
        if (m_isLateUpateFirstCall == true)
        {
            return;
        }
        m_isLateUpateFirstCall = true;
        Debug.LogWarning("LateUpdate 입니다");

        Destroy(this.gameObject);

    }

    private void OnDisable()
    {
        Debug.Log("OnDisable 입니다");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy 입니다");
    }

}
