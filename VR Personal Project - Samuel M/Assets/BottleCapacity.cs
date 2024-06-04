using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleCapacity : MonoBehaviour
{
    public GameObject waterParticles;
    WaterCapacity thisWaterCap;
    // Start is called before the first frame update
    void Start()
    {
        thisWaterCap = GetComponent<WaterCapacity>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thisWaterCap.currentCap <= 0)
        {
            waterParticles.SetActive(false);
        }
    }
}
