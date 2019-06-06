using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BarNodeCtr : MonoBehaviour,IPointerClickHandler
{
    public Text MainTitle;
    public Image DisplayImg;

    public Color HeighLightColor, DeHeighLightColor;

    public bool IsHeighlight;

    public bool isDisplayYears;

    public string Years;

    public int ID;

    public bool isVideo;

    public GameObject YearsObj;

    public GameObject VideoUi;
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

        if (ID == 0)
        {
            IsHeighlight = true;
            HeighLight();
        }
        else {
            IsHeighlight = false;
            DeHeighLight();
        }
    }



    public void setUp(int _ID) {

        if (ValueSheet.dic_id_SpriteOrVideo[_ID].isVideo) {
            SetDisplayImg(ValueSheet.NodeList[_ID].MainImage);
        }
        else{
            SetDisplayImg(ValueSheet.NodeList[_ID].MainImage);

        }

        isDisplayYears = ValueSheet.NodeList[_ID].IsDisplayYears;
        Years = ValueSheet.NodeList[_ID].Years;

        isVideo = ValueSheet.NodeList[_ID].isVideo;
        SetVideoUi(isVideo);
        SetMainTitleStr(Years);
        YearsObj.SetActive(isDisplayYears);
    }

    public void SetVideoUi(bool b) {
        VideoUi.SetActive(b);
    }

    public void SetDisplayImg(Sprite sprite) {
        DisplayImg.sprite = sprite;
    }

    public void SetMainTitleStr(string str) {
        MainTitle.text = str;
    }

    public void HeighLight() {
        DisplayImg.color = HeighLightColor;
    }

    public void DeHeighLight() {
        DisplayImg.color = DeHeighLightColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        EventCenter.Broadcast<int>(EventDefine.ShowBoard, ID);
        EventCenter.Broadcast(EventDefine.resetTimeCountDown);

    }
}
