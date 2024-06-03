using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Profiles
{
    public class ProfilePortraitSelectionView : MonoBehaviour
    {
        public event EventHandler<PortraitData> ProfileSelected;
        
        [SerializeField] private PortraitsDataScriptableObject portraitsDataScriptableObject;
        [Space] [SerializeField] private Image selectedProfileImage;
        [Space] [SerializeField] private Transform profilesContainer;
        [SerializeField] private ProfilePortraitView profileSelectionViewPrefab;
        private List<ProfilePortraitView> _profilesViews;

        private void OnEnable()
        {
            ClearProfileViews();

            _profilesViews = new List<ProfilePortraitView>();
            foreach (var profile in portraitsDataScriptableObject.Portraits)
            {
                var profileView = Instantiate(profileSelectionViewPrefab, profilesContainer);
                profileView.Selected += OnPortraitSelected;
                profileView.SetData(profile);
                _profilesViews.Add(profileView);
            }

            SetSelectedPortrait(portraitsDataScriptableObject.Portraits[0]);
        }

        private void ClearProfileViews()
        {
            if (_profilesViews == null || _profilesViews.Count <= 0) return;
            
            foreach (var profileView in _profilesViews)
            {
                profileView.Selected -= OnPortraitSelected;
                Destroy(profileView.gameObject);
            }
        }

        private void OnDisable()
        {
            ClearProfileViews();
        }

        private void OnPortraitSelected(object sender, PortraitData e)
        {
            SetSelectedPortrait(e);
            ProfileSelected?.Invoke(this, e);
        }

        private void SetSelectedPortrait(PortraitData e)
        {
            selectedProfileImage.sprite = portraitsDataScriptableObject.Get(e.Portrait).Image;
        }
    }
} 