using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionSound : MonoBehaviour
{
    public AudioClip soundEffect; // Drag and drop your sound effect into this field in the Unity Inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Add an AudioSource component to the object
        audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the sound effect to the AudioSource component
        audioSource.clip = soundEffect;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object collided with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Play the sound effect
            audioSource.Play();
        }
    }
}