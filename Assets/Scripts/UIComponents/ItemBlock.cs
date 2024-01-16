using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace UIComponents
{
    public class ItemBlock : MonoBehaviour
    {
        [Serializable]
        public class ItemBlockData
        {
            [TextArea] public string _blockHeader;
            [TextArea] public string _blockText;
            public VideoClip _video;
        }

        [SerializeField] private TextMeshProUGUI _blockHeaderRef;
        [SerializeField] private TextMeshProUGUI _blockTextRef;
        [SerializeField] private GameObject _videoContainer;
        [SerializeField] private VideoController _videoControllerRef;
        [SerializeField] private Image _imageContainerRef;

        public void Setup(ItemBlockData blockData)
        {
            if (!string.IsNullOrEmpty(blockData._blockHeader))
            {
                _blockHeaderRef.gameObject.SetActive(true);
                _blockHeaderRef.text = blockData._blockHeader;
            }

            if (!string.IsNullOrEmpty(blockData._blockText))
            {
                _blockTextRef.gameObject.SetActive(true);
                _blockTextRef.text = blockData._blockText;
            }

            if (blockData._video != null)
            {
                _videoContainer.gameObject.SetActive(true);
                _videoControllerRef.Setup();
                _videoControllerRef.SetClip(blockData._video);
            }
        }

        public void Open()
        {
            if (_videoContainer.gameObject.activeInHierarchy)
            {
                _videoControllerRef.Play();
            }
        }

        public void Close()
        {
            if (_videoContainer.gameObject.activeInHierarchy)
            {
                _videoControllerRef.Stop();
                _videoControllerRef.Release();
            }
        }
    }
}