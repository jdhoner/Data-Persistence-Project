using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public string[] animals = { "cats", "dogs", "elephants", "zebra", "tiger", "hippo" };



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RankAnimals());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RankAnimals()
    {

        yield return new WaitForSeconds(2);
        System.Array.Sort(animals);
    }
}
