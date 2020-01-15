using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public AudioSource dj;
    public AudioClip aclip;

    public float clip; // stand-in
    public float clipTime;

    float startTime;

    public bool trigger;

    private Branching br;

    // br.UpdateBranch(id, storyId, gameObject.GetComponentInParent<NodeInfo>().location, block, gameObject, Twin); // to fill

    void Start()
    {
        br = GameObject.FindGameObjectWithTag("GameController").GetComponent<Branching>();
        dj = gameObject.GetComponentInChildren<AudioSource>();
        aclip = dj.clip;
        Debug.Log("Audio Time: " + aclip.length);
        clip = aclip.length;
    }

    void Update()
    {

        if (clip <= 0)
        {
            startTime = Random.RandomRange(2f, 15f);
            StartCoroutine(Respawn(startTime));
            Debug.Log("AUDIO CLIP ENDED! w/" + startTime);
            trigger = false;
        }
        else
        {
            clip -= Time.deltaTime;
        }

        /*
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
        }*/

    }
    
    IEnumerator Respawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.GetComponentInChildren<NodeInfo>().Respawn();
    }

    public void UpdateClip()
    {
        if(dj.clip != null)
        {
            aclip = dj.clip;

            Debug.Log("Audio Time: " + aclip.length);
            clip = aclip.length;
        }
        else
        {
            Debug.Log("E M P T Y  A U D I O  L O G");
        }
        
    }
}
