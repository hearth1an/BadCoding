using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _speed;
    [SerializeField] private float _shootDelay;

    private Transform _target;
    private WaitForSeconds _time;

    private void Start()
    {
        _time = new WaitForSeconds(_shootDelay);
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (enabled)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);
            Rigidbody bulletRigidbody = bullet.Rigidbody;

            bullet.Init(bulletRigidbody, direction, _speed);

            yield return _time;
        }
    }
}