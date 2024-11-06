using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);

        if(transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
