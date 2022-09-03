using System;
using UnityEngine;
using GoogleMobileAds.Api;
public class Banner : MonoBehaviour
{
    [HideInInspector]  public BannerView _bannerView;
    
    private const string BANNER_ID = "ca-app-pub-3154374948435241/1613350758"; // Баннер
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        
        RequestBanner();
    }

    public  void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = BANNER_ID;
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif
        

        

        // Create a 320x50 banner at the top of the screen.
        _bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        
        // Called when an ad request has successfully loaded.
        _bannerView.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        _bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        _bannerView.OnAdOpening += HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        _bannerView.OnAdClosed += HandleOnAdClosed;
        
        AdRequest request = new AdRequest.Builder().Build();
        _bannerView.LoadAd(request);

    }

    public void BannerDestroy()
    {
        _bannerView.Destroy();
    }
    
    
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
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
