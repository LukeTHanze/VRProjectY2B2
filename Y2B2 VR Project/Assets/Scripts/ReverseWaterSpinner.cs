using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseWaterSpinner : MonoBehaviour
{

    void Update()
    {
       transform.Rotate(0, -2f * Time.deltaTime, 0, Space.Self);
    }
}
