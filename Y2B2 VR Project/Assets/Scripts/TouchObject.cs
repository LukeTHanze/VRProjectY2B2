using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObject : MonoBehaviour
{
    /*
     * Figure out if a player has touched an object within the world.
     */

    
    [Header("Main")]
    public int id;
    public int storyId;

    [Header("Renderer Options")]
    public Renderer rend;
    public Material result, start;

    [Header("Testing Options")]
    public bool select;

    private GameController gc;
    private Branching br;
    private int location = 1;
    private bool started;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        rend.material = start;

        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        br = GameObject.FindGameObjectWithTag("GameController").GetComponent<Branching>();

        StartCoroutine(WaitForSpawn(0.1f));
        StartCoroutine(FixRotation(0.2f));
    }

    private void Update()
    {
        if (select)
        {
            br.UpdateBranch(id, storyId, location);

            location = br.accessed;
            br.accessed = 0;

            WaitForWake();

            select = false;
        }
    }

    void WaitForWake()
    {
        //gameObject.SetActive(false);
        gameObject.GetComponentInParent<NodeInfo>().play = false;

        transform.eulerAngles = new Vector3(0, 0, 0);
        //StartCoroutine(FixRotation(0.1f));

        GameObject[] TouchSearch = GameObject.FindGameObjectsWithTag("Option");
        for (int i = 0; i < TouchSearch.Length; i++)
        {
            if (TouchSearch[i].GetComponent<TouchObject>().storyId == storyId)
            {
                if (TouchSearch[i].GetComponent<TouchObject>().id == 1)
                {
                    GetComponent<WarpText>().UpdateText(br.opt1);
                }
                else if (TouchSearch[i].GetComponent<TouchObject>().id == 2)
                {
                    GetComponent<WarpText>().UpdateText(br.opt2);
                }
            }
        }

        StartCoroutine(FixRotation(0.1f));

        //gameObject.SetActive(true);
    }

    IEnumerator WaitForAudio(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.GetComponentInParent<NodeInfo>().play = true;
        //gameObject.SetActive(true);
    }

    IEnumerator FixRotation(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (id == 1)
        {
            // transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.eulerAngles = new Vector3(0, 180, 0); //new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
            gameObject.GetComponentInParent<NodeInfo>().play = true;
        }

        //StartCoroutine(WaitForAudio(1.0f));
    }

    IEnumerator WaitForSpawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (!started)
        {
            SpawnText();
        }
    }

    void SpawnText()
    {
        foreach (Stories story in br.stories)
        {
            if (story.storyID == storyId && story.branchID == 0 && story.nestedBranchID == 0)
            {
                if (id == 1)
                {
                    gameObject.GetComponent<WarpText>().UpdateText(story.option1);
                    started = true;
                }
                else if (id == 2)
                {
                    gameObject.GetComponent<WarpText>().UpdateText(story.option2);
                    started = true;
                }
            }
        }
        started = true;
    }


    private void OnTriggerEnter(Collider other) // works with OnCollisionEnter also
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Touched box");

            select = true;
           
            //rend.material = result;
            // play animtion?
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rend.material = start;
        }
    }
    */
}
