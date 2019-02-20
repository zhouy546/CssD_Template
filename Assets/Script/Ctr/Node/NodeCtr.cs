using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        initialization();

        if (isFirst())
        {
            show();
        }
        else {
            hide();
        }

        StartCoroutine(LoadMainImage());
    }

    public override void initialization()
    {
        base.initialization();
        setTitle();
    }

    public override void hide()
    {
        base.hide();


        nodeComponentRef.playableDirector.Play(nodeComponentRef.playableAsset[1]);

        //animator.SetBool("Show", false);

        //nodeComponentRef.nodeTitleCtr.hide();
    }

    public override void show()
    {
        base.show();

        nodeComponentRef.playableDirector.Play(nodeComponentRef.playableAsset[0]);
        //animator.SetBool("Show", true);
        //nodeComponentRef.nodeTitleCtr.show();
    }

    public override void PlayVideo()
    {
        base.PlayVideo();
    }

    public override void StopVideo()
    {
        base.StopVideo();
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
        nodeComponentRef.nodeTitleCtr.MainTitle.text = Node.MainTitle;
    }
}
