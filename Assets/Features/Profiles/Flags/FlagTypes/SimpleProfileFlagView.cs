using UnityEngine;
using UnityEngine.UI;

namespace Features.Profiles.Flags.FlagTypes
{
    public class SimpleProfileFlagView : ProfileFlagView
    {
        [SerializeField] private Sprite[] logos;
        [SerializeField] private Image logoImage;
        [SerializeField] private Sprite[] textures;
        [SerializeField] private Image textureImage;
        public override void SetLogo(int logoIndex)
        {
            logoImage.sprite = logos[logoIndex];
        }

        public override void SetTexture(int textureIndex)
        {
            textureImage.sprite = textures[textureIndex];
        }
    }
}