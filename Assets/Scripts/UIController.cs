using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _uiContainer;
    [SerializeField] private ItemPageController _pageContainer;

    private void Awake()
    {
        _uiContainer.SetActive(false);
    }

    public void SetupAndOpenPage(PageData data)
    {
        _uiContainer.SetActive(true);
        _pageContainer.Setup(data._headerSettings, data._dataBlocks);
    }

    public void ClosePage()
    {
        _pageContainer.Close();
        _uiContainer.SetActive(false);
    }
}
