using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInfo : MonoBehaviour
{
    public int id;
    public bool play;

    private void Update()
    {
        if (!play)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (play)
        {
            transform.Rotate(Vector3.up * 20f * Time.deltaTime);
        }
    }
}
