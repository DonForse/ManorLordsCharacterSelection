using System.Linq;
using UnityEngine;

namespace Features.Profiles
{
    [CreateAssetMenu(menuName = "Profiles/Create ProfilesData Scriptable Object", fileName = "Profiles", order = 0)]
    public class ProfilesDataScriptableObject: ScriptableObject
    {
        public ProfileData[] Profiles;

        public ProfileData Get(ProfileEnum profile) => Profiles.FirstOrDefault(x => x.Profile == profile);
    }
}