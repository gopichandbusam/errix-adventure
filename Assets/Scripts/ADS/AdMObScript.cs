using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
// public class AdMObScript : MonoBehaviour
// {
//     InterstitialAd interstitial;
//     string interstitialId;
//     void Start()
//     {
//         MobileAds.Initialize(initStatus => {});
//         RequestInterstitial();
//     }

//     void RequestInterstitial()
//     {

// #if UNITY_ANDROID
//         // interstitialId = "ca-app-pub-3940256099942544/1033173712";
//         interstitialId = "ca-app-pub-9793616844322643/7816189618";
// #elif UNITY_IPHONE
//         // interstitialId = "ca-app-pub-3940256099942544/1033173712";
// #else
//         interstitialId = null;
// #endif
 
//         interstitial = new InterstitialAd(interstitialId);

//         //call events
//         interstitial.OnAdLoaded += HandleOnAdLoaded;
//         interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
//         interstitial.OnAdOpening += HandleOnAdOpened;
//         interstitial.OnAdClosed += HandleOnAdClosed;
//         // interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;


//         //create and ad request
//         if (PlayerPrefs.HasKey("Consent"))
//         {
//             AdRequest request = new AdRequest.Builder().Build();
//             interstitial.LoadAd(request); //load & show the banner ad
//         } else
//         {
//             AdRequest request = new AdRequest.Builder().AddExtra("npa", "1").Build();
//             interstitial.LoadAd(request); //load & show the banner ad (non-personalised)
//         }
//     }

//     //show the ad
//     public void ShowInterstitial()
//     {
//         // MediationTestSuite.Show();
//         MobileAds.Initialize(initStatus => {});
//         RequestInterstitial();
//         if (interstitial.IsLoaded())
//         {
            
//             this.interstitial.Show();
//         }
//     }


//     // events below
//      //events below
//     public void HandleOnAdLoaded(object sender, EventArgs args)
//     {
//         Debug.Log("Ad loaded");
//         this.interstitial.Show();
//         //do this when ad loads
//         // this.interstitial.Show();
//         // MediationTestSuite.Show();
//     }

//     public void HandleOnAdFailedToLoad(object sender, EventArgs args)
//     {
//         Debug.Log("Ad Failed");
//         //do this when ad fails to load
//     }

//     public void HandleOnAdOpened(object sender, EventArgs args)
//     {
//         Debug.Log("Ad Opened");
//         //do this when ad is opened
//     }

//     public void HandleOnAdClosed(object sender, EventArgs args)
//     {
//         Debug.Log("Ad Closed");

//         //do this when ad is closed
//     }

//     public void HandleOnAdLeavingApplication(object sender, EventArgs args)
//     {
//         //do this when on leaving application;
//     }
    
// }

 
public class AdMObScript : MonoBehaviour
{
 
   
    //THE SCRIPT HAS ORIGNAL ID'S OF ADMOB
    InterstitialAd interstitial;
    BannerView bannerView;
    // Use this for initialization
    void Start()
    {
        MobileAds.Initialize(initStatus => {});
 
        RequestBanner();
        RequestInterstitial();
    }
 
 
    public void RequestBanner()
    {
   // replace this id with your orignal admob id for banner ad
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
 
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
        bannerView.OnAdLoaded += HandleOnAdLoaded;
 
    }
 
    void HandleOnAdLoaded(object a, EventArgs args)
    {
        print("loaded");
        bannerView.Show();
        interstitial.Show();
    }
 
 
    public void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        // string adUnitId = "ca-app-pub-9793616844322643/1584681548";
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
 
 
    }
 
    public void show()
    {
        RequestInterstitial();
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }
 
 
}