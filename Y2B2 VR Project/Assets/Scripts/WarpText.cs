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
     * Leaving out animated text/rotations until after we find out if we're actually going to use it
     */

    public string RoundText = "";
    public float Radius;
    public GameObject TextMeshPrefab;
    public bool create, destroy;

    List<GameObject> prefabs = new List<GameObject>();

    private void Start()
    {
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
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);

            prefabs.Add(Instantiate(TextMeshPrefab, pos, rot));
            char c = RoundText[i];
            prefabs[i].GetComponentInChildren<TextMeshPro>().text = c.ToString();
            ang += 360 / RoundText.Length - 1;
        }
        prefabs[0].transform.rotation = Quaternion.Euler(0, prefabs[0].transform.rotation.y, prefabs[0].transform.rotation.z);
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
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
