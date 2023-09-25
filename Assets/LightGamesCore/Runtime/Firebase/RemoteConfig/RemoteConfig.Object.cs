﻿using Newtonsoft.Json;

namespace LGCore.Firebase
{
    public partial class RemoteConfig
    {
        public static class Object
        {
            public static T Get<T>(string name, T defaultValue = default) => JsonConvert.DeserializeObject<T>(String.Get(name));
        }
    }
}