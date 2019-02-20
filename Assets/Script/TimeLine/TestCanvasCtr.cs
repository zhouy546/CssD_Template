using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCanvasCtr : MonoBehaviour
{
    public List<TimeLineCtr> timeLineCtrs = new List<TimeLineCtr>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            timeLineCtrs[0].Show();
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            timeLineCtrs[0].Hide();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            timeLineCtrs[1].Show();
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            timeLineCtrs[1].Hide();
        }
    }
}
