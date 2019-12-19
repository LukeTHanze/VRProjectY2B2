﻿using System.Collections;
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
    public List<Stories> currentBranch = new List<Stories>(); // 0 <-> 3 - Displayed Stories // 4 <-> 7 - Stored Stories
    public Stories[] newBranch = { null, null, null, null };


    GameController gm;


    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        stories = Resources.LoadAll<Stories>("Stories");
    }



    /*
     * TODO
     */
    public void UpdateBranch()
    {
        currentBranch.Clear();

        if (gm.whatBranch == 1)
        {
            foreach (Stories story in stories)
            {
                for (int i = 0; i < gm.branch.Length; i++)
                {
                    {
                        if (gm.branch[i] == story.storyID && story.branchID == 0 && story.nestedBranchID == 0)
                        {
                            currentBranch.Add(story);
                            gm.RefreshUI(story, i);
                            gm.storiesRemaining++;
                            Debug.Log(currentBranch[i].storyID + "." + currentBranch[i].branchID + "." + currentBranch[i].nestedBranchID + "." + " - This story is loaded. At [" + i + "]");
                        }
                    }
                }
            }
        }
        else if (gm.whatBranch == 2)
        {
            gm.storiesRemaining = 4;

            for (int i = 0; i < gm.branch.Length; i++)
            {
                gm.RefreshUI(newBranch[i], i);
                Debug.Log(newBranch[i].storyID + "." + newBranch[i].branchID + "." + newBranch[i].nestedBranchID + "." + " - This story is loaded. At [" + i + "]");
            }
        }
    }
}
