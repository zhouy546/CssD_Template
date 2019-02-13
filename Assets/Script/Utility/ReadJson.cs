using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using System.IO;

using LitJson;


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
            SetupNodeList(i, ref ValueSheet.NodeList, "information");

        }

        for (int j = 0; j < itemDate["ScreenProtectVideoPath"].Count; j++)
        {
            string videoPath = itemDate["ScreenProtectVideoPath"][j]["VideoPath"].ToString();
            ValueSheet.ScreenProtectPath.Add(videoPath);
        }


    }

    void SetupNodeList(int i, ref List<Node> nodes, string SectionStr)
    {
        int id;
        string MainTitle;
        string VideoPath;
        string ImagePath;

        id = int.Parse(itemDate[SectionStr][i]["id"].ToString());//get id;

        MainTitle = itemDate[SectionStr][i]["BigTitle"].ToString();//get bigtitle;

        VideoPath = itemDate[SectionStr][i]["VideoPath"].ToString();//get video path;

        ImagePath = itemDate[SectionStr][i]["ImagePath"].ToString();

        Node temp = new Node(id, MainTitle, VideoPath, ImagePath);

        createUI.CreateMainUI(temp);
    }
}
