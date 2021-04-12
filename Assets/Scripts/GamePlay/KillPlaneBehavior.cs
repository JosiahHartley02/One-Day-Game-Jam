using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlaneBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PipePairBehavior pipeScript = other.GetComponent < PipePairBehavior>();
        if (pipeScript)
            pipeScript.Destroy();
    }
}
