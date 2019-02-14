using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLayerCtr : MonoBehaviour
{
    public List<BGAnimationCtr> bGAnimationCtrs = new List<BGAnimationCtr>();
    private int currentVideo;

    public MediaPlayer mediaPlayer;
    private void Awake()
    {
        EventCenter.AddListener(EventDefine.StartScreenProtect, ShowScreenProtect);
        EventCenter.AddListener(EventDefine.LoadPlayScreenProtectVideo, LoadPlayVideo);
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(initialization());
    }

    private IEnumerator initialization() {
        yield return new WaitForSeconds(8);

        EventCenter.Broadcast(EventDefine.StartScreenProtect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowScreenProtect() {
        StartCoroutine(LoopBGAnimation());
        StartCoroutine(LoopBtnAnimation());
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

    public void StopVideo() {
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
}
