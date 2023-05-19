using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{   
    private Rigidbody rb;
    [SerializeField] private float speedArrow;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the shoot direction based on the crossbow's rotation
        Vector3 shootDirection = transform.rotation * Vector3.forward;

        // Apply velocity to the rigidbody in the shoot direction
        rb.velocity = shootDirection * speedArrow;
    }
}
