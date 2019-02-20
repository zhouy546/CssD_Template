using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineCtr : MonoBehaviour
{
    public PlayableDirector playableDirector;

    public List<PlayableAsset> playableAsset = new List<PlayableAsset>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show() {
        playableDirector.Play(playableAsset[0]);

    }

    public void Hide() {
        playableDirector.Play(playableAsset[1]);

    }
}
