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
    public Stories investigation;
    public List<Stories> currentBranch = new List<Stories>(); // 0 <-> 3 - Displayed Stories // 4 <-> 7 - Stored Stories with canvas version
    public  List<Stories> storedBranch = new List<Stories>();
    //public Stories[] newBranch = { null, null, null, null };
    public int accessed;
    public int result, result2;

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

    public void UpdateBranches(int id, Stories storedStory, GameObject holder)
    {
        foreach(Stories story in stories)
        {
            if (story == storedStory)
            {
                if (!story.KillHere && !story.StartInvestigation)
                {
                    switch (id)
                    {
                        case 1:
                            holder.GetComponent<Holder>().stored = story.link1;
                            holder.GetComponent<Holder>().AnswerPlay(story.answer1);
                            holder.GetComponent<Holder>().UpdateBlock();
                            Debug.Log("Case " + id);
                            break;
                        case 2:
                            holder.GetComponent<Holder>().stored = story.link2;
                            holder.GetComponent<Holder>().AnswerPlay(story.answer2);
                            holder.GetComponent<Holder>().UpdateBlock();
                            Debug.Log("Case " + id);
                            break;
                        case 3:
                            holder.GetComponent<Holder>().stored = story.link3;
                            holder.GetComponent<Holder>().UpdateBlock();
                            Debug.Log("Case " + id);
                            break;
                        default:
                            Debug.Log("Invalid ID");
                            break;
                    }
                }
                else
                {
                    switch (id)
                    {
                        case 1:
                            bool noresult = false;
                            bool breakloop = false;
                            if (!noresult)
                            {
                                if (!breakloop)
                                {
                                    for (int i = 0; i < story.KillAt.Length; i++)
                                    {
                                        if (story.KillAt[i] == 1)
                                        {
                                            // kill
                                            if (!story.IsPart2)
                                            {
                                                holder.GetComponent<Holder>().AnswerPlay(story.answer1, true);
                                                Debug.Log("Killing");
                                                breakloop = true;
                                                break;
                                            }
                                            else
                                            {
                                                // portal 1
                                                // just spawn ??
                                                holder.GetComponent<Holder>().AnswerPlay(story.answer1, true);

                                                Debug.Log("Killing for " + id);
                                                breakloop = true;
                                                break;
                                            }
                                        }
                                    }

                                    if (!breakloop)
                                    {
                                        for (int j = 0; j < story.SI.Length; j++)
                                        {
                                            if (story.SI[j] == 1 && story.StartInvestigation)
                                            {
                                                // investigation
                                                if (!gm.InvestigationStarted)
                                                {
                                                    Debug.Log("Investigation");
                                                    holder.GetComponent<Holder>().stored = investigation;
                                                    holder.GetComponent<Holder>().AnswerPlay(story.answer1);
                                                    holder.GetComponent<Holder>().UpdateBlock();
                                                    gm.InvestigationStarted = true;
                                                    breakloop = true;
                                                    break;
                                                }
                                                else if (gm.InvestigationStarted)
                                                {
                                                    // kill
                                                    holder.GetComponent<Holder>().AnswerPlay(story.answer1, true);

                                                    Debug.Log("Killing");
                                                    breakloop = true;
                                                    break;
                                                }
                                            }
                                        }

                                        if (!breakloop)
                                        {
                                            holder.GetComponent<Holder>().stored = story.link1;
                                            holder.GetComponent<Holder>().AnswerPlay(story.answer1);
                                            holder.GetComponent<Holder>().UpdateBlock();
                                            Debug.Log("Case " + id);
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                        case 2:
                            bool noresult2 = false;
                            bool breakloop2 = false;
                            if (!noresult2)
                            {

                                if (!breakloop2)
                                {
                                    for (int i = 0; i < story.KillAt.Length; i++)
                                    {
                                        if (story.KillAt[i] == 2)
                                        {
                                            // kill
                                            holder.GetComponent<Holder>().AnswerPlay(story.answer2, true);
                                            breakloop2 = true;
                                            break;
                                        }
                                    }

                                    if (!breakloop2)
                                    {
                                        for (int j = 0; j < story.SI.Length; j++)
                                        {
                                            if (story.SI[j] == 2 && story.StartInvestigation)
                                            {
                                                // investigation
                                                if (!gm.InvestigationStarted)
                                                {
                                                    Debug.Log("Investigation");
                                                    holder.GetComponent<Holder>().stored = investigation;
                                                    holder.GetComponent<Holder>().AnswerPlay(story.answer2);
                                                    holder.GetComponent<Holder>().UpdateBlock();
                                                    gm.InvestigationStarted = true;
                                                    breakloop2 = true;
                                                    break;
                                                }
                                                else if (gm.InvestigationStarted)
                                                {
                                                    // kill
                                                    holder.GetComponent<Holder>().AnswerPlay(story.answer2, true);
                                                    Debug.Log("Killing");
                                                    breakloop2 = true;
                                                    break;
                                                }
                                            }
                                        }

                                        if (!breakloop2)
                                        {
                                            holder.GetComponent<Holder>().stored = story.link2;
                                            holder.GetComponent<Holder>().AnswerPlay(story.answer2);
                                            holder.GetComponent<Holder>().UpdateBlock();
                                            Debug.Log("Case " + id);
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                        case 3:
                            bool noresult3 = false;
                            bool breakloop3 = false;
                            if (!noresult3)
                            {

                                if (!breakloop3)
                                {
                                    for (int i = 0; i < story.KillAt.Length; i++)
                                    {
                                        if (story.KillAt[i] == 3)
                                        {
                                            // kill
                                            Debug.Log("Killed");
                                            Destroy(holder);
                                            breakloop3 = true;
                                            break;
                                        }
                                    }

                                    if (!breakloop3)
                                    {
                                        for (int j = 0; j < story.SI.Length; j++)
                                        {
                                            if (story.SI[j] == 3 && story.StartInvestigation)
                                            {
                                                // investigation
                                                if (!gm.InvestigationStarted)
                                                {
                                                    Debug.Log("Investigation");
                                                    holder.GetComponent<Holder>().stored = investigation;
                                                    holder.GetComponent<Holder>().UpdateBlock();
                                                    gm.InvestigationStarted = true;
                                                    breakloop3 = true;
                                                    break;
                                                }
                                                else if (gm.InvestigationStarted)
                                                {
                                                    // kill
                                                    Destroy(holder);
                                                    Debug.Log("Killing");
                                                    breakloop3 = true;
                                                    break;
                                                }
                                            }
                                        }

                                        if (!breakloop3)
                                        {
                                            holder.GetComponent<Holder>().stored = story.link3;
                                            holder.GetComponent<Holder>().UpdateBlock();
                                            Debug.Log("Case " + id);
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                        default:
                            Debug.Log("Invalid ID");
                            break;
                    }
                }
            }
        }
    }

    /*
     * Branching Version two - bugged with answer calls & image updates [slower speeds]
     * 
    public void UpdateBranch(int id, int branch, int location, int block, int block2, GameObject main, GameObject twin, AudioSource audios, GameObject holder, Stories storedStory)
    {
        for(int i = 0; i < currentBranch.Count; i++)
        {
            if(currentBranch[i].storyID == branch)
            {
                if (location == 1)
                { 
                    // set X.[Y].0
                    if (id == 1)
                    {
                        foreach (Stories story in stories)
                        {
                            if (story.storyID == branch && story.branchID == id && story.nestedBranchID == 0 && story.finalID == 0)
                            {
                                holder.GetComponent<Holder>().AnswerPlay(storedStory.answer1);
                                Debug.Log("story updated");
                                holder.GetComponent<Holder>().stored = story;
                                holder.GetComponent<Holder>().test = true;
                                main.GetComponent<WarpText>().UpdateText(story.option1);
                                twin.GetComponent<WarpText>().UpdateText(story.option2);

                                audios.clip = story.audio;

                                result = 1;
                                accessed = location++;
                            }
                        }
                    }
                    else if (id == 2)
                    {
                        foreach (Stories story in stories)
                        {
                            

                            if (story.storyID == branch && story.branchID == id && story.nestedBranchID == 0 && story.finalID == 0)
                            {
                                holder.GetComponent<Holder>().AnswerPlay(storedStory.answer1);
                                Debug.Log("story updated");
                                holder.GetComponent<Holder>().stored = story;

                                main.GetComponent<WarpText>().UpdateText(story.option2);
                                twin.GetComponent<WarpText>().UpdateText(story.option1);

                                audios.clip = story.audio;

                                result = 2;
                                accessed = location++;
                            }
                        }
                    }
                    else if (id == 3)
                    {
                        foreach (Stories story in stories)
                        {
                            if (story.storyID == branch && story.branchID == id && story.nestedBranchID == 0 && story.finalID == 0)
                            {
                                Debug.Log("story updated");
                                storedBranch.Add(story);

                                main.GetComponent<WarpText>().UpdateText(story.option2);
                                twin.GetComponent<WarpText>().UpdateText(story.option1);

                                audios.clip = story.audio;

                                result = 3;
                                accessed = location++;
                            }
                            else if(story.storyID == branch && story.branchID == 0 && story.nestedBranchID == 0 && story.finalID == 0)
                            {
                                if (story.KillHere)
                                {
                                    for (int j = 0;j < story.KillAt.Length;j++)
                                    {
                                        if(story.KillAt[j] == 3)
                                        {
                                            // kill clip
                                            
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if(location == 2)
                {
                    if(id == 1)
                    {
                        foreach (Stories story in stories)
                        {
                            if (story.storyID == branch && story.branchID == block && story.nestedBranchID == id && story.finalID == 0)
                            {
                                Debug.Log("story updated");
                                storedBranch.Add(story);

                                main.GetComponent<WarpText>().UpdateText(story.option1);
                                twin.GetComponent<WarpText>().UpdateText(story.option2);

                                audios.clip = story.audio;

                                result = 1;
                                
                                accessed = location++;
                            }
                        }
                    }
                    else if(id == 2)
                    {
                        foreach (Stories story in stories)
                        {
                            if (story.storyID == branch && story.branchID == block && story.nestedBranchID == id && story.finalID == 0)
                            {
                                Debug.Log("story updated");
                                storedBranch.Add(story);

                                main.GetComponent<WarpText>().UpdateText(story.option2);
                                twin.GetComponent<WarpText>().UpdateText(story.option1);

                                audios.clip = story.audio;

                                result = 2;
                                accessed = location++;
                            }
                        }
                    }
                    
                }
                else if(location == 3)
                {
                    if (id == 1)
                    {
                        foreach (Stories story in stories)
                        {
                            if (story.storyID == branch && story.branchID == block && story.nestedBranchID == id && story.finalID == 0)
                            {
                                Debug.Log("story updated");
                                storedBranch.Add(story);

                                main.GetComponent<WarpText>().UpdateText(story.option1);
                                twin.GetComponent<WarpText>().UpdateText(story.option2);

                                audios.clip = story.audio;

                                result = 1;
                                result2 = 1;
                                accessed = location++;
                            }
                        }
                    }
                    else if (id == 2)
                    {
                        foreach (Stories story in stories)
                        {
                            if (story.storyID == branch && story.branchID == block && story.nestedBranchID == id && story.finalID == 0)
                            {
                                Debug.Log("story updated");
                                storedBranch.Add(story);

                                main.GetComponent<WarpText>().UpdateText(story.option2);
                                twin.GetComponent<WarpText>().UpdateText(story.option1);

                                audios.clip = story.audio;

                                result = 2;
                                result2 = 2;
                                accessed = location++;
                            }
                        }
                    }
                }
                else if (location == 4)
                {
                    if (id == 1)
                    {
                        foreach (Stories story in stories)
                        {
                            if (story.storyID == branch && story.branchID == block && story.nestedBranchID == block2 && story.finalID == id)
                            {
                                Debug.Log("story updated");
                                storedBranch.Add(story);

                                main.GetComponent<WarpText>().UpdateText(story.option1);
                                twin.GetComponent<WarpText>().UpdateText(story.option2);

                                audios.clip = story.audio;

                                result = 1;
                                result2 = 1;
                                accessed = location++;
                            }
                        }
                    }
                    else if (id == 2)
                    {
                        foreach (Stories story in stories)
                        {
                            if (story.storyID == branch && story.branchID == block && story.nestedBranchID == block2 && story.finalID == id)
                            {
                                Debug.Log("story updated");
                                storedBranch.Add(story);

                                main.GetComponent<WarpText>().UpdateText(story.option2);
                                twin.GetComponent<WarpText>().UpdateText(story.option1);

                                audios.clip = story.audio;

                                result = 2;
                                result2 = 2;
                                accessed = location++;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Stories story in stories)
                    {
                        if (story.storyID == branch && story.branchID == block && story.nestedBranchID == block2 && story.finalID == id)
                        {
                            Debug.Log("story updated");
                            storedBranch.Add(story);

                            main.GetComponent<WarpText>().UpdateText("< end >");
                            twin.GetComponent<WarpText>().UpdateText("< end >");

                            audios.clip = story.audio;

                            result = 0;
                            result2 = 0;
                            
                            accessed = location++;
                        }
                    }
                }
            }
        }
    }

    public int OutputUpdate(int value)
    {
        value++;
        return value;
    }
    */
}
