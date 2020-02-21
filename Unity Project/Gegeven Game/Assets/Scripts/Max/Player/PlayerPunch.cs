using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public enum PunchStatus
{
    IdlePunch,
    punching
}

public class PlayerPunch : MonoBehaviour
{
    public PunchStatus PunchStatus;

    public Animator animator;

    private BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        SetValues();

        Punch();
    }

    private void SetValues()
    {
        animator.SetInteger("State", (int)PunchStatus);
    }

    private void Punch()
    {

        if (XCI.GetButton(XboxButton.X))
        {
            PunchStatus = PunchStatus.punching;
            boxCollider.enabled = true;
        }
        else
        {
            PunchStatus = PunchStatus.IdlePunch;
            StartCoroutine(PunchDelay());
            boxCollider.enabled = false;
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    PunchStatus = PunchStatus.punching;
        //    boxCollider.enabled = true;
        //}
        //else
        //{
        //////PunchStatus = PunchStatus.IdlePunch;
        //////StartCoroutine(PunchDelay());
        //////boxCollider.enabled = false;
        //}
    }

    private IEnumerator PunchDelay()
    {
        yield return new WaitForSeconds(1.5f);
    }
}
