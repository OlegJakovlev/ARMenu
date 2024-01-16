using System;
using System.Collections.Generic;
using UIComponents;
using UnityEngine;

[CreateAssetMenu(fileName = "PageData", menuName = "ScriptableObjects/PageData", order = 1)]
public class PageData : ScriptableObject
{
    [Serializable]
    public class HeaderBlock 
    {
        public Sprite _backgroundSprite;
        [TextArea] public string _headerText;
        [TextArea] public string _subHeaderText;
        [Range(1, 3)] public int _michelinStars;
    }
        
    public HeaderBlock _headerSettings;
    public List<ItemBlock.ItemBlockData> _dataBlocks;
}