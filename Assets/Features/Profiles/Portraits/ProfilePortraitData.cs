using System;
using UnityEngine;

namespace Features.Profiles
{
    [Serializable]
    public class PortraitData
    {
        public PortraitEnum Portrait;
        public Sprite Image;
        public string Name;
    }
}