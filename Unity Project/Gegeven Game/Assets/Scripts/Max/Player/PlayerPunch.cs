using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerPunch : MonoBehaviour
{

    PlayerDirection playerDirection;

    [SerializeField] CircleCollider2D rightCollider;
    [SerializeField] CircleCollider2D leftCollider;

    void Update()
    {
        Punch();
    }

    private void Punch()
    {

        if (XCI.GetButton(XboxButton.X))
        {
            playerDirection = PlayerDirection.punch;
        }
        else
        {
            StartCoroutine(PunchDelay());
        }

    
    }

    private void CheckDirectionAndPunch()
    {
        if(XCI.GetButton(XboxButton.X) && gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
            playerDirection = PlayerDirection.punch;
        }
    }

    public void ActivateRightCollider()
    {
        rightCollider.enabled = true;
        StartCoroutine(PunchDelay());
        rightCollider.enabled = false;
    }

    public void ActivateLeftCollider()
    {
        leftCollider.enabled = true;
    }


    private IEnumerator PunchDelay()
    {
        yield return new WaitForSeconds(1f);
    }
}
