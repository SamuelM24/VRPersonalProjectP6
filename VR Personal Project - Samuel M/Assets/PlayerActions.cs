using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public bool grounded;
    public float gravityScale;
    public float jumpForce;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!grounded && transform.rotation.y == 180f)
        {
            rb.AddRelativeForce(Vector3.up * 9.81f * gravityScale);
        }
        else if (!grounded && transform.rotation.y == 0f)
        {
            rb.AddRelativeForce(Vector3.down * 9.81f * gravityScale);
        }
        Flip();
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
        }
    }
}
