using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public float pickUpRange = 5;
    public float moveForce = 250;
    private GameObject heldObj;
    public Transform heldParent;
    

    // Update is called once per frame
    void OnTriggerStay(Collider coll)
    {
        if (Input.GetKeyDown(KeyCode.F) && coll.tag == "Cube")
        {
            if (heldObj == null)
            {



                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    pickUpObject(hit.transform.gameObject);
                }
            }

            else
            {
                DropObject();
            }
        }

        if(heldObj != null)
        {
            MoveObject();
        }

    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, heldParent.position) > 0.1f)
        {
            Vector3 moveDirection = (heldParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);

        }

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ball")
            if (!heldObj) // if we don't have anything holding
                heldObj = col.gameObject;
    }

    //void OnTriggerExit(Collider col)
    //{
    //    if (col.gameObject.tag == "ball")
    //    {
    //        if (canHold)
    //            ball = null;
    //    }
    //}

    void pickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.parent = heldParent;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        heldObj.transform.parent = null;
        heldObj = null;

    }

}   


