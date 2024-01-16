using System.Collections.Generic;
using TMPro;
using UIComponents;
using UnityEngine;
using UnityEngine.UI;

public class ItemPageController : MonoBehaviour
{
    [SerializeField] private Image _headerImageRef;
    [SerializeField] private TextMeshProUGUI _headerRef;
    [SerializeField] private TextMeshProUGUI _subHeaderRef;
    [SerializeField] private MichelinImages _michelinRef;
    
    [SerializeField] private GameObject _blockPrefab;
    [SerializeField] private GameObject _blocksContainer;

    private readonly List<ItemBlock> _blocks = new List<ItemBlock>(8);

    public void Setup(PageData.HeaderBlock headerSettings, List<ItemBlock.ItemBlockData> dataBlocks)
    {
        _headerImageRef.sprite = headerSettings._backgroundSprite;
        _headerRef.text = headerSettings._headerText;
        _subHeaderRef.text = headerSettings._subHeaderText;
        _michelinRef.ActivateAmount(headerSettings._michelinStars);
        
        foreach (ItemBlock.ItemBlockData blockData in dataBlocks)
        {
            GameObject block = Instantiate(_blockPrefab, _blocksContainer.transform);

            if (block.TryGetComponent(out ItemBlock itemBlock))
            {
                itemBlock.Setup(blockData);
                _blocks.Add(itemBlock);
            }
            else
            {
                Debug.LogWarning("Did not find ItemBlock component!");
            }
        }
        
        foreach (ItemBlock block in _blocks)
        {
            block.Open();
        }
    }

    public void Close()
    {
        foreach (ItemBlock block in _blocks)
        {
            block.Close();
            Destroy(block.gameObject);
        }
        
        _blocks.Clear();
    }
}
