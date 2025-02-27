﻿using System;
using Newtonsoft.Json.Serialization;

namespace MusicEventSystem.Configs
{
    public class MusicDataContractResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            JsonContract contract = base.CreateContract(objectType);
            
            if (objectType == typeof(MusicData.NoteMusicData<LongNoteTrackData>))
            {
                contract.Converter = new LongNoteConverter();
            }
            else if(objectType == typeof(MusicData.NoteMusicData<ShortNoteTrackData>))
            {
                contract.Converter = new ShortNoteConverter();
            }
			
            return contract;
        }
    }
}