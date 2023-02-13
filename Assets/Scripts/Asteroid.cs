using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : FallingObject
{
    private Vector2 _speedMinMax = new Vector2(7, 15);

    void Start()
    {
        _speed = Mathf.Lerp(_speedMinMax.x, _speedMinMax.y, Difficulty.GetDifficultyPercent());
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 4f * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Player")
        {
            triggerCollider.GetComponent<PlayerController>().Lose();
            Destroy(gameObject);
        }
    }
}
