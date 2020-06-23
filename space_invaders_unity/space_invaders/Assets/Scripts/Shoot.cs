using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    float shootSpeed;
    float shootDirection;

    Action onShootDestroy;

    void Update() {
        transform.position += new Vector3(0, shootDirection * shootSpeed * Time.deltaTime, 0);

        if(transform.position.y > 10f) {
            onShootDestroy();
            Destroy(gameObject);
        }
    }

    internal void Setup(float speed, float direction, Action onShootDestroy) {
        shootSpeed = speed;
        shootDirection = direction;
        this.onShootDestroy = onShootDestroy;
    }
}
