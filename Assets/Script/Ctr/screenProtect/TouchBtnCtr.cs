using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchBtnCtr : ICtr
{

    public bool turnOnGlitch;


    public float DistortionAmplitude;


    public float ColorScatterStrength;


    public Image BtnImage;

    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.BtnShacking, show);
        setBtnToIdle();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnOnGlitch) {
            SetGlitch(DistortionAmplitude, ColorScatterStrength);
        }
    }

    public override void show()
    {
        animator.SetTrigger("Show");
    }


    public void SetGlitch(float DistortionAmplitude,float ColorScatterStrength) {
        BtnImage.material.SetFloat("_DistortionAmplitude", DistortionAmplitude);
        BtnImage.material.SetFloat("_ColorScatterStrength", ColorScatterStrength);
    }

    public void setBtnToIdle() {
        SetGlitch(0, 0);
    }
}
