using UnityEngine;

namespace Features.Profiles
{
    public class ProfileSelectionView : MonoBehaviour
    {
        [SerializeField] private ProfilePortraitSelectionView profilePortraitSelectionView;

        private void OnEnable()
        {
            profilePortraitSelectionView.ProfileSelected += OnProfileSelected;
        }

        private void OnProfileSelected(object sender, PortraitData e)
        {
            Debug.Log($"Selected: {e.Portrait}");
        }
    }
}
