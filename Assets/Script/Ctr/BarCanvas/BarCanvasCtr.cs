using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCanvasCtr : ICtr
{
    public PanelCtr panelCtr;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void initialization()
    {
        base.initialization();
        panelCtr.initialization();
        EventCenter.Broadcast(EventDefine.ShowCanvasBar);
    }

    public override void show()
    {
        base.show();
        animator.SetBool("Show", true);

    }

    public override void hide()
    {
        base.hide();
        animator.SetBool("Show", false);

    }

}
