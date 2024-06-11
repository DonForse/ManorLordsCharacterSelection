using UnityEngine;
using UnityEngine.UI;

namespace Features.Profiles.Flags
{
    public abstract class ProfileFlagView : MonoBehaviour
    {
        public virtual void SetCoatOfArm(CoatOfArmData coatOfArmData)
        {
         
        }

        public virtual void SetLogo(int logoIndex)
        {
            
        }

        public virtual  void SetTexture(int textureIndex)
        {
        }
    }
}