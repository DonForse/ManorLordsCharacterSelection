using System;
using System.Collections.Generic;
using UnityEngine;

namespace Features.Profiles.Flags
{
    public class ProfileFlagSelectionView : MonoBehaviour
    {
        public event EventHandler<CoatOfArmData> CoatOfArmSelected;
        
        [SerializeField] private CoatsOfArmsDataScriptableObject coatsOfArmsDataScriptableObject;
        [Space] [SerializeField] private Transform selectedFlagContainer;
        [Space] [SerializeField] private Transform profileCoatOfArmsContainer;
        [SerializeField] private ProfileCoatOfArmView profileCoatOfArmViewPrefab;
        [SerializeField] private ItemsSelection textureSelection;
        [SerializeField] private ItemsSelection logoSelection;
        
        private List<ProfileCoatOfArmView> _profilesViews;
        private ProfileFlagView _instantiatedFlag;

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
            textureSelection.ItemSelected += OnTextureSelected;
            logoSelection.ItemSelected += OnLogoSelected;

        }

        private void OnLogoSelected(object sender, int e)
        {
            _instantiatedFlag.SetLogo(e);
            // throw new NotImplementedException();
        }

        private void OnTextureSelected(object sender, int e)
        {
            _instantiatedFlag.SetTexture(e);
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
        
        private void SetSelectedCoatOfArm(CoatOfArmData e)
        {
            _instantiatedFlag = null;
            foreach (Transform child in selectedFlagContainer.transform)
            {
                Destroy(child.gameObject);
            }
            
            var coatOfArmData = coatsOfArmsDataScriptableObject.Get(e.CoatOfArm);
            _instantiatedFlag = Instantiate(coatOfArmData.FlagViewPrefab, selectedFlagContainer);
            _instantiatedFlag.SetCoatOfArm(coatOfArmData);
        }
    }
}