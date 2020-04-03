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
    }

    private void CheckDirectionAndPunch()
    {
        if(XCI.GetButton(XboxButton.X) && gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
        }
    }

    public void ActivateRightCollider()
    {
        if(gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
            rightCollider.enabled = true;
            StartCoroutine(PunchDelay());
        }
    }

    public void ActivateLeftCollider()
    {
        if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
        {
            leftCollider.enabled = true;
            StartCoroutine(PunchDelay());
        }
    }

    public void TurnOfColliders()
    {

        leftCollider.enabled = false;
        rightCollider.enabled = false;
    }

    private IEnumerator PunchDelay()
    {
        yield return new WaitForSeconds(0.1f);
        leftCollider.enabled = false;
        rightCollider.enabled = false;
    }
}
