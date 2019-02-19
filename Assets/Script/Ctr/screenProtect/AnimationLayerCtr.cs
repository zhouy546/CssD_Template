using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationLayerCtr : ICtr,IPointerClickHandler
{
    public List<BGAnimationCtr> bGAnimationCtrs = new List<BGAnimationCtr>();
    private int currentVideo;

    private bool isInScreenProtect = true;

    public MediaPlayer mediaPlayer;
    private void Awake()
    {
        EventCenter.AddListener(EventDefine.StartScreenProtect, ShowScreenProtect);
        EventCenter.AddListener(EventDefine.LoadPlayScreenProtectVideo, LoadPlayVideo);
        EventCenter.AddListener(EventDefine.HideScreenProtect, hide);
        EventCenter.AddListener(EventDefine.resetTimeCountDown, resetTime);
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Initialization());
    }
    

    private IEnumerator Initialization() {
        yield return new WaitForSeconds(8);

        EventCenter.Broadcast(EventDefine.StartScreenProtect);
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void ShowScreenProtect() {
        StopAllCoroutines();
        StartCoroutine(LoopBGAnimation());
        StartCoroutine(LoopBtnAnimation());
        ShowVideo();
        isInScreenProtect = true;
    }

    private IEnumerator LoopBtnAnimation() {
        EventCenter.Broadcast(EventDefine.BtnShacking);
        yield return new WaitForSeconds(timeRandom(3f,10f));
        StartCoroutine(LoopBtnAnimation());
    }

    private IEnumerator LoopBGAnimation() {
        PlayBGanimation();
        yield return new WaitForSeconds(timeRandom(15f,25f));
        StartCoroutine(LoopBGAnimation());
    }


    private float timeRandom(float min, float max) {
        return Random.Range(min, max);
    }


    private void PlayBGanimation() {
        bGAnimationCtrs[RandomAinmationID()].show();
    }

    private int RandomAinmationID() {
        return Random.Range(0, bGAnimationCtrs.Count);
    }

    public void LoadPlayVideo() {
        string path = ValueSheet.ScreenProtectPath[RandomVideoID()];
        mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, path, true);
    }

    public override void StopVideo() {
        mediaPlayer.Stop();
        mediaPlayer.CloseVideo();
    }

    private int RandomVideoID() {
       
        while (true) {
            int temp = Random.Range(0, ValueSheet.ScreenProtectPath.Count);

            if (temp != currentVideo) {
              
                currentVideo = temp;
                return temp;
            }
        }

    }

    public override void show()
    {
        base.show();
    }

    public override void hide()
    {
        StopAllCoroutines();
        EventCenter.Broadcast(EventDefine.ShowSwitchAnim);
        StartCoroutine(timeCountDown());

        HideVideo();
        isInScreenProtect = false;
    }

    private void HideVideo() {
        StopVideo();
        animator.SetBool("Show", false);
    }

    private void ShowVideo() {

        animator.SetBool("Show", true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (isInScreenProtect)
        {
            EventCenter.Broadcast(EventDefine.HideScreenProtect);
        }

        
    }

    public IEnumerator timeCountDown() {

        if (ValueSheet.currentTimeCountDown >= 1)
        {
            ValueSheet.currentTimeCountDown--;
            yield return new WaitForSeconds(1f);
            StartCoroutine(timeCountDown());
        }
        else {
            EventCenter.Broadcast(EventDefine.StartScreenProtect);

            EventCenter.Broadcast(EventDefine.resetTimeCountDown);
        }
       // Debug.Log(ValueSheet.currentTimeCountDown);
    }

    private void resetTime() {
        ValueSheet.currentTimeCountDown = ValueSheet.TimeCountDown;
    }

}
