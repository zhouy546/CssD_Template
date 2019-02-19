using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ini : MonoBehaviour
{
    private ReadJson readJson;
    private BarCanvasCtr canvasCtr;
    private void Start()
    {

        StartCoroutine(ini());

    }


    IEnumerator ini() {
        readJson = FindObjectOfType<ReadJson>();

        canvasCtr = FindObjectOfType<BarCanvasCtr>();

        yield return StartCoroutine(readJson.initialization());





        yield return new WaitForSeconds(5f);
        canvasCtr.initialization();
    }


}
