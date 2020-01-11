using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    /*
     * Main controller of events within the game
     * 
     * 
     * TODO:
     * - IEnumarator based on audioclip length
     * - End States
     */
    Branching br;
    public int[] branch = { 0, 1, 2, 3, 4 };

    public int whatBranch = 1;
    public int storiesRemaining;


    // for setting up the options as 3d objects
    public GameObject opt1Obj_1;
    public GameObject opt2Obj_1;

    /*
     
        // For setting up the options as UI Buttons
     
    public Button opt1Btn_1;
    public Button opt2Btn_1;
    public Text option1_1;
    public Text option2_1;

    public Button opt1Btn_2;
    public Button opt2Btn_2;
    public Text option1_2;
    public Text option2_2;

    public Button opt1Btn_3;
    public Button opt2Btn_3;
    public Text option1_3;
    public Text option2_3;

    public Button opt1Btn_4;
    public Button opt2Btn_4;
    public Text option1_4;
    public Text option2_4;

    public Text storyID1, storyID2, storyID3, storyID4;

    public Image story1, story2, story3, story4;

    public AudioClip audioStory1, audioStory2, audioStory3, audioStory4;
    */

    private void Start()
    {
        br = GetComponent<Branching>();
        br.LoadStories();

        //br.UpdateBranch();
        //SetupButtons(); // only needed for Canvas UI version
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Refreshing");
            br.UpdateBranch();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Next Branch");
            whatBranch++;
            br.UpdateBranch();
        }

        if (storiesRemaining <= 0)
        {
            whatBranch++;
            br.UpdateBranch();
        }
        */
    }

    void SetupButtons()
    {
        /*
        Button btn1_1 = opt1Btn_1.GetComponent<Button>();
        Button btn2_1 = opt2Btn_1.GetComponent<Button>();

        Button btn1_2 = opt1Btn_2.GetComponent<Button>();
        Button btn2_2 = opt2Btn_2.GetComponent<Button>();

        Button btn1_3 = opt1Btn_3.GetComponent<Button>();
        Button btn2_3 = opt2Btn_3.GetComponent<Button>();

        Button btn1_4 = opt1Btn_4.GetComponent<Button>();
        Button btn2_4 = opt2Btn_4.GetComponent<Button>();

        btn1_1.onClick.AddListener(delegate { SelectOption(0); });
        btn2_1.onClick.AddListener(delegate { SelectOption2(0); });

        btn1_2.onClick.AddListener(delegate { SelectOption(1); });
        btn2_2.onClick.AddListener(delegate { SelectOption2(1); });

        btn1_3.onClick.AddListener(delegate { SelectOption(2); });
        btn2_3.onClick.AddListener(delegate { SelectOption2(2); });

        btn1_4.onClick.AddListener(delegate { SelectOption(3); });
        btn2_4.onClick.AddListener(delegate { SelectOption2(3); });

    */
    }

    public void RefreshUI(Stories story, int id)
    {
        switch (id)
        {
            case 0:
               /* opt1Obj_1.GetComponent<WarpText>().UpdateText = story.option1;
                option2_1.text = story.option2;
                storyID1.text = "ID: " + story.storyID + "." + story.branchID + "." + story.nestedBranchID;*/
                break;
            default:
                break;
        }
        
                /*
                // Canvas Version
                switch (id)
                {
                    case 0:
                        option1_1.text = story.option1;
                        option2_1.text = story.option2;
                        storyID1.text = "ID: " + story.storyID + "." + story.branchID + "." + story.nestedBranchID;
                        break;
                    case 1:
                        option1_2.text = story.option1;
                        option2_2.text = story.option2;
                        storyID2.text = "ID: " + story.storyID + "." + story.branchID + "." + story.nestedBranchID;
                        break;
                    case 2:
                        option1_3.text = story.option1;
                        option2_3.text = story.option2;
                        storyID3.text = "ID: " + story.storyID + "." + story.branchID + "." + story.nestedBranchID;
                        break;
                    case 3:
                        option1_4.text = story.option1;
                        option2_4.text = story.option2;
                        storyID4.text = "ID: " + story.storyID + "." + story.branchID + "." + story.nestedBranchID;
                        break;
                    default:
                        break;
                }
                */
        }


    /*
     * 
     * Used for delegation when using UI Canvas's instead of gameobjects for selecting options
     * 

    private void SelectOption(int id)
    {
        Debug.Log(id + " Story - Option 1");

        if (whatBranch == 1)
        {
            br.newBranch[id] = br.currentBranch[id].resultOption1;

            storiesRemaining--;
        }
        else
        {
            br.newBranch[id] = br.newBranch[id].resultOption1;

            storiesRemaining--;
        }


        //Stories stored = br.currentBranch[id].resultOption1;

    }

    private void SelectOption2(int id)
    {
        Debug.Log(id + " Story - Option 1");

        br.newBranch[id] = br.currentBranch[id].resultOption2;

        storiesRemaining--;
    }
    */
}
