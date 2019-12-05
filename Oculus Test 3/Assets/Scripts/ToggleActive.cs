using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleActive : MonoBehaviour
{
    Toggle Self;
    public GameObject Content;
    public GameObject GObj;
    Image Image;
    public Sprite ActiveSprite;
    public Sprite InActiveSprite;
    Sprite CurrentSprite;

    // Start is called before the first frame update
    void Start()
    {
        Self = GetComponent<Toggle>();
        Self.onValueChanged.AddListener(OnToggleValueChanged);

        Image = GObj.GetComponent<Image>();

        ColorBlock cb = Self.colors;
        cb.normalColor = Content.activeInHierarchy ? Color.white : Color.gray;
        cb.highlightedColor = Content.activeInHierarchy ? Color.white : Color.gray;
        Self.colors = cb;

        //CurrentSprite = Content.activeInHierarchy ? ActiveSprite : InActiveSprite;
        //Image.sprite = CurrentSprite;
    }

    void OnToggleValueChanged(bool IsOn)
    {
        ColorBlock cb = Self.colors;
        cb.normalColor = IsOn ? Color.white : Color.gray;
        cb.highlightedColor = IsOn ? Color.white : Color.gray;
        Self.colors = cb;

        //CurrentSprite = IsOn ? ActiveSprite : InActiveSprite;
        //Image.sprite = CurrentSprite;
    }
}
