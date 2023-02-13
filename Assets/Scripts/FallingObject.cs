using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField]
    protected float _speed;


    void FixedUpdate()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.Self);
        if (transform.position.y < -Camera.main.orthographicSize - transform.localScale.y)
        {
            Destroy(gameObject);
        }
    }
}
