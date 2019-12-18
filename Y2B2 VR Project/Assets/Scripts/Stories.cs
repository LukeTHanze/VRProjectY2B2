using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Story", menuName = "New Story")]
public class Stories : ScriptableObject
{
    /*
     * 
     * TODO
     * 
     */
    [Header("Identity")]
    public float id; // isnt required, only used if we need to check for a particular story

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

}

