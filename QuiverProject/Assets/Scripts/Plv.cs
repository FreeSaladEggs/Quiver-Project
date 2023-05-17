using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class Plv : MonoBehaviour
{
    private XRDeviceSimulator simulator; 
    void Update()
    {
        if (Input.GetAxis("Horizontal")>0)
        {
            transform.Translate(Vector3.up); 
        }
    }
}
