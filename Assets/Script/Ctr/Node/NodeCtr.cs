using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MoveDirection {
Feft_To_Right,Right_to_Left,
}


public class NodeCtr : ICtr
{
    public Node Node;

    public NodeCtr NextNodeCtr;
    public NodeCtr PerviousNodeCtr;

    public NodeComponentRef nodeComponentRef;

    private void Start()
    {
        Node = this.GetComponent<Node>();
        animator = this.GetComponent<Animator>();
        nodeComponentRef = this.GetComponent<NodeComponentRef>();
       // initialization();

        if (isFirst())
        {
            show(MoveDirection.Right_to_Left);
        }
        else {
            hide(MoveDirection.Right_to_Left);
        }

        StartCoroutine(LoadMainImage());
    }

    Texture2D texture2D;
    public void Update() {
        if (Input.GetKeyDown(KeyCode.U)&&Node.isVideo) {
  
            
        }
    }

    public override void initialization()
    {
        base.initialization();
        setTitle();
        SetSubTitle();
        SetYears();
        VideoOrSprite();
        StartCoroutine(SetImage());
    }

    public IEnumerator SetImage() {
        yield return new WaitForSeconds(5f);
        if (Node.isVideo) {
            texture2D = nodeComponentRef.mediaPlayer.ExtractFrame(texture2D, 1f);

            Node.MainImage = Sprite.Create(texture2D as Texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);
        }


    }

    public void VideoOrSprite() {
        if (Node.isVideo)
        {
            nodeComponentRef.SpriteCanvas.SetActive(false);
            nodeComponentRef.VideoCanvas.SetActive(true);
            LoadVideo();

    
        }
        else {
            nodeComponentRef.SpriteCanvas.SetActive(true);
            nodeComponentRef.VideoCanvas.SetActive(false);
        }
    }

    public void  LoadVideo() {
        if (Node.isVideo)
        {

            string s = "\\";
            char[] r = s.ToCharArray();
            char t = r[0];
            string path = Node.videoPath.Replace(t,'/');

             bool autoPlay = isFirst();
            nodeComponentRef.mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.AbsolutePathOrURL, path,true);
       
            PlayVideo();
        }
    }

    public override void PlayVideo()
    {
        if (Node.isVideo)
        {
            nodeComponentRef.mediaPlayer.Control.Play();
        }
    }

    public override void StopVideo()
    {
        if (Node.isVideo)
        {
            nodeComponentRef.mediaPlayer.Control.Stop();
            nodeComponentRef.mediaPlayer.CloseVideo();
        }
    }


    public  void hide(MoveDirection dir)
    {
        StopVideo();

        switch (dir)
        {
            case MoveDirection.Feft_To_Right:
                nodeComponentRef.playableDirector.Play(nodeComponentRef.playableAsset[1]);
                break;
            case MoveDirection.Right_to_Left:
                nodeComponentRef.playableDirector.Play(nodeComponentRef.playableAsset[3]);
                break;
            default:
                break;
        }

        //animator.SetBool("Show", false);

        //nodeComponentRef.nodeTitleCtr.hide();
    }

    public  void show(MoveDirection dir)
    {
        LoadVideo();
        Debug.Log(dir);
        PlayVideo();
        switch (dir)
        {
            case MoveDirection.Feft_To_Right:
                nodeComponentRef.playableDirector.Play(nodeComponentRef.playableAsset[0]);
                break;
            case MoveDirection.Right_to_Left:
                nodeComponentRef.playableDirector.Play(nodeComponentRef.playableAsset[2]);
                break;
            default:
                break;
        }
        //animator.SetBool("Show", true);
        //nodeComponentRef.nodeTitleCtr.show();
    }



    public bool isLast() {
        return NextNodeCtr==null?true:false;
    }

    public bool isFirst() {
        return PerviousNodeCtr == null ? true : false;
    }

    public IEnumerator LoadMainImage() {
        yield return new WaitForSeconds(5f);
        nodeComponentRef.MainImage.sprite = Node.MainImage;

    }

    private void setTitle() {
        nodeComponentRef.nodeTitleCtr.MainTitle.text = "园区"+Node.Years;
    }

    private void SetSubTitle() {
        nodeComponentRef.SubtTitleText.text = Node.SubTitle;
    }

    private void SetYears() {
        nodeComponentRef.YearText.text = Node.Years_Date;
    }
}
