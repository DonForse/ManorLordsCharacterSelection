using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Profiles.Flags
{
    public class ProfileFlagSelectionView : MonoBehaviour
    {
        public event EventHandler<CoatOfArmData> CoatOfArmSelected;
        
        [SerializeField] private CoatsOfArmsDataScriptableObject coatsOfArmsDataScriptableObject;
        [Space] [SerializeField] private Image selectedFlag;
        [Space] [SerializeField] private Transform profileCoatOfArmsContainer;
        [SerializeField] private ProfileCoatOfArmView profileCoatOfArmViewPrefab;
        
        private List<ProfileCoatOfArmView> _profilesViews;

        private void OnEnable()
        {
            ClearProfileViews();

            _profilesViews = new List<ProfileCoatOfArmView>();
            foreach (var profile in coatsOfArmsDataScriptableObject.CoatsOfArms)
            {
                var profileCoatOfArmView = Instantiate(profileCoatOfArmViewPrefab, profileCoatOfArmsContainer);
                profileCoatOfArmView.Selected += OnCoatOfArmSelected;
                profileCoatOfArmView.SetData(profile);
                _profilesViews.Add(profileCoatOfArmView);
            }

            SetSelectedCoatOfArm(coatsOfArmsDataScriptableObject.CoatsOfArms[0]);
        }

        private void ClearProfileViews()
        {
            if (_profilesViews == null || _profilesViews.Count <= 0) return;
            
            foreach (var profileView in _profilesViews)
            {
                profileView.Selected -= OnCoatOfArmSelected;
                Destroy(profileView.gameObject);
            }
        }

        private void OnDisable()
        {
            ClearProfileViews();
        }

        private void OnCoatOfArmSelected(object sender, CoatOfArmData e)
        {
            SetSelectedCoatOfArm(e);
            CoatOfArmSelected?.Invoke(this, e);
        }
        
        private void SetSelectedCoatOfArm(CoatOfArmData e) => selectedFlag.sprite = coatsOfArmsDataScriptableObject.Get(e.CoatOfArm).Image;
    }
}
