using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody _rigidbody;

    void Start()
    {
        if (_rigidbody == null) _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        ResetPosition();
    }
    private void OnEnable()
    {
        ResetPosition();
    }
    public void SetSpeed(float _value)
    {
        moveSpeed = _value;
    }

    private void ResetPosition()
    {
        Vector3 newPosition = new Vector3
        {
            x = Random.Range(-4.5f, 4.5f),
            y = 0.5f,
            z = transform.position.z + 300
        };

        transform.SetPositionAndRotation(newPosition, Quaternion.identity);
    }
}
