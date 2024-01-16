using System;
using System.Collections.Generic;
using UnityEngine;

namespace UIComponents
{
    [Serializable]
    public class MichelinImages : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _images;

        private void Awake()
        {
            DeactivateAmount(_images.Count);
        }

        public void ActivateAmount(int count)
        {
            if (count > _images.Count) Debug.LogWarning("Trying to activate more than exists!");
            
            for (int i = 0; i < count; i++)
            {
                _images[i].SetActive(true);
            }
        }

        public void DeactivateAmount(int count)
        {
            if (count > _images.Count) Debug.LogWarning("Trying to deactivate more than exists!");
            
            for (int i = count - 1; i > 0; i--)
            {
                _images[i].SetActive(false);
            }
        }
    }
}