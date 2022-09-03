
using UnityEngine;
using GoogleMobileAds.Api;
using System;



namespace Skript.ADS
{
    public class Ads : MonoBehaviour
{
    private RewardedAd _rewardedAd;
    public InterstitialAd interstitial;
    
    private const string Interstitial_ID = "ca-app-pub-3154374948435241/3357413937"; // Межстраничное объявление
    
    
        
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        

        
    }
    
    
    
    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = Interstitial_ID;
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif
    

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }
    
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
       
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.LoadAdError.GetMessage());
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
     
    }
    
}

}
