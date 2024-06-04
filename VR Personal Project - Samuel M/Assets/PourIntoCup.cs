using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourIntoCup : MonoBehaviour
{
    public GameObject waterBottle;
    WaterCapacity thisWaterCap;
    // Start is called before the first frame update
    void Start()
    {
        thisWaterCap = waterBottle.GetComponent<WaterCapacity>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay (Collider c)
    {
        if (c.gameObject.CompareTag("Pour"))
        {
            c.gameObject.transform.parent.GetComponent<WaterCapacity>().currentCap += thisWaterCap.drainRate * Time.deltaTime;
        }
    }
}
