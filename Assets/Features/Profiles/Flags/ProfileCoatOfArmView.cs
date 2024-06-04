using System;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Profiles.Flags
{
    public class ProfileCoatOfArmView : MonoBehaviour
    {
        public event EventHandler<CoatOfArmData> Selected;
        [SerializeField] private Button button;
        [SerializeField] private Image profileImage;
        private CoatOfArmData _coatOfArmData;

        public void SetData(CoatOfArmData data)
        {
            _coatOfArmData = data;
            profileImage.sprite = data.Image;
        }

        private void OnEnable() => button.onClick.AddListener(Clicked);
        private void OnDisable() => button.onClick.RemoveListener(Clicked);
        private void Clicked() => Selected?.Invoke(this, _coatOfArmData);
    }
}
