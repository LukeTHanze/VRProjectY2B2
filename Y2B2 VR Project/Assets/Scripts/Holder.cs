using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public AudioSource dj;
    public AudioClip aclip;

    public GameObject opt1, opt2;
    public GameObject matHolder;

    public Stories stored;

    public float clip; // stand-in
    public float ansTime;

    float startTime;

    public bool trigger;
    public bool selected;
    private bool uwu;
    private bool toKill;

    public AudioClip queuedAudio = null;

    private Branching br;

    [Header("Test")]
    public bool test;
    public Stories newStored;

    void Start()
    {
        br = GameObject.FindGameObjectWithTag("GameController").GetComponent<Branching>();
        dj = gameObject.GetComponentInChildren<AudioSource>();

        
        UpdateClip();
        dj.Play();
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
            stored = newStored;
            test = false;
        }

    }

    /*
    IEnumerator Spawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        UpdateClip();
        dj.Play()
    }*/

    IEnumerator Respawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        queuedAudio = null;
        if (toKill)
            Destroy(gameObject);
        gameObject.GetComponentInChildren<NodeInfo>().Respawn();
    }

    public void AnswerPlay(AudioClip answer, bool kill = false)
    {
        Debug.Log("Answer Audio Clip");
        uwu = false;
        if (kill)
            toKill = true;

        queuedAudio = answer;
        dj.Stop();
        dj.clip = answer;
        if (dj.clip != null)
            ansTime = dj.clip.length;
        else
            ansTime = 2f;
        
    }

    public void UpdateClip()
    {
        Debug.Log("Updated Clip");
        Debug.Log("New Audio Time: " + dj.clip.length);

        if(stored.audio != null)
        {
            dj.clip = stored.audio;
            clip = dj.clip.length;
            dj.Play();
        }

        selected = false;
        trigger = true;
    }

    public void CallBranch(int id)
    {
        br.UpdateBranches(id, stored, gameObject);     
    }

    public void UpdateBlock()
    {
        opt1.GetComponent<WarpText>().UpdateText(stored.option1);
        opt2.GetComponent<WarpText>().UpdateText(stored.option2);

        matHolder.GetComponent<MeshRenderer>().material = stored.mat;
    }

}
