using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpinner : MonoBehaviour
{

    void Update()
    {
       transform.Rotate(10f *Time.deltaTime, 0.0f, 0.0f, Space.Self);
    }
}
