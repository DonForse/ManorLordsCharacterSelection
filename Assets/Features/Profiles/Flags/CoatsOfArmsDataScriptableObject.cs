using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Features.Profiles.Flags
{
    [CreateAssetMenu(menuName = "Profiles/Create CoatsOfArmsDataScriptableObject", fileName = "CoatsOfArms", order = 0)]
    public class CoatsOfArmsDataScriptableObject : ScriptableObject
    {
        public List<CoatOfArmData> CoatsOfArms;

        public CoatOfArmData Get(CoatOfArmEnum coatOfArm) => CoatsOfArms.FirstOrDefault(x => x.CoatOfArm == coatOfArm);
    }
}