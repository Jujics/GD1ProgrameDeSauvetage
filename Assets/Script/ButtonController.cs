using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject currentButton;
    public Material activeMaterial;
    public Material inactiveMaterial;
    public float timeActive;
    private bool buttonRange = false;

    void Update()
    {
        if (buttonRange && Input.GetKeyDown(KeyCode.E))
        {
            PressButton();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button"))
        {
            currentButton = other.gameObject;
            buttonRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Button"))
        {
            StopAllCoroutines();
            currentButton = null;
            buttonRange = false;
            other.GetComponent<MeshRenderer>().material = inactiveMaterial;
        }
    }

    private void PressButton()
    {
        if (currentButton != null)
        {
            StartCoroutine(ActivateButtonForDuration(timeActive));
        }
    }

    private IEnumerator ActivateButtonForDuration(float duration)
    {
        currentButton.GetComponent<MeshRenderer>().material = activeMaterial;
        yield return new WaitForSeconds(duration);
        currentButton.GetComponent<MeshRenderer>().material = inactiveMaterial;
    }
}