using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadSensor6 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool fits;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cube6")
        {
            fits = true;
            Debug.Log("the 3 is in place");
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.GetComponent<Pickupable>() != null) //If it is a box that has stopped colliding...
        {
            fits = false; //...then reduce the number of colliding objects...
            Debug.Log("its no loger in place");



        }

    }
}
