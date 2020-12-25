using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{

    public GameObject light;
    private bool on = false;
    public GameObject text;
    public GameObject InstructionText;
    public GameObject secondText;

    // Use this for initialization
    void OnTriggerStay(Collider plyr)
    {
        if (plyr.tag == "Player")
        {
            text.SetActive(true);
            InstructionText.SetActive(false);
            secondText.SetActive(false);

            
        }

        if (plyr.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !on)
        {
            light.SetActive(true);
            text.SetActive(false);
            on = true;
        }
        else if (plyr.tag == "Player" && Input.GetKeyDown(KeyCode.E) && on)
        {
            light.SetActive(false);
            text.SetActive(false);
            on = false;
        }
    }
}