﻿using System;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine;
using static BeatRoyale.CommonPlayerData;
using static Firebase.Auth.FirebaseAuth;

namespace BeatRoyale
{
    public static class Auth
    {
        public static void SignIn(Action onSuccess, Action onError = null)
        {
            var userId = UserId;
            if (string.IsNullOrEmpty(userId))
            {
                var utc = DateTime.UtcNow;
                UserId = $"Y{utc.Year}M{utc.Month}D{utc.Day}h{utc.Hour}m{utc.Minute}s{utc.Second}ms{utc.Millisecond}";
                SignInByEmail(true, onSuccess, onError);
            }
            else if(DefaultInstance.CurrentUser == null)
            {
                SignInByEmail(false, onSuccess, ()=> { SignInByEmail(true, onSuccess, onError); });
            }
            else
            {
                onSuccess();
            }
        }

        private static void SignInByEmail(bool isNewUser, Action onSuccess, Action onError)
        {
            GetTask(isNewUser).ContinueWithOnMainThread(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    Debug.Log($"[{nameof(Auth)}] Sign In. UserId: {UserId}");
                    onSuccess?.Invoke();
                }
                else
                {
                    onError?.Invoke();
                    Debug.LogError($"[{nameof(Auth)}] {task.Exception.Message}");
                }
            });
        }

        private static Task<FirebaseUser> GetTask(bool isNewUser)
        {
            var email = $"{UserId}@beatroyale.com";
            var password = UserId;

            return isNewUser
                ? DefaultInstance.CreateUserWithEmailAndPasswordAsync(email, password)
                : DefaultInstance.SignInWithEmailAndPasswordAsync(email, password);
        }
    }
}