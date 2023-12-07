using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public float speed = 25;

    Vector3 direction = new();
    
    void Start()
    {
        direction.x = Random.Range(-1, 2);
        direction.y = Random.Range(-1, 2);
        direction.z = Random.Range(-1, 2);
    }

    
    void Update()
    {
        transform.Rotate(direction * speed * Time.deltaTime);
    }
}
