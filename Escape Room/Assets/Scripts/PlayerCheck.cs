using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject instructionText;
    public GameObject previousText;
    public GameObject secondText;
    // Start is called before the first frame update
    void OnTriggerStay(Collider plyr)
    {
        if (plyr.tag == "Player")
        {
            instructionText.SetActive(false);
            previousText.SetActive(false);
            secondText.SetActive(true);



        }
    }
}
