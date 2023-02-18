using UnityEngine;

public class Shotgun : Weapon
{
    public override void Shoot(GameObject shootPoint, float passedAfterShot)
    {
        _shotDelay = 0.5f;

        if (passedAfterShot >= _shotDelay)
        {
            _animator.Play("AnimationGunAttack");
            Instantiate(Bullet, shootPoint.transform.position, Quaternion.identity);
            _isAttackPassed = true;
        }
        else
        {
            _isAttackPassed = false;
        }
    }
}
