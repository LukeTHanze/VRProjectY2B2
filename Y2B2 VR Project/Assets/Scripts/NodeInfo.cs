using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInfo : MonoBehaviour
{
    [Header("Settings")]
    public int id;
    public bool play;

    [Header("Branch Management")]
    public int location = 1;

    [Header("Testing Options")]
    public bool test;


    Vector3 spawn;

    private void Start()
    {
        spawn = transform.position;
    }

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

        if (test)
        {
            Respawn();
            test = false;
        }

        if(location > 4)
        {
            location = 4;
        }
    }

    public void MoveLocation()
    {
        play = false;
        transform.position = new Vector3(-20, 0, 1);
    }

    public void Respawn()
    {
        transform.position = spawn;
        play = true;
    }
}
