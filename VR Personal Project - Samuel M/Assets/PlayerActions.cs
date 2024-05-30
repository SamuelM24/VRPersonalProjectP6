using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerActions : MonoBehaviour
{
    public bool grounded;
    public float gravityScale;
    public float jumpForce;
    public float bufferTimeInit;
    float bufferTime = 0f;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bufferTime -= Time.deltaTime;
        if (transform.rotation.y == 180f)
        {
            rb.AddRelativeForce(-Physics.gravity * (gravityScale + 1));
        }
        else if (transform.rotation.y == 0f)
        {
            rb.AddRelativeForce(-Physics.gravity * (1-gravityScale));
        }   
        if (bufferTime > 0f)
        {
            Flip();
        }

        if (grounded)
        {
            Debug.Log("I'm grounded");
        }
    }

    public void SetBuffer()
    {
        bufferTime = bufferTimeInit;
    }

    public void Flip()
    {
        if (grounded)
        {
            grounded = false;
            transform.Rotate(Vector3.forward * 180f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Floor"))
        {
            grounded = true;
            bufferTime = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Floor"))
        {
            grounded = false;
        }
    }
}
