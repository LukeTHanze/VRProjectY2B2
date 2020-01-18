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
    public float ansTime;

    float startTime;

    public bool trigger;
    public bool selected;
    private bool uwu;

    public AudioClip queuedAudio = null;

    private Branching br;

    [Header("Test")]
    public bool test;

    // br.UpdateBranch(id, storyId, gameObject.GetComponentInParent<NodeInfo>().location, block, gameObject, Twin); // to fill

    void Start()
    {
        br = GameObject.FindGameObjectWithTag("GameController").GetComponent<Branching>();
        dj = gameObject.GetComponentInChildren<AudioSource>();
        UpdateClip();

        Debug.Log("Playing");
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
            if (clip <= 0 && dj.clip != null && !selected)
            {
                trigger = false;
                if (!selected)
                {
                    br.UpdateBranches(3, stored, gameObject);
                }
                startTime = Random.RandomRange(2f, 15f);
                StartCoroutine(Respawn(startTime));
                Debug.Log("AUDIO CLIP ENDED! w/" + startTime);
            }
            else if (selected && queuedAudio != null)
            {
                if(ansTime <= 0)
                {
                    trigger = false;
                    startTime = Random.RandomRange(2f, 15f);
                    dj.Stop();
                    StartCoroutine(Respawn(startTime));
                }
                else
                {
                    ansTime -= Time.deltaTime;
                }

                if (!dj.isPlaying && !uwu)
                {
                    ansTime = dj.clip.length;
                    dj.Play();
                    uwu = true;
                }

            }
            else if(!selected)
            {
                clip -= Time.deltaTime;
            }
        }

        if (test)
        {
            dj.Play();
            test = false;
        }
    }
    
    IEnumerator Respawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        queuedAudio = null;
        gameObject.GetComponentInChildren<NodeInfo>().Respawn();
    }

    public void AnswerPlay(AudioClip answer)
    {
        Debug.Log("Answer Audio Clip");
        uwu = false;
        queuedAudio = answer;
        dj.Stop();
        dj.clip = answer;
        ansTime = dj.clip.length;
    }

    public void UpdateClip()
    {
        Debug.Log("Updated Clip");
        Debug.Log("New Audio Time: " + dj.clip.length);
        dj.clip = stored.audio;
        clip = dj.clip.length;

        dj.Play();

        selected = false;
        trigger = true;
    }

    public void CallBranch(int id)
    {
        br.UpdateBranches(id, stored, gameObject);
    }

    public void UpdateBlock()
    {
       // dj.clip = stored.audio;
    }
}
