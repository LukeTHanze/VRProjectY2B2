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
    public int finalID;

    [Header("Foundation")]
    public AudioClip audio; // AudioClip
    public Material mat;

    [Header("Interactables")]
    public string option1;
    public AudioClip answer1;
    public Stories link1;

    public string option2;
    public AudioClip answer2;
    public Stories link2;

    public Stories link3;

    [Header("Investigation")]
    public bool StartInvestigation;
    public bool isInvestigation;

    [Header("Kill Branch 1")]
    public bool KillHere;
    public int[] KillAt;


}

