using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class NodeComponentRef : MonoBehaviour
{
    public Image MainImage;

    public PlayableDirector playableDirector;

    public List<PlayableAsset> playableAsset = new List<PlayableAsset>();

    public NodeTitleCtr nodeTitleCtr;

    public Text SubtTitleText;

    public Text YearText;

    public GameObject VideoCanvas;

    public GameObject SpriteCanvas;

    public MediaPlayer mediaPlayer;
}
