using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Branching br;
    public int[] branch = { 1, 2, 3, 4 };

    public int whatBranch = 1;

    public int storiesRemaining;
    public int res1, res2, res3, res4;
    public int[] result;

    /*
    public Text option1_1;
    public Text option2_1;

    public Text option1_2;
    public Text option2_2;

    public Text option1_3;
    public Text option2_3;

    public Text option1_4;
    public Text option2_4;
    

    public Image story1, story2, story3, story4;

    public AudioClip audioStory1, audioStory2, audioStory3, audioStory4;
    */

    private void Start()
    {
        br = GetComponent<Branching>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Option 1 selected");
            if(storiesRemaining != 0)
            {
                
                if(storiesRemaining == 1)
                {
                    res1 = 1;
                }
                else if (storiesRemaining == 2)
                {
                    res2 = 1;
                }
                else if (storiesRemaining == 3)
                {
                    res3 = 1;
                }
                else if (storiesRemaining == 4)
                {
                    res4 = 1;
                }
            }
            else
            {
                Debug.Log("UPDATING BRANCH");
                br.UpdateBranch();
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Option 2 selected");
            if (storiesRemaining != 0)
            {
                if (storiesRemaining == 1)
                {
                    res1 = 2;
                }
                else if (storiesRemaining == 2)
                {
                    res2 = 2;
                }
                else if (storiesRemaining == 3)
                {
                    res3 = 2;
                }
                else if (storiesRemaining == 4)
                {
                    res4 = 2;
                }
            }
            else
            {
                Debug.Log("UPDATING BRANCH");
                br.UpdateBranch();
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("No Option selected");
            br.UpdateBranch();
        }
    }

}
