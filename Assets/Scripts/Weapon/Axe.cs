using UnityEngine;

public class Axe : Weapon
{
    public override void Shoot(GameObject shootPoint, float passedAfterShot)
    {
        _shotDelay = 1;

        if (passedAfterShot >= _shotDelay)
        {
            _animator.Play("AnimationAxeAttack");
            Instantiate(Bullet, shootPoint.transform.position, Quaternion.identity);
            _isAttackPassed = true;
        }
        else
        {
            _isAttackPassed = false;
        }
    }
}
