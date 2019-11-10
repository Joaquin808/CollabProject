using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleActive : MonoBehaviour
{
    Toggle Self;
    public GameObject Content;

    // Start is called before the first frame update
    void Start()
    {
        Self = GetComponent<Toggle>();
        Self.onValueChanged.AddListener(OnToggleValueChanged);

        ColorBlock cb = Self.colors;
        cb.normalColor = Content.activeInHierarchy ? Color.white : Color.gray;
        cb.highlightedColor = Content.activeInHierarchy ? Color.white : Color.gray;
        Self.colors = cb;
    }

    void OnToggleValueChanged(bool IsOn)
    {
        ColorBlock cb = Self.colors;
        cb.normalColor = IsOn ? Color.white : Color.gray;
        cb.highlightedColor = IsOn ? Color.white : Color.gray;
        Self.colors = cb;
    }
}
