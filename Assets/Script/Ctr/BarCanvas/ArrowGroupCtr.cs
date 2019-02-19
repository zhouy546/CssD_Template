using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ArrowGroupCtr : ICtr,IPointerClickHandler
{
    private bool isDisplay = false;

    public BarCanvasCtr barCanvasCtr;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.ShowCanvasBar, show);
        EventCenter.AddListener(EventDefine.HideCanvasBar, hide);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void show()
    {
        base.show();

        animator.SetBool("Show", true);

        barCanvasCtr.show();
        isDisplay = true;
    }

    public override void hide()
    {
        base.hide();

        animator.SetBool("Show", false);

        barCanvasCtr.hide();
        isDisplay = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isDisplay)
        {

            EventCenter.Broadcast(EventDefine.HideCanvasBar);
        }
        else {


            EventCenter.Broadcast(EventDefine.ShowCanvasBar);
        }
    }
}
