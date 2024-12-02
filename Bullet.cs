using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(Rigidbody rigidbody, Vector3 direction, float speed)
    {
        rigidbody.transform.up = direction;
        rigidbody.velocity = direction * speed;
    }
}
