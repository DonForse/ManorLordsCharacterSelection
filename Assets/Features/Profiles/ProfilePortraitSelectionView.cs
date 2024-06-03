using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Profiles
{
    public class ProfilePortraitSelectionView : MonoBehaviour
    {
        [SerializeField] private ProfilesDataScriptableObject _profilesDataScriptableObject;
        [Space] [SerializeField] private Image selectedProfileImage;
        [Space] [SerializeField] private Transform profilesContainer;
        [SerializeField] private ProfilePortraitView profileSelectionViewPrefab;
        private List<ProfilePortraitView> _profilesViews;

        private void OnEnable()
        {
            ClearProfileViews();

            _profilesViews = new List<ProfilePortraitView>();
            foreach (var profile in _profilesDataScriptableObject.Profiles)
            {
                var profileView = Instantiate(profileSelectionViewPrefab, profilesContainer);
                profileView.Selected += ProfileSelected;
                profileView.SetData(profile);
                _profilesViews.Add(profileView);
            }

            SetSelectedProfile(_profilesDataScriptableObject.Profiles[0]);
        }

        private void ClearProfileViews()
        {
            if (_profilesViews == null || _profilesViews.Count <= 0) return;
            
            foreach (var profileView in _profilesViews)
            {
                profileView.Selected -= ProfileSelected;
                Destroy(profileView.gameObject);
            }
        }

        private void OnDisable()
        {
            ClearProfileViews();
        }

        private void ProfileSelected(object sender, ProfileData e) => SetSelectedProfile(e);

        private void SetSelectedProfile(ProfileData e)
        {
            selectedProfileImage.sprite = _profilesDataScriptableObject.Get(e.Profile).Portrait;
        }
    }
}