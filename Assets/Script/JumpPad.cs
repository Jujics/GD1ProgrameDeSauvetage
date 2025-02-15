using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float boostSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Boosting(other.gameObject));
        }
    }

    private IEnumerator Boosting(GameObject target)
    {
        float baseJump = target.GetComponent<PlayerController>().jumpForce;
        target.GetComponent<PlayerController>().jumpForce = boostSpeed;
        yield return new WaitForSeconds(2f);
        target.GetComponent<PlayerController>().jumpForce = baseJump;
    }
}
