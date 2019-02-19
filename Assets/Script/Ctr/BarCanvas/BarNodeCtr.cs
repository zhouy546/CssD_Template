using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BarNodeCtr : MonoBehaviour,IPointerClickHandler
{
    public Text MainTitle;
    public Image DisplayImg;

    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initialization(int _ID) {
        ID = _ID;
        setUp(_ID);
    }
    public void setUp(int _ID) {
        SetMainTitleStr(ValueSheet.NodeList[_ID].MainTitle);
        SetDisplayImg(ValueSheet.NodeList[_ID].MainImage);
    }

    public void SetDisplayImg(Sprite sprite) {
        DisplayImg.sprite = sprite;
    }

    public void SetMainTitleStr(string str) {
        MainTitle.text = str;
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        EventCenter.Broadcast<int>(EventDefine.ShowBoard, ID);
        EventCenter.Broadcast(EventDefine.resetTimeCountDown);

    }
}
