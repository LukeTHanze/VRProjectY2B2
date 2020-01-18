using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    [Header("Value Editor")]
    [Range(0.0f, 10.0f)]
    public float speed;
    [Range(0.0f, 1.0f)]
    public float minValue;
    [Range(0.0f, 1.0f)]
    public float maxValue;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Standard");
    }

    void Update()
    {
        float cutOffValue = PingPong(Time.time, minValue, maxValue); //Mathf.PingPong(Time.time / speed, 0.8f); // between 0 <-> 0.8f
        rend.material.SetFloat("_Cutoff", cutOffValue);

    }

    float PingPong(float aValue, float aMin, float aMax)
    {
        return Mathf.PingPong(aValue / speed, aMax - aMin) + aMin;
    }
}
