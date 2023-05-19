using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    public GameObject arrow;
    public bool ready_shoot; // ready to shoot
   // public CrossBowAttack crossbow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            Debug.Log("arrow on crossbow");
            ready_shoot = true;
        }
    }
}
