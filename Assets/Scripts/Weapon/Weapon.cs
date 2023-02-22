using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;
    [SerializeField] protected Bullet Bullet;

    protected Animator _animator;
    protected bool _isAttackPassed = true;
    protected float _shotDelay = 0;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;
    public bool IsAttackPassed => _isAttackPassed;
    public abstract void Shoot(GameObject shootPoint, float passedAfterShot);

    public void GetAnimator(Animator animator) => _animator = animator;

    public void Buy() => _isBuyed = true;
}
