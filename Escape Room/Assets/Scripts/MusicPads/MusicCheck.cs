using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public MusicPad1 pad1;
    public MusicPad4 pad2;
    public MusicPad5 pad3;
    

    public GameObject youWinText;
    public AudioSource Correctsound;
    public AudioSource Wrongsound;

    public AudioClip wrongSound;
    public AudioClip correctSound;
    // Start is called before the first frame update
    void Start()
    {
        Correctsound = GetComponent<AudioSource>();
        Wrongsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlaySound();
        }

    }

    public void PlaySound()
    {
        if (pad1.fits == true && pad2.fits == true && pad3.fits == true)
        {
            Correctsound.PlayOneShot(correctSound, 1);
            Debug.Log("You got the correct sound");
            youWinText.SetActive(true);
            SceneManager.LoadScene(1);
        }
        if(pad1.fits == false || pad2.fits == false || pad3.fits == false)
        {
            Wrongsound.PlayOneShot(wrongSound, 1);
            Debug.Log("Try again");
        }


        

    }
}
