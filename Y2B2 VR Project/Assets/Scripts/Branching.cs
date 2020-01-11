using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branching : MonoBehaviour
{


    /*
     * Information handler to find out where the story currently is and when to progress it
     */


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
     */

    public Stories[] stories;
    public List<Stories> currentBranch = new List<Stories>(); // 0 <-> 3 - Displayed Stories // 4 <-> 7 - Stored Stories
    public Stories[] newBranch = { null, null, null, null };
    public int accessed;
    public string opt1;
    public string opt2;

    GameController gm;
    

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        stories = Resources.LoadAll<Stories>("Stories");
    }

    
    /*
    public void UpdateBranch()
    {
        currentBranch.Clear();

        if (gm.whatBranch == 1)
        {
            Debug.Log("route 1");
            foreach (Stories story in stories)
            {
                Debug.Log(story.storyID + " - Loaded");
                for (int i = 0; i < gm.branch.Length; i++)
                {
                    if (gm.branch[i] == story.storyID && story.branchID == 0 && story.nestedBranchID == 0)
                    {
                        Debug.Log("I loaded");
                        currentBranch.Add(story);
                        gm.RefreshUI(story, i);
                        gm.storiesRemaining++;
                        Debug.Log(currentBranch[i].storyID + "." + currentBranch[i].branchID + "." + currentBranch[i].nestedBranchID + "." + " - This story is loaded. At [" + i + "]");
                    }
                }
            }
        }
        else if (gm.whatBranch == 2)
        {
            Debug.Log("route 2");
            gm.storiesRemaining = 4;

            for (int i = 0; i < gm.branch.Length; i++)
            {
                gm.RefreshUI(newBranch[i], i);
                Debug.Log(newBranch[i].storyID + "." + newBranch[i].branchID + "." + newBranch[i].nestedBranchID + "." + " - This story is loaded. At [" + i + "]");
            }
        }
        else
        {
            Debug.Log("no stories found");
        }
    }
    */

    public void LoadStories()
    {
        foreach (Stories story in stories)
        {
            for (int i = 0; i < gm.branch.Length; i++)
            {
                if (gm.branch[i] == story.storyID && story.branchID == 0 && story.nestedBranchID == 0)
                {
                    Debug.Log("Loaded: " + story.storyID + "." + story.branchID + "." + story.nestedBranchID);
                    currentBranch.Add(story);
                }
            }
        }
    }

    public void UpdateBranch(int id, int branch, int location)
    {
        for(int i = 0; i < newBranch.Length; i++)
        {
            if(currentBranch[i].storyID == branch)
            {
                if(location == 1)
                {
                    // start
                    Debug.Log("Location: 1 = " + location);

                    // set X.[Y].0
                    if (id == 1)
                    {
                        foreach (Stories story in stories)
                        {
                            if (story.storyID == branch && story.branchID == id && story.nestedBranchID == 0)
                            {
                                Debug.Log("story updated");
                                currentBranch[i] = story;

                                opt1 = story.option1;
                                opt2 = story.option2;

                                accessed = OutputUpdate(location++);
                            }
                        }
                    }
                    else if (id == 2)
                    {
                        foreach (Stories story in stories)
                        {
                            if (story.storyID == branch && story.branchID == id && story.nestedBranchID == 0)
                            {
                                Debug.Log("story updated");
                                currentBranch[i] = story;

                                opt1 = story.option1;
                                opt2 = story.option2;

                                accessed = OutputUpdate(location++);
                            }
                        }
                    }
                    
                }
                else if(location == 2)
                {
                    // center
                    Debug.Log("Location: 2 = " + location);
                    accessed = OutputUpdate(location++);
                }
                else if(location == 3)
                {
                    // end
                    Debug.Log("Location: 3 = " + location);
                    accessed = OutputUpdate(location++);
                }
                else
                {
                    // kill
                }
            }
        }
    }

    public int OutputUpdate(int value)
    {
        value++;
        return value;
    }
}
