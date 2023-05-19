using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{   
    private Rigidbody rb;
    [SerializeField] private float speedArrow,arrowDammage =20f;
    public CharacterStats charStat;

    // Start is called before the first frame update
    void Start()
    {
        charStat = GameObject.FindGameObjectWithTag("Enemy").GetComponent<CharacterStats>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the shoot direction based on the crossbow's rotation
        Vector3 shootDirection = transform.rotation * Vector3.forward;

        // Apply velocity to the rigidbody in the shoot direction
        rb.velocity = shootDirection * speedArrow;

        if (charStat.maxHealth <= 0)
        {
            Debug.Log("enemy met");
            charStat.Die();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            charStat.maxHealth -= arrowDammage;
            Debug.Log("Enemy Dammaged");
        }
    }
}
