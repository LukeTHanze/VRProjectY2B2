using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public float speed;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Standard");
    }

    void Update()
    {
        float cutOffValue = Mathf.PingPong(Time.time / speed, 0.8f);
        rend.material.SetFloat("_Cutoff", cutOffValue);
    }
}
