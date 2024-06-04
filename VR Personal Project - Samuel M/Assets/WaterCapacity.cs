using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCapacity : MonoBehaviour
{
    public float maxCap = 300;
    public float startingCapPercentage = 100;
    public float currentCap;
    public float drainRate;
    public bool draining;
    // Start is called before the first frame update
    void Start()
    {
        currentCap = maxCap * (startingCapPercentage / 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (draining)
        {
            currentCap -= drainRate * Time.deltaTime;
        }
    }

    public void DrainLiquid()
    {
        draining = true;
    }

    public void DrainLiquidStop()
    {
        draining = false;
    }
}
