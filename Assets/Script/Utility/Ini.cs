using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ini : MonoBehaviour
{
    private ReadJson readJson;

    private void Start()
    {
        readJson = FindObjectOfType<ReadJson>();

        StartCoroutine(readJson.initialization());
        

    }


}
