using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Ini : MonoBehaviour
{
    private ReadJson readJson;
    private BarCanvasCtr canvasCtr;

    private MainUICtr mainUICtr;
    private void Start()
    {

        StartCoroutine(ini());

    }


    IEnumerator ini() {


        readJson = FindObjectOfType<ReadJson>();

        canvasCtr = FindObjectOfType<BarCanvasCtr>();

        mainUICtr = FindObjectOfType<MainUICtr>();

        yield return StartCoroutine(ReadIntroUIsprites());

        List<string> paths = new List<string>(); ;

        paths =LoopAllFile();

        yield return   StartCoroutine( SetupSpriteOrVideoDic(paths));

        //  yield return StartCoroutine(readJson.initialization());

        SetUpNode();



        yield return new WaitForSeconds(1f);

        foreach (var item in ValueSheet.nodeCtrs)
        {
            item.initialization();
        }

        mainUICtr.UpDateTimeLine();


        yield return new WaitForSeconds(5f);
        canvasCtr.initialization();
    }


    void SetUpNode() {

        for (int i = 0; i < ValueSheet.dic_id_SpriteOrVideo.Count; i++)
        {
            SpriteOrVideo spriteOrVideo = ValueSheet.dic_id_SpriteOrVideo[i];

            string s = "\\";
            char[] r = s.ToCharArray();
            char t = r[0];

            string trimstr = (Application.streamingAssetsPath + "/Node/Images/").Replace('/', t);

            char[] trimtext = trimstr.ToCharArray();

            string[] tempstr = spriteOrVideo.Path.Remove(0, trimtext.Length).Split('-');


            if (spriteOrVideo.isVideo)
            {
                string strJpg = ".mp4";
                char[] cha = strJpg.ToCharArray();
                readJson.SetUpNodeList(i, " ", spriteOrVideo.Path, "", tempstr[1], false, tempstr[2], tempstr[3].TrimEnd(cha), spriteOrVideo.sprite,true);
            }
            else {
                string strJpg = ".jpg";
                char[] cha = strJpg.ToCharArray();
                readJson.SetUpNodeList(i, " ", " ", " ", tempstr[1], false, tempstr[2], tempstr[3].TrimEnd(cha), spriteOrVideo.sprite,false);
            } 
        }


        //List<Sprite> tempSprite = new List<Sprite>();

        //foreach (var item in ValueSheet.NodeSprites)
        //{
        //   string[] temp =  item.name.Split('_');

        //    // Debug.Log(temp[0]);
        //    ValueSheet.dic_id_sprite.Add(int.Parse(temp[0]), item);
           
        
        //}

        //string strJpg = ".jpg";
        //char[] cha = strJpg.ToCharArray();


        ////    Debug.Log(ValueSheet.dic_id_sprite[4].name);

        //for (int i = 0; i < ValueSheet.NodeSprites.Count; i++)
        //{
        //    string[] tempstr = ValueSheet.dic_id_sprite[i].name.Split('_');



        

        //}



    }

    IEnumerator ReadIntroUIsprites()
    {
        string path = "/Node/Images/";
        yield return GetSpriteListFromStreamAsset(path, "jpg", ValueSheet.NodeSprites);
    }


    public IEnumerator SetupSpriteOrVideoDic(List<string> paths) {


        string s = "\\";
        char[] r = s.ToCharArray();
        char t = r[0];

        string trimstr = (Application.streamingAssetsPath + "/Node/Images/").Replace('/', t);

        char[] trimtext = trimstr.ToCharArray();

        for (int i = 0; i < paths.Count; i++)
        {
            if (paths[i].Contains(".jpg")){

                //ID

                string[] temp = paths[i].Split('-');
                Debug.Log(paths[i]);
                Debug.Log(temp.Length);

                string idStr = temp[0].Remove(0, trimtext.Length);
         
                int id = int.Parse(idStr);

                //Sprite

                WWW www = new WWW(paths[i]);
                yield return www;

               Texture texture = www.texture;

                Sprite sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

                if (www.isDone)
                {
                    www.Dispose();
                }
                //Create Object
                SpriteOrVideo spriteOrVideo = new SpriteOrVideo(false, paths[i], sprite);

                ValueSheet.dic_id_SpriteOrVideo.Add(id, spriteOrVideo);
            }
            else if(paths[i].Contains(".mp4")) {

                string[] temp = paths[i].Split('-');

                string idStr = temp[0].Remove(0, trimtext.Length);

                int id = int.Parse(idStr);

                SpriteOrVideo spriteOrVideo = new SpriteOrVideo(true, paths[i]);

                ValueSheet.dic_id_SpriteOrVideo.Add(id, spriteOrVideo);
            }
        }
    }

    IEnumerator GetSpriteListFromStreamAsset(string path, string suffix, List<Sprite> sprites)
    {
        List<Texture> texturesList = new List<Texture>();
        string streamingPath = Application.streamingAssetsPath + path;
        DirectoryInfo dir = new DirectoryInfo(streamingPath);

        //Debug.Log(dir);

        GetAllFiles(dir, path, suffix, jpgName);

        foreach (string de in jpgName)
        {
      
            WWW www = new WWW(Application.streamingAssetsPath + path + de);
            yield return www;
            if (www != null)
            {
                Texture texture = www.texture;
                texture.name = de;
                texturesList.Add(texture);
            }
            if (www.isDone)
            {
                www.Dispose();
            }
        }

        foreach (var texture in texturesList)
        {
            Sprite sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            sprite.name = texture.name;
            sprites.Add(sprite);
        }

        jpgName.Clear();
    }

    List<string> jpgName = new List<string>();

    public void GetAllFiles(DirectoryInfo dir, string Filepath, string suffix,List<string> fileName)
    {
        FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();   //初始化一个FileSystemInfo类型的实例
        foreach (FileSystemInfo i in fileinfo)              //循环遍历fileinfo下的所有内容
        {
            if (i is DirectoryInfo)             //当在DirectoryInfo中存在i时
            {
                GetAllFiles((DirectoryInfo)i, Filepath, suffix, fileName);  //获取i下的所有文件
            }
            else
            {
                
                string str = i.FullName;        //记录i的绝对路径
                string path = Application.streamingAssetsPath + Filepath;
                string strType = str.Substring(path.Length);

                if (strType.Substring(strType.Length - 3).ToLower() == suffix)
                {
                    if (fileName.Contains(strType))
                    {
                    }
                    else
                    {
                        //  Debug.Log(strType);
                        fileName.Add(strType);
                    }
                }
            }
        }
    }


    List<string>  LoopAllFile() {

        List<string> temp = new List<string>();
        List<string> newtemp = new List<string>();

        string path = Application.streamingAssetsPath +  "/Node/Images/";

        DirectoryInfo folder = new DirectoryInfo(path);

        foreach (FileInfo file in folder.GetFiles(/*"*.txt"*/))
        {
            temp.Add(file.FullName);
        }


      
        foreach (var str in temp)
        {
            if (str.Contains(".meta"))
            {

            }
            else {
                newtemp.Add(str);
            }
        }

        return newtemp;
    }
}

public class SpriteOrVideo {
    public bool isVideo;
    public Sprite sprite;
    public string Path;

    public SpriteOrVideo(bool _isVideo, string _path,Sprite _sprite = null) {
        isVideo = _isVideo;
        sprite = _sprite;
        Path = _path;
    }
}
