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
    public string name; // isnt required, only used if we need to check for a particular story

    [Header("Foundation")]
    public AudioClip audio;
    public Image parallax; // or animation? depending on how we want to do it.
    public int storyPart;

    [Header("Interactables")]
    public bool isInteractable = true;
    public string[] optionText;
    public int[] effectType; // 0 - neutral, 1 - pos, 2 - neg. Etc..

}

