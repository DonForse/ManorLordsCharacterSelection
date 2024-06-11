using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Features.Profiles.Flags
{
    [Serializable]
    public class CoatOfArmData
    {
        public CoatOfArmEnum CoatOfArm;
        public Sprite Image;
        public ProfileFlagView FlagViewPrefab;
    }
}