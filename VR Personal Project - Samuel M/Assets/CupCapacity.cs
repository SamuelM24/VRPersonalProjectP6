using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupCapacity : MonoBehaviour
{
    public GameObject waterToBeFilled;
    public GameObject pourCollider;
    WaterCapacity thisObjectWater;
    // Start is called before the first frame update
    void Start()
    {
        thisObjectWater = GetComponent<WaterCapacity>();
    }

    // Update is called once per frame
    void Update()
    {
        waterToBeFilled.transform.localScale = (Vector3.right + Vector3.forward) * (4 + (thisObjectWater.currentCap / thisObjectWater.maxCap) * 2f);
        waterToBeFilled.transform.localPosition = Vector3.up * (-0.06f + 10.06f * (thisObjectWater.currentCap / thisObjectWater.maxCap));
        if (thisObjectWater.currentCap <= 0)
        {
            thisObjectWater.currentCap = 0;
            pourCollider.GetComponent<ParticleSystem>().Stop();
        }
    }
}
