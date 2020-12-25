using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPad4 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool fits;
    public AudioSource sound;




    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball")
        {
            sound.Play();

            Debug.Log("Music Pad 4 sound has played");

            if (other.name == "MusicCube2")
            {
                fits = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.GetComponent<Pickupable>() != null) //If it is a box that has stopped colliding...
        {
            fits = false; //...then reduce the number of colliding objects...
            Debug.Log("Sound does not play");



        }

    }
}
