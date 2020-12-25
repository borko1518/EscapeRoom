using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{

    public PadSensor pad1;
    public PadSensor5 pad2;
    public PadSensor6 pad3;
    public PadSensor7 pad4;

    public GameObject wall;
    public AudioSource sounds;
    public AudioClip sound;
    public AudioClip wrong;

    public GameObject WallText; 
    public GameObject WallTextPrev;
    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CheckForSound();
        }
        
    }

    public void CheckForSound()
    {
        if (pad1.fits == true && pad2.fits == true && pad3.fits == true && pad4.fits == true)
        {
            sounds.PlayOneShot(sound, 1);
            wall.SetActive(false);

            Debug.Log("Now you can do level 3");
            


        }
        if (pad1.fits == false || pad2.fits == false || pad3.fits == false || pad4.fits == false)
        {
            sounds.PlayOneShot(wrong, 1);
            WallText.SetActive(true);
            WallTextPrev.SetActive(false);

            Debug.Log(" you can't do level 3");
        }
    }
}
