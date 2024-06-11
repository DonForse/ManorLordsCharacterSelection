using System;
using System.Collections.Generic;
using Features.Profiles.Flags;
using UnityEngine;


public class ItemsSelection : MonoBehaviour
{
    public event EventHandler<int> ItemSelected;

    [SerializeField] private Sprite[] textures;
    [SerializeField]private Transform itemsContainer;

    [SerializeField] private Selectable<int> IntSelectablePrefab;
    private readonly List<Selectable<int>> _selectables = new();

    private void OnEnable()
    {
        ClearProfileViews();

        for (int i = 0; i < textures.Length; i++)
        {
            var selectable = Instantiate(IntSelectablePrefab, itemsContainer);
            selectable.Set(i, textures[i]);
            selectable.Selected += OnSelected;
            _selectables.Add(selectable);
        }
    }

    private void ClearProfileViews()
    {
        if (_selectables == null || _selectables.Count <= 0) return;

        foreach (var profileView in _selectables)
        {
            profileView.Selected -= OnSelected;
            Destroy(profileView.gameObject);
        }
    }

    private void OnDisable()
    {
        ClearProfileViews();
    }

    private void OnSelected(object sender, int e)
    {
        ItemSelected?.Invoke(this, e);
    }
}