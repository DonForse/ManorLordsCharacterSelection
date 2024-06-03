using System.Collections.Generic;
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

        public void Initialize()
        {
            if (_profilesViews != null && _profilesViews.Count > 0)
            {
                foreach (var profileView in _profilesViews)
                {
                    profileView.Selected -= ProfileSelected;
                }
            }

            _profilesViews = new List<ProfilePortraitView>();
            foreach (var profile in _profilesDataScriptableObject.Profiles)
            {
                var profileView = Instantiate(profileSelectionViewPrefab, profilesContainer);
                profileView.Selected += ProfileSelected;

                _profilesViews.Add(profileView);
            }
        }

        private void ProfileSelected(object sender, ProfileData e)
        {
            selectedProfileImage.sprite = _profilesDataScriptableObject.Get(e.Profile).Portrait;
        }
    }
}