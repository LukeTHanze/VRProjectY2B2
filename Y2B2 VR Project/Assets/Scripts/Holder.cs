using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    // public AudioClip clip;
    public float clip; // stand-in
    public float clipTime;

    //public float extraTime;
    float startTime;

    public bool trigger;

    private Branching br;

    // br.UpdateBranch(id, storyId, gameObject.GetComponentInParent<NodeInfo>().location, block, gameObject, Twin); // to fill

    void Start()
    {
        br = GameObject.FindGameObjectWithTag("GameController").GetComponent<Branching>();
        clip = clipTime;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(clip.length + extraTime <= 0)
        {
            // hide

            // random time to appear again
            startTime = Random.RandomRange(2f, 15f);
            


        }    */

        if (trigger)
        {
            if (clip <= 0)
            {
                startTime = Random.RandomRange(2f, 15f);
                StartCoroutine(Respawn(startTime));
                clip = clipTime;
                trigger = false;
            }
            else
            {
                clip -= Time.deltaTime;
            }
        }

    }
    
    IEnumerator Respawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.GetComponentInChildren<NodeInfo>().Respawn();
    }
}
