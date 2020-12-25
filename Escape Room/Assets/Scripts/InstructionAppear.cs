using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionAppear : MonoBehaviour
{
    public GameObject instructionText;
    public GameObject previousText;
    public GameObject secondText;
    // Start is called before the first frame update
    void OnTriggerStay(Collider plyr)
    {
        if (plyr.tag == "Player")
        {
            instructionText.SetActive(true);
            previousText.SetActive(false);
            secondText.SetActive(false);
            


        }
    }
}