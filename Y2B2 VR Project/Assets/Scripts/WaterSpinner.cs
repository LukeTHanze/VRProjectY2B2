﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpinner : MonoBehaviour
{

    void Update()
    {
       transform.Rotate(0, 10f * Time.deltaTime, 0, Space.Self);
    }
}
