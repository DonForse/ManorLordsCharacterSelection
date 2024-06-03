using System;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Profiles
{
    public class ProfilePortraitView : MonoBehaviour
    {
        public event EventHandler<ProfileData> Selected;
        [SerializeField] private Button button;
        [SerializeField] private Image profileImage;
        private ProfileData _profilePortraitData;

        public void SetData(ProfileData data)
        {
            _profilePortraitData = data;
            profileImage.sprite = data.Portrait;
        }

        private void OnEnable() => button.onClick.AddListener(Clicked);
        private void OnDisable() => button.onClick.RemoveListener(Clicked);
        private void Clicked() => Selected?.Invoke(this, _profilePortraitData);
    }
}