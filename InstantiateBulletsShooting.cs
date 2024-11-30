using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
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
        while (true)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            GameObject bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            bulletRigidbody.transform.up = direction;
            bulletRigidbody.velocity = direction * _speed;

            yield return _time;
        }
    }
}