using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour {

    public Vector3 direction;

    void Start() {

        var height = 2;
        var width = 1;

        direction = new Vector3(1, 0);

        for(int i = 0; i < width; i++) {
            for(int j = 0; j < height; j++) {
                Instantiate(
                    GameAssets.i.pfAliens[j], 
                    new Vector3(i + .5f - width / 2, j - height / 2) + transform.position, 
                    Quaternion.identity, 
                    transform
                );
            }
        }

    }

    public float changeDirectionInterval = 0f;
    float movimentInterval = 0f;    
    float shootInterval = 0f;

    void Update() {
        changeDirectionInterval += Time.deltaTime;
        movimentInterval += Time.deltaTime;

        if(movimentInterval >= 1) {
            movimentInterval = 0;
            transform.Translate(direction);
        }

        shootInterval += Time.deltaTime;
        if(shootInterval >= 1 && transform.childCount > 0) {
            shootInterval = 0;
            var randChild = UnityEngine.Random.Range(0, transform.childCount);
            var enemy = transform.GetChild(randChild).GetComponent<Enemy>();
            enemy.Shoot();
        }
    }
}
