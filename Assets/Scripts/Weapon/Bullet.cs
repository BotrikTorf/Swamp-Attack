using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.TryGetComponent(out Destroyer destroyer))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.TryGetComponent(out MinotaurBlack minotaur))
        {
            minotaur.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }


}
