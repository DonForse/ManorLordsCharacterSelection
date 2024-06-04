using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Profiles
{
    public class ProfilePortraitSelectionView : MonoBehaviour
    {
        public event EventHandler<PortraitData> ProfileSelected;
        public event EventHandler<string> NameUpdated;
        
        [SerializeField] private PortraitsDataScriptableObject portraitsDataScriptableObject;
        [Space] [SerializeField] private Image selectedProfileImage;
        [Space] [SerializeField] private Transform profilesContainer;
        [SerializeField] private ProfilePortraitView profileSelectionViewPrefab;
        [SerializeField] private TMP_InputField nameInput;
        
        private List<ProfilePortraitView> _profilesViews;

        private void OnEnable()
        {
            nameInput.onValueChanged.AddListener(OnNameInputValueChanged);;
            
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
            nameInput.text = portraitsDataScriptableObject.Get(e.Portrait).Name;
        }

        private void OnNameInputValueChanged(string newValue) => NameUpdated?.Invoke(this, newValue);
    }
} 