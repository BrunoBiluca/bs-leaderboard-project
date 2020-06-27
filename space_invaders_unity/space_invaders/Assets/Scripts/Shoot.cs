using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    float shootSpeed;
    float shootDirection;
    Type shootTarget;

    Action onShootDestroy;

    void Update() {
        transform.position += new Vector3(0, shootDirection * shootSpeed * Time.deltaTime, 0);

        if(transform.position.y > 10f) {
            GameManager.i.gameScore.MissedShoot();
            Destroy(gameObject);
        }
    }

    internal void Setup<T>(float speed, float direction, Action onShootDestroy) where T : IDamageable {
        shootSpeed = speed;
        shootDirection = direction;
        shootTarget = typeof(T);
        this.onShootDestroy = onShootDestroy;
    }

    private void OnTriggerEnter(Collider other) {
        var damageableSystem = other.GetComponent<IDamageable>();

        if(damageableSystem != null) {
            if(damageableSystem.GetType() == shootTarget) {
                damageableSystem.Damage();
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy() {
        onShootDestroy();
    }

}
