using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponPanel : MonoBehaviour
{
    [SerializeField] private Button _axeButton;
    [SerializeField] private Button _pistolButton;
    [SerializeField] private Button _gunButton;
    [SerializeField] private Button _uziButton;

    private Axe _axe;
    private Pistol _pistol;
    private Shotgun _shotgun;
    private UZI _uzi;

    public event UnityAction<int, Weapon> ChangeState;

    private void OnEnable()
    {
        _axeButton.onClick.AddListener(OnStateAxe);
        _pistolButton.onClick.AddListener(OnStatePistol);
        _gunButton.onClick.AddListener(OnStateShotgun);
        _uziButton.onClick.AddListener(OnStateUZI);
    }

    private void OnDisable()
    {
        _axeButton.onClick.RemoveListener(OnStateAxe);
        _pistolButton.onClick.RemoveListener(OnStatePistol);
        _gunButton.onClick.RemoveListener(OnStateShotgun);
        _uziButton.onClick.RemoveListener(OnStateUZI);
    }

    private void Start()
    {
        _pistolButton.transform.gameObject.SetActive(false);
        _gunButton.transform.gameObject.SetActive(false);
        _uziButton.transform.gameObject.SetActive(false);
    }

    private void OnStateAxe() => ChangeState?.Invoke(0, _axe);

    private void OnStatePistol() => ChangeState?.Invoke(1, _pistol);

    private void OnStateShotgun() => ChangeState?.Invoke(1, _shotgun);

    private void OnStateUZI() => ChangeState?.Invoke(1, _uzi);

    public void BuyWeapon(Weapon weapon)
    {
        if (weapon is Pistol)
        {
            _pistolButton.transform.gameObject.SetActive(true);
            _pistol = (Pistol)weapon;
        }
        else if (weapon is Shotgun)
        {
            _gunButton.transform.gameObject.SetActive(true);
            _shotgun = (Shotgun)weapon;
        }
        else if (weapon is UZI)
        {
            _uziButton.transform.gameObject.SetActive(true);
            _uzi = (UZI)weapon;
        }
        else if (weapon is Axe)
        {
            _axe = (Axe)weapon;
        }
    }
}
