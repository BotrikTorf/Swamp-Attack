using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContent;
    [SerializeField] private TMP_Text _moneyBalance;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
            AddItem(_weapons[i]);
    }

    private void OnEnable()
    {
        _player.ChangingCoins += OnMoneyChanges;
        _exitButton.onClick.AddListener(OnButtomClick);
    }

    private void OnDisable()
    {
        _player.ChangingCoins -= OnMoneyChanges;
        _exitButton.onClick.RemoveListener(OnButtomClick);
    }

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_template, _itemContent.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(weapon);
    }

    private void OnSellButtonClick(Weapon weapon, WeaponView view) => TrySellWeapon(weapon, view);

    private void TrySellWeapon(Weapon weapon, WeaponView view)
    {
        if (weapon.Price <= _player.Money)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            view.SellButtonClick -= OnSellButtonClick;
        }
    }

    private void OnMoneyChanges() => _moneyBalance.text = _player.Money.ToString();

    private void OnButtomClick() => gameObject.SetActive(false);
}
