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
    public GameObject Twin;
    public GameObject hParent;
    public AudioSource audios;

    [Header("Renderer Options")]
    public Renderer rend;
    public Material result, start;

    [Header("Testing Options")]
    public bool select;

    private GameController gc;
    private Branching br;
    //private int location = 1;
    private bool started;
    public int block = 0;
    public int block2 = 0;

    private void Start()
    {
        /*
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        rend.material = start;
        */

        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        br = GameObject.FindGameObjectWithTag("GameController").GetComponent<Branching>();

        StartCoroutine(WaitForSpawn(0.1f));
        StartCoroutine(FixRotation(0.2f));
    }

    private void Update()
    {
        if (select)
        {
            WaitForWake();

            gameObject.GetComponentInParent<NodeInfo>().location++;
            gameObject.GetComponentInParent<NodeInfo>().GetComponentInParent<Holder>().selected = true;
            br.accessed = 0;

            block = br.result;
            br.result = 0;

            gameObject.GetComponentInParent<NodeInfo>().GetComponentInParent<Holder>().UpdateClip();

            StartCoroutine(FixRotation(0.1f));

            select = false;
        }
    }

    void WaitForWake()
    {
        // Instead of deactivating the gameobject, move the position to be out of scene.

        gameObject.GetComponentInParent<NodeInfo>().transform.eulerAngles = new Vector3(0, 0, 0);
        gameObject.GetComponentInParent<NodeInfo>().MoveLocation();
        transform.eulerAngles = new Vector3(0, 0, 0);

        br.UpdateBranch(id, storyId, gameObject.GetComponentInParent<NodeInfo>().location, block, block2, gameObject, Twin, audios, hParent, hParent.GetComponent<Holder>().stored);
        if(id == 1)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    IEnumerator WaitForAudio(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.GetComponentInParent<NodeInfo>().play = true;
    }

    IEnumerator FixRotation(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (id == 1)
        {
            // transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.eulerAngles = new Vector3(0, 180, 0);
            Twin.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            Vector3 store = new Vector3(0, 0, 0);
            if(Twin.transform.eulerAngles == store)
            {
                Twin.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                Twin.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            
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
