using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CanvasGame : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _buttonAxe;
    [SerializeField] private Button _buttonPistol;
    [SerializeField] private Button _buttonShotgun;

    public event UnityAction<int, int> ChangeState;

    private void OnEnable()
    {
        _player.ChangingCoins += OnChangingCoins;
        _buttonAxe.onClick.AddListener(OnStateAxe);
        _buttonPistol.onClick.AddListener(OnStatePistol);
        _buttonShotgun.onClick.AddListener(OnStateShotgun);
    }

    private void OnDisable()
    {
        _player.ChangingCoins -= OnChangingCoins;
        _buttonAxe.onClick.RemoveListener(OnStateAxe);
        _buttonPistol.onClick.RemoveListener(OnStatePistol);
        _buttonShotgun.onClick.RemoveListener(OnStateShotgun);
    }

    private void OnChangingCoins() => _text.text = _player.Money.ToString();

    private void OnStateAxe() => ChangeState?.Invoke(0, 0);

    private void OnStatePistol() => ChangeState?.Invoke(1, 1);

    private void OnStateShotgun() => ChangeState?.Invoke(1, 2);
}
