using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using System.IO;

using LitJson;
using System;

public class ReadJson : MonoBehaviour
{
    public CreateUI createUI;

    public static ReadJson instance;

    //  public  Ntext ntext;

    private JsonData itemDate;

    private string jsonString;

    public IEnumerator initialization()
    {
        if (instance == null)
        {

            instance = this;

        }

        yield return StartCoroutine(readJson());
    }

    IEnumerator readJson()
    {
        string spath = Application.streamingAssetsPath + "/information.json";

        Debug.Log(spath);

        WWW www = new WWW(spath);

        yield return www;

        jsonString = System.Text.Encoding.UTF8.GetString(www.bytes);

        JsonMapper.ToObject(www.text);

        itemDate = JsonMapper.ToObject(jsonString.ToString());


        for (int i = 0; i < itemDate["information"].Count; i++)

        {
           // SetupNodeList(i, ref ValueSheet.NodeList, "information");

        }

        for (int j = 0; j < itemDate["ScreenProtectVideoPath"].Count; j++)
        {
            string videoPath = itemDate["ScreenProtectVideoPath"][j]["VideoPath"].ToString();
            ValueSheet.ScreenProtectPath.Add(videoPath);
        }


        ValueSheet.currentTimeCountDown = ValueSheet.TimeCountDown = float.Parse( itemDate["Setup"][0]["ScreenProtectTimeCountDown"].ToString());

    }



    public void SetUpNodeList(int _ID, string _MainTitle, string _videoPath, string _ImagePath, string _years, bool _isDisplayYears, string _Years_Date, string _Subtitle, Sprite _sprite,bool _isVideo) {


        Node temp = new Node(_ID, _MainTitle, _videoPath, _ImagePath, _years, _isDisplayYears, _Years_Date, _Subtitle, _sprite, _isVideo);

        createUI.CreateMainUI(temp);
    }

    //private void SetupNodeList(int i, ref List<Node> nodes, string SectionStr)
    //{
    //    int id;
    //    string MainTitle;
    //    string VideoPath;
    //    string ImagePath;
    //    string Years;
    //    string Years_Date;
    //    string subtitle;
        
    //    bool isDisplayYears;


    //    id = int.Parse(itemDate[SectionStr][i]["id"].ToString());//get id;

    //    MainTitle = itemDate[SectionStr][i]["BigTitle"].ToString();//get bigtitle;

    //    VideoPath = itemDate[SectionStr][i]["VideoPath"].ToString();//get video path;

    //    ImagePath = itemDate[SectionStr][i]["ImagePath"].ToString();

    //    Years = itemDate[SectionStr][i]["Years"].ToString();

    //    isDisplayYears = Convert.ToBoolean(itemDate[SectionStr][i]["DisplayYears"].ToString());

    //    Years_Date = itemDate[SectionStr][i]["Date"].ToString();

    //    subtitle = itemDate[SectionStr][i]["SubTitle"].ToString();

    //    Node temp = new Node(id, MainTitle, VideoPath, ImagePath,Years,isDisplayYears,Years_Date, subtitle);

    //    createUI.CreateMainUI(temp);
    //}
}
