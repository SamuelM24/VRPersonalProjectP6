using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.Find("CubePlayer"))
        {
            ObstaclesMove[] ob = FindObjectsOfType<ObstaclesMove>();
            foreach (ObstaclesMove ob2 in ob)
            {
                ob2.ObstaclesRestart();
            }

            other.gameObject.transform.position = new Vector3(15, 3, -40);
            other.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}
