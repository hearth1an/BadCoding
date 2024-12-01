using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public Rigidbody Rigidbody => GetComponent<Rigidbody>();
}
