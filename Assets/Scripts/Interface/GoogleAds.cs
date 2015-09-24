using UnityEngine;
using GoogleMobileAds.Api;
using System;
using System.Collections;

public class GoogleAds : MonoBehaviour
{
    BannerView bannerView;
    bool canShow = false;
    // Use this for initialization
    void Start()
    {
        RequestBanner();
        //ShowBanner();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //ShowBanner();
        }
    }

    private void RequestBanner()
    {
        print("Requesting banner");
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-7985621142287872/3326776942";
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).Build();
        // Register for ad events.
        bannerView.AdLoaded += HandleAdLoaded;
        bannerView.AdFailedToLoad += HandleAdFailedToLoad;
        bannerView.AdOpened += HandleAdOpened;
        bannerView.AdClosing += HandleAdClosing;
        bannerView.AdClosed += HandleAdClosed;
        bannerView.AdLeftApplication += HandleAdLeftApplication;
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        print("HandleAdLoaded event received.");
        canShow = true;
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleFailedToReceiveAd event received with message: " + args.Message);
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
        print("HandleAdOpened event received");
    }

    void HandleAdClosing(object sender, EventArgs args)
    {
        print("HandleAdClosing event received");
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        print("HandleAdClosed event received");

    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        print("HandleAdLeftApplication event received");
    }

    public void Show()
    {
        StartCoroutine("ShowAsync");
    }

    public void Destroy()
    {
        print("DestroyBanner");
        if (!canShow)
            return;
        bannerView.Hide();
        bannerView.Destroy();
    }

    IEnumerator ShowAsync()
    {
        while (!canShow)
            yield return new WaitForEndOfFrame();

        bannerView.Show();
    }
}
