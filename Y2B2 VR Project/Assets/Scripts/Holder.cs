using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public AudioSource dj;
    public AudioClip aclip;

    public GameObject opt1, opt2;

    public Stories stored;

    public float clip; // stand-in
    public float clipTime;

    float startTime;

    public bool trigger;
    public bool selected;

    public AudioClip queuedAudio = null;
    private float newClip;
    private bool startAudio;

    private Branching br;

    [Header("Test")]
    public bool test;

    // br.UpdateBranch(id, storyId, gameObject.GetComponentInParent<NodeInfo>().location, block, gameObject, Twin); // to fill

    void Start()
    {
        br = GameObject.FindGameObjectWithTag("GameController").GetComponent<Branching>();
        dj = gameObject.GetComponentInChildren<AudioSource>();
        UpdateClip();

        dj.Play();

        /*
        aclip = dj.clip;
        Debug.Log("Audio Time: " + aclip.length);
        clip = aclip.length;
        */
    }

    void Update()
    {
        if (trigger)
        {
            if (clip <= 0 && dj.clip != null)
            {
                trigger = false;
                if (!selected)
                {
                    int storyId = gameObject.GetComponentInChildren<NodeInfo>().gameObject.GetComponentInChildren<TouchObject>().storyId;
                    int location = gameObject.GetComponentInChildren<NodeInfo>().location;
                    int block = gameObject.GetComponentInChildren<NodeInfo>().GetComponentInChildren<TouchObject>().block;
                    int block2 = gameObject.GetComponentInChildren<NodeInfo>().GetComponentInChildren<TouchObject>().block2;
                    br.UpdateBranch(3, storyId, location, block, block2, opt1, opt2, dj, gameObject, stored);
                }
                startTime = Random.RandomRange(2f, 15f);
                StartCoroutine(Respawn(startTime));
                Debug.Log("AUDIO CLIP ENDED! w/" + startTime);
                startAudio = false;
                queuedAudio = null;
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

    public void AnswerPlay(AudioClip answer)
    {
        Debug.Log("Answer Audio Clip");
        queuedAudio = answer;
        dj.Stop();
        dj.clip = answer;
        clip = answer.length;
        dj.Play();
    }

    public void UpdateClip()
    {
        if(dj.clip != null)
        {
            aclip = dj.clip;

            Debug.Log("Updated Clip");
            Debug.Log("Audio Time: " + aclip.length);
            clip = aclip.length;

            trigger = true;
            selected = false;
        }
        else
        {
            Debug.Log("E M P T Y  A U D I O  L O G");
        }   
    }
}
