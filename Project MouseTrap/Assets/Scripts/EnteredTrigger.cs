using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteredTrigger : MonoBehaviour
{
    public bool triggerFlip;
 
     public void OnTriggerEnter(Collider other)
     {
         if (other.tag == "HidePlace")
            triggerFlip = true;
     }
     public void OnTriggerExit(Collider other)
     {
         if (other.tag == "HidePlace")
            triggerFlip = false;
     }
}
