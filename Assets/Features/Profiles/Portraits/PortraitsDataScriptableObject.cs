using System.Linq;
using UnityEngine;

namespace Features.Profiles
{
    [CreateAssetMenu(menuName = "Profiles/Create PortraitsData Scriptable Object", fileName = "Portraits", order = 0)]
    public class PortraitsDataScriptableObject: ScriptableObject
    {
        public PortraitData[] Portraits;

        public PortraitData Get(PortraitEnum portrait) => Portraits.FirstOrDefault(x => x.Portrait == portrait);
    }
}