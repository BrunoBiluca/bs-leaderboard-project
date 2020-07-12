using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour {
    float timeToLive;

    private void Awake() {
        timeToLive = .5f;
    }

    void Update() {
        timeToLive -= Time.deltaTime;
        if(timeToLive <= 0)
            Destroy(gameObject);
    }
}
