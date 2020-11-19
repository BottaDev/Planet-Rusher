using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsController : MonoBehaviour
{
    public AdType currentTypeAds;

    private string type = "";
    private string gameID = "3907101";
    private ShowOptions adCallback;

    void Start()
    {
#if UNITY_ANDROID
        Advertisement.Initialize(gameID, false);
#elif UNITY_EDITOR
        Advertisement.Initialize(gameID, true);
#endif

        adCallback = new ShowOptions();
        adCallback.resultCallback = ResultAds;

        type = currentTypeAds.ToString();
    }


    public void ShowAds()
    {
        if (Advertisement.IsReady())
            Advertisement.Show(type, adCallback);
    }


    void ResultAds(ShowResult resultAds)
    {
        if (resultAds == ShowResult.Finished)
            Debug.Log("User finished viewing the ad");
        else if (resultAds == ShowResult.Skipped)
            Debug.Log("Nos skipped the ad");
        else if (resultAds == ShowResult.Failed)
            Debug.Log("Failed to watch the ad");
    }

    public enum AdType
    {
        video,
        rewardedVideo
    }
}
