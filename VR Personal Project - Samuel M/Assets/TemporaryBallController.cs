using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryBallController : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        ball.GetComponent<PlayerActions>().SetBuffer();
    }

    private void OnDisable()
    {
        ball.GetComponent<PlayerActions>().SetBuffer();
    }
}
