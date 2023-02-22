using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private void OnEnable() => _player.ChangingCoins += OnChangingCoins;

    private void OnDisable() => _player.ChangingCoins -= OnChangingCoins;

    private void OnChangingCoins() => _text.text = _player.Money.ToString();

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit() => Application.Quit();
}
