using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NodeTitleCtr : ICtr
{

    public Text MainTitle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
