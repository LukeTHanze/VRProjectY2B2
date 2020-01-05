using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObject : MonoBehaviour
{
    /*
     * Figure out if a player has touched an object within the world.
     */

    Renderer rend;

    public int id;

    public Material result, start;

    [Header("Test Option")]
    public bool select;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        rend.material = start;
    }

    private void Update()
    {
        if (select)
        {
            GetComponent<WarpText>().UpdateText("NEW TEXT");
            select = false;
        }
    }

    private void OnTriggerEnter(Collider other) // works with OnCollisionEnter also
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Touched box");

            select = true;

            //disable object for next branch
           
            //rend.material = result;
            // play animtion?
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rend.material = start;
        }
    }
    */
}
