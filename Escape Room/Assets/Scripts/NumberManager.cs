using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// This handles assigning colours to pads and boxes, and assigning ids to both boxes and pads.
/// </summary>
public class NumberManager : MonoBehaviour
{
    public static NumberManager instance;
    [SerializeField]
    int totalCorrectPlacementsNeed; //This is the total number of boxes that needs to be placed correctly before the door will open.
    [SerializeField]
    int currentCorrectPlacements; //Current number of boxes that are placed on the correct pad
    [SerializeField]
    int placements = 0; //This is overall attempted placements. This increments everytime a box is placed on a pad

    public List<GameObject> pads;
    public List<GameObject> boxes;
    public List<int> possibleNumbers;


    public Text canvasText;

    public UnityEvent completeEvent; //The event you want to call when all boxes are placed. This can be anything. 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        totalCorrectPlacementsNeed = pads.Count; //Set the total number of correct placements needed to be the number of pads in the pads list. 
        currentCorrectPlacements = 0; //Start off with 0 correct placements

        //RandomizeColourList(); //Randomize the colors 
        //AssignColoursToListObjects(pads); //Assign the colors to the pads
        //RandomizeColourList(); //Randomize the colors again
        //AssignColoursToListObjectsBoxes(boxes); //Assign them to the boxes
        ShuffleBoxOrder(); //Shuffle the box order so the same box does not always go on the same box
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Shuffle the colours in the possibleColors list
    /// </summary>
    void RandomizeColourList()
    {
        List<int> tempList = new List<int>();

        for (int i = 0; i < possibleNumbers.Count; i++)
        {
            tempList.Add(possibleNumbers[i]);
        }


        for (int i = 0; i < possibleNumbers.Count; i++)
        {
            int tempint = possibleNumbers[i];
            int randomIndex = UnityEngine.Random.Range(i, possibleNumbers.Count);
            possibleNumbers[i] = possibleNumbers[randomIndex];
            possibleNumbers[randomIndex] = tempint;
        }
    }

    /// <summary>
    /// Goes through the list of objects passed to the function and applies a color from the possibleColors list to it.
    /// </summary>
    /// <param name="objects"></param>
    void AssignColoursToListObjects(List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            
            objects[i].GetComponent<Pad>().padId = possibleNumbers[i];
        }
    }
    void AssignColoursToListObjectsBoxes(List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {

            objects[i].GetComponent<HoldItems>().boxId = possibleNumbers[i];
        }
    }

    /// <summary>
    /// Increase the number of attempted placements
    /// </summary>
    public void IncreasePlacement()
    {
        placements++;

        if (placements == totalCorrectPlacementsNeed) //Update the UI board
        {
            canvasText.text = currentCorrectPlacements.ToString();
        }
    }

    /// <summary>
    /// Decrease the number of attempted placements
    /// </summary>
    public void DecreasePlacement()
    {
        placements--;
    }

    /// <summary>
    /// Increase the number of CORRECT placements
    /// </summary>
    public void IncreaseCorrectPlacements()
    {
        currentCorrectPlacements++;

        if (currentCorrectPlacements == totalCorrectPlacementsNeed)
        {
            Debug.Log("ALL BOXES PLACED CORRECTLY");
            completeEvent.Invoke();
        }
    }

    /// <summary>
    /// Decrease the number of incorrect placements
    /// </summary>
    public void DecreaseCorrectPlacements()
    {
        currentCorrectPlacements--;
    }

    /// <summary>
    /// Shuffles the order of the boxes, and applies an ID to each box
    /// </summary>
    void ShuffleBoxOrder()
    {
        int number = 0;
        for (int i = 0; i < boxes.Count; i++)
        {

            GameObject temp = boxes[i];
            int randomIndex = UnityEngine.Random.Range(i, boxes.Count);
            boxes[i] = boxes[randomIndex];
            boxes[randomIndex] = temp;

            boxes[i].GetComponent<Pickupable>().boxId = number;
            pads[i].GetComponent<Pad>().padId = number;
            number++;

        }
    }

}