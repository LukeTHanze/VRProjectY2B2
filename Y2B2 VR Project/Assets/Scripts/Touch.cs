using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{

    Renderer rend;

    public Material result, start;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        rend.material = start;
    }

    private void OnTriggerEnter(Collider other) // works with OnCollisionEnter also
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Touched box");

            rend.material = result;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rend.material = start;
        }
    }
}
