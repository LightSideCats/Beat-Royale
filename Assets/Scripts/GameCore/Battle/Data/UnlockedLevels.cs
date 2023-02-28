﻿using System.Collections.Generic;
using Core.ConfigModule;

namespace Battle.Data
{
    public class UnlockedLevels : JsonBaseConfigData<UnlockedLevels>
    {
        public Dictionary<string, int> Levels { get; } = new()
        {
            {"Dumbledore", 1}
        };
    }
}