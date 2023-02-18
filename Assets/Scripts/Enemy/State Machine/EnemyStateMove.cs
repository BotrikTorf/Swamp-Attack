using UnityEngine;

public class EnemyStateMove : EnemyState
{
    [SerializeField] private float _speed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            transform.position =
                Vector3.MoveTowards(transform.position,
                    Target.transform.position,
                    _speed * Time.deltaTime);
        }
        else
        {
            Exit();
        }
    }
}
