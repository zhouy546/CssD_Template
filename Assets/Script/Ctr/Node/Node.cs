﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class Node : MonoBehaviour 
{
    public int ID;
    public string MainTitle;
    public string videoPath;
    public string ImagePath;
    public Sprite MainImage;

    public Node(int _ID, string _MainTitle, string _videoPath, string _ImagePath) {
        ID = _ID;
        MainTitle = _MainTitle;
        videoPath = _videoPath;
        ImagePath = _ImagePath;

        //function
        //StartCoroutine(LoadImageSprite(_ImagePath));
    }

    public void initialization(int _ID, string _MainTitle, string _videoPath, string _ImagePath ) {
        ID = _ID;
        MainTitle = _MainTitle;
        videoPath = _videoPath;
        ImagePath = _ImagePath;

        //function
        StartCoroutine(LoadImageSprite(_ImagePath));
    }



    IEnumerator LoadImageSprite(string str)
    {
        string path = Application.streamingAssetsPath + str;

        //请求WWW
        WWW www = new WWW(path);
        yield return www;
        if (www != null && string.IsNullOrEmpty(www.error))
        {
            //获取Texture
            Texture2D texture = www.texture;

            //创建Sprite
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            MainImage = sprite;



        }
    }
}
