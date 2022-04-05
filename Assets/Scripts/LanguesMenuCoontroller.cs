using UnityEngine;

public class LanguesMenuCoontroller : MonoBehaviour
{
    [SerializeField] GameObject _LanguePanel;

    private void Awake()
    {
        _LanguePanel.SetActive(false);
    }

    public void LanguesButtonSetting()
    {
       _LanguePanel.SetActive(true);
    }
}
