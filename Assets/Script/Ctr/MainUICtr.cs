using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUICtr : ICtr
{
    public int currentDisplayID=0;
    // Start is called before the first frame update
    void Start()
    {

        EventCenter.AddListener<int>(EventDefine.ShowBoard, ShowBoard);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowBoard(int id) {
        if (id != currentDisplayID) {
            ValueSheet.nodeCtrs[currentDisplayID].hide();

            ValueSheet.nodeCtrs[id].show();

            currentDisplayID = id; 
        }
    }



}
