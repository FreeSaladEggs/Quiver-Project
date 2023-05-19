using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class CrossBowAttack : MonoBehaviour
{
    public CrossBow CheckArrow; // access to script if arrow is in crossbow
    Rigidbody rb;
    bool shooted_already = false; // already shooted
    public GameObject Placement; // placement to push arrow
    public GameObject arrowWorld; // arrow real world
    public GameObject arrowInst; // arrow prefab

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      if (CheckArrow.ready_shoot && GetTriggerInput())
         {
             Shoot();
             Debug.Log("Test");
         }

         if(shooted_already)
         {
             shooted_already = false;
             CheckArrow.ready_shoot = false;
             Instantiate(arrowInst,Placement.transform.position,this.transform.rotation);
             //Destroy(GameObject.Find("Arroworld"));
         }
    }

    public bool GetTriggerInput()
    {
        // Check if the left mouse button is pressed
        return Mouse.current.leftButton.isPressed;
    }

    public void Shoot()
    {
        rb.isKinematic = false;
        shooted_already = true;
    }
}
