using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressObject : MonoBehaviour
{
    public float pressDistance = 0.1f; // Distance the button can be pressed
    public float pressSpeed = 5f; // Speed at which the button is pressed
    public UnityEvent onPressed;
    public UnityEvent onReleased;

    private Vector3 originalPosition;
    private Vector3 pressedPosition;
    private bool isPressed = false;

    private void Start()
    {
        originalPosition = transform.localPosition;
        pressedPosition = originalPosition - new Vector3(0, pressDistance, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed && other.CompareTag("Player")) // Assuming the player will interact with the button
        {
            StartCoroutine(PressButton());
            isPressed = true;
            onPressed.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPressed && other.CompareTag("Player"))
        {
            StartCoroutine(ReleaseButton());
            isPressed = false;
            onReleased.Invoke();
        }
    }

    private IEnumerator PressButton()
    {
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            transform.localPosition = Vector3.Lerp(originalPosition, pressedPosition, elapsedTime);
            elapsedTime += Time.deltaTime * pressSpeed;
            yield return null;
        }
        transform.localPosition = pressedPosition;
    }

    private IEnumerator ReleaseButton()
    {
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            transform.localPosition = Vector3.Lerp(pressedPosition, originalPosition, elapsedTime);
            elapsedTime += Time.deltaTime * pressSpeed;
            yield return null;
        }
        transform.localPosition = originalPosition;
    }
}
