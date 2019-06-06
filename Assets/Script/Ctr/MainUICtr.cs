using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUICtr : ICtr
{
   
    // Start is called before the first frame update
    void Start()
    {

        EventCenter.AddListener<int>(EventDefine.ShowBoard, ShowBoard);


    }

    public void UpDateTimeLine() {
        string temp = "";

        foreach (var item in ValueSheet.nodeCtrs)
        {
            if (temp != item.Node.Years) {
                item.Node.IsDisplayYears = true;
                temp = item.Node.Years;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowBoard(int id) {
       // Debug.Log(id);
        if (id != ValueSheet.currentDisplayID) {


            ValueSheet.barNodeCtrs[ValueSheet.currentDisplayID].DeHeighLight();


            if (id > ValueSheet.currentDisplayID)
            {
                ValueSheet.nodeCtrs[ValueSheet.currentDisplayID].hide(MoveDirection.Feft_To_Right);

                ValueSheet.nodeCtrs[id].show(MoveDirection.Feft_To_Right);

            }
            else {
                ValueSheet.nodeCtrs[ValueSheet.currentDisplayID].hide(MoveDirection.Right_to_Left);

                ValueSheet.nodeCtrs[id].show(MoveDirection.Right_to_Left);
            }



            ValueSheet.currentDisplayID = id;

            ValueSheet.barNodeCtrs[ValueSheet.currentDisplayID].HeighLight();
        }
    }



}
