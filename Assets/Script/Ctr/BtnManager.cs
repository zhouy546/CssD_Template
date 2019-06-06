using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
   // public int currentID = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    int PlusId() {
        int temp;
        temp = ValueSheet.currentDisplayID + 1;
        if (temp< ValueSheet.NodeList.Count)
        {
            return temp;
        }
 
        return ValueSheet.currentDisplayID;
    }

    int MinusID() {
        int temp;
        temp = ValueSheet.currentDisplayID - 1;
        if (temp >= 0)
        {
            return temp;
        }
        return ValueSheet.currentDisplayID;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftBtn() {
        int id = PlusId();
        EventCenter.Broadcast<int>(EventDefine.ShowBoard, id);
        EventCenter.Broadcast(EventDefine.resetTimeCountDown);

    }


    public void RightBtn() {
        int id = MinusID();
        EventCenter.Broadcast<int>(EventDefine.ShowBoard, id);
        EventCenter.Broadcast(EventDefine.resetTimeCountDown);
    }
}
