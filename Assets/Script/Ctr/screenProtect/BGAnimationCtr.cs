using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAnimationCtr : ICtr
{
    public string AnimationTrigger_Str;
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
        animator.SetTrigger(AnimationTrigger_Str);
    }

    public void LoadPlayVideo() {
        EventCenter.Broadcast(EventDefine.LoadPlayScreenProtectVideo);
    }

}
