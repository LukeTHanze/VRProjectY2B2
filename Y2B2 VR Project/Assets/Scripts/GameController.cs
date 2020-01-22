using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    /*
     * Most game logic now takes place within branching manager
     */

    Branching br;
    public int[] branch = { 0, 1, 2, 3, 4 };
    public GameObject[] holders;

    //public int whatBranch = 1;
    //public int storiesRemaining;

    public bool InvestigationStarted;

    private void Start()
    {
        br = GetComponent<Branching>();
        br.LoadStories();

        for (int i = 0; i < holders.Length; i++)
        {
            holders[i].active = false;
        }

        float time1 = Random.RandomRange(6f, 22f);
        StartCoroutine(Spawn(holders[0], time1));

        float time2 = Random.RandomRange(6f, 22f);
        StartCoroutine(Spawn(holders[1], time2));

        float time3 = Random.RandomRange(6f, 22f);
        StartCoroutine(Spawn(holders[2], time3));

    }

    IEnumerator Spawn(GameObject toSpawn, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        toSpawn.active = true;
        //Instantiate(toSpawn, new Vector3(0, 0, 0), Quaternion.identity);
    }


}
