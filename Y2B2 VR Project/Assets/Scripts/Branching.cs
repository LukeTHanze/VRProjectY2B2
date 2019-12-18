using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branching : MonoBehaviour
{
    /*
     * 
    [Header("Identity")]
    public float id; // store id

    [Header("Foundation")]
    public AudioClip audio; // AudioClip
    public Image parallax; // or animation? depending on how we want to do it.

    [Header("Interactables")]
    public bool isInteractable = true;
    public string option1;
    public Stories resultOption1;

    public string option2;
    public Stories resultOption2;

    public Stories resultTimer; // time-out option

    [Header("Kill Branch")]
    public bool KillHere;
    public AudioClip endStatement;

     * 
     * check story part X / Y / Z
     * check id
     * 
     * check rest
     * 
     */

    private Stories[] stories;
    public List<Stories> currentBranch = new List<Stories>();
    GameManager gm;


    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }



    /*
     * TODO
     */
    public void UpdateBranch()
    {
        foreach(Stories story in stories)
        {
            if(gm.StoryNumber == story.id)
            {
                currentBranch.Add(story);
            }
        }
    }

}
