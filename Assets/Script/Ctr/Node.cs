using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Node : MonoBehaviour 
{
    public int ID;
    public string MainTitle;
    public string videoPath;
    public string ImagePath;

    public Node(int _ID, string _MainTitle, string _videoPath, string _ImagePath) {
        ID = _ID;
        MainTitle = _MainTitle;
        videoPath = _videoPath;
        ImagePath = _ImagePath;
    }

    public void initialization(int _ID, string _MainTitle, string _videoPath, string _ImagePath) {
        ID = _ID;
        MainTitle = _MainTitle;
        videoPath = _videoPath;
        ImagePath = _ImagePath;
    }
}
