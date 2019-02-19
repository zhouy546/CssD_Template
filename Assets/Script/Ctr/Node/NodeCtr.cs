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
        initialization();
        Node = this.GetComponent<Node>();
        animator = this.GetComponent<Animator>();
        nodeComponentRef = this.GetComponent<NodeComponentRef>();
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
    }

    public override void hide()
    {
        base.hide();
        animator.SetBool("Show", false);
    }

    public override void show()
    {
        base.show();
        animator.SetBool("Show", true);
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
}
