using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour
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
        float baseSpeed = target.GetComponent<PlayerController>().moveSpeed;
        target.GetComponent<PlayerController>().moveSpeed = boostSpeed;
        yield return new WaitForSeconds(2f);
        target.GetComponent<PlayerController>().moveSpeed = baseSpeed;
    }
}
