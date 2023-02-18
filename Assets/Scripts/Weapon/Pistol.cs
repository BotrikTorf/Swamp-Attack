using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(GameObject shootPoint, float passedAfterShot)
    {
        _shotDelay = 0.2f;

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
