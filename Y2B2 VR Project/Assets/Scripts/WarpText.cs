using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//[ExecuteInEditMode] // for debugging purposes
public class WarpText : MonoBehaviour
{
    /*
     * 
     * Make text warp around the object it is attatched too
     * 
     * - Must be textmeshpro
     * - Acts on a radius
     * - Font size needs to be changed within a textmeshpro prefab
     * 
     */
    [Header("Attributes")]
    public string RoundText = "";
    public float Radius;
    public GameObject TextMeshPrefab;
    [Header("Testing Options")]
    public bool create, destroy;

    private int _story, _id;
    private Branching br;

    List<GameObject> prefabs = new List<GameObject>();

    private void Start()
    {
        br = GameObject.FindGameObjectWithTag("GameController").GetComponent<Branching>();

        Vector3 center = transform.position;

        CreateText();
    }

    void Update()
    {
        if (create)
        {
            CreateText();
        }

        if (destroy)
        {
            DestoryText();
        }

    }

    void CreateText()
    {
        Vector3 center = transform.position;
        float ang = 0;
        for (int i = 0; i < RoundText.Length; i++)
        {
            Vector3 pos = RandomCircle(center, Radius, ang);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos); ;

            prefabs.Add(Instantiate(TextMeshPrefab, pos, rot, transform.parent = transform));
            char c = RoundText[i];
            prefabs[i].GetComponentInChildren<TextMeshPro>().text = c.ToString();
            ang += -180 / RoundText.Length - 1;

            prefabs[i].transform.rotation = Quaternion.Euler(90, prefabs[i].transform.rotation.y + 90, prefabs[i].transform.rotation.z);

        }
        create = false;
    }

    void DestoryText()
    {
        for (int i = 0; i < prefabs.Count; i++)
        {
            DestroyImmediate(prefabs[i]);
        }
        prefabs = new List<GameObject>();
        destroy = false;
    }

    public void UpdateText(string NewText)
    {
        RoundText = NewText;
        DestoryText();
        CreateText();
    }

    Vector3 RandomCircle(Vector3 center, float radius, float ang)
    {
        Vector3 pos;
        pos.x = center.x + (radius) * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
