using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ValueSheet 
{
    public static Dictionary<int, Sprite> dic_id_sprite = new Dictionary<int, Sprite>();

    public static Dictionary<int, SpriteOrVideo> dic_id_SpriteOrVideo = new Dictionary<int, SpriteOrVideo>();


    public static List<Sprite> NodeSprites = new List<Sprite>();

    public static List<Node> NodeList = new List<Node>();

    public static List<NodeCtr> nodeCtrs = new List<NodeCtr>();

    public static List<BarNodeCtr> barNodeCtrs = new List<BarNodeCtr>();

    public static List<string> ScreenProtectPath = new List<string>();

    public static int currentDisplayID;

    public static float TimeCountDown = 300f;

    public static float currentTimeCountDown =300f;
}
