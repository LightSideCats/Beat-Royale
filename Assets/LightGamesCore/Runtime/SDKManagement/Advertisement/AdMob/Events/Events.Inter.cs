﻿using System;
using GoogleMobileAds.Api;

namespace LGCore.SDKManagement.Advertisement.AdMob
{
    public static partial class Events
    {
        public static class Inter
        {
            public static event Action AdClicked;
            public static event Action<AdValue> AdPaid;
            public static event Action AdImpressionRecorded;
            public static event Action AdFullScreenContentClosed;
            public static event Action AdFullScreenContentOpened;
            public static event Action<AdError> AdFullScreenContentFailed;

            public static InterstitialAd Ad
            {
                set
                {
                    value.OnAdClicked += OnAdClicked;
                    value.OnAdPaid += OnAdPaid;
                    value.OnAdImpressionRecorded += OnAdImpressionRecorded;
                    value.OnAdFullScreenContentClosed += OnAdFullScreenContentClosed;
                    value.OnAdFullScreenContentOpened += OnAdFullScreenContentOpened;
                    value.OnAdFullScreenContentFailed += OnAdFullScreenContentFailed;
                }
            }

            private static void OnAdFullScreenContentFailed(AdError obj)
            {
                Burger.Log("[Ads.Events.Inter] OnAdFullScreenContentFailed");
                AdFullScreenContentFailed?.Invoke(obj);
            }

            private static void OnAdFullScreenContentOpened()
            {
                Burger.Log("[Ads.Events.Inter] OnAdFullScreenContentOpened");
                AdFullScreenContentOpened?.Invoke();
            }

            private static void OnAdFullScreenContentClosed()
            {
                Burger.Log("[Ads.Events.Inter] OnAdFullScreenContentClosed");
                AdFullScreenContentClosed?.Invoke();
            }

            private static void OnAdImpressionRecorded()
            {
                Burger.Log("[Ads.Events.Inter] OnAdImpressionRecorded");
                AdImpressionRecorded?.Invoke();
            }

            private static void OnAdPaid(AdValue obj)
            {
                Burger.Log("[Ads.Events.Inter] OnAdPaid");
                AdPaid?.Invoke(obj);
            }

            private static void OnAdClicked()
            {
                Burger.Log("[Ads.Events.Inter] OnAdClicked");
                AdClicked?.Invoke();
            }
        }
    }
}