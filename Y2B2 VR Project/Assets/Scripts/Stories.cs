using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Story", menuName = "New Story")]
public class Stories : ScriptableObject
{
    [Header("Identity")]
    public int storyID; // isnt required, only used if we need to check for a particular story
    public int branchID;
    public int nestedBranchID;

    [Header("Foundation")]
    public AudioClip audio; // AudioClip
    public Sprite parallax; // or animation? depending on how we want to do it.

    [Header("Interactables")]
    public string option1;
    public Stories resultOption1;

    public string option2;
    public Stories resultOption2;

    public Stories resultTimer; // time-out option

    [Header("Kill Branch")]
    public bool StartInvestigation;
    public bool KillHere;
    public AudioClip endStatement;

}

