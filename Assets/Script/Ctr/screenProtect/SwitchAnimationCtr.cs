using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimationCtr : ICtr
{
    
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.ShowSwitchAnim, show);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void show()
    {
        base.show();
        animator.SetTrigger("Show");
    }

    
}
