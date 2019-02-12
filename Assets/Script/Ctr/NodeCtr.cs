using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCtr : ICtr
{
   public Node Node;

    public NodeCtr NextNodeCtr;
    public NodeCtr PerviousNodeCtr;

    private void Start()
    {
        initialization();
        Node = this.GetComponent<Node>();
        animator = this.GetComponent<Animator>();
    }

    public override void initialization()
    {
        base.initialization();
    }

    public override void hide()
    {
        base.hide();
    }

    public override void show()
    {
        base.show();
    }

    public override void PlayVideo()
    {
        base.PlayVideo();
    }

    public override void StopVideo()
    {
        base.StopVideo();
    }
}
