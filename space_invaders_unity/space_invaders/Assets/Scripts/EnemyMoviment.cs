using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour {

    [SerializeField] public GameObject[] aliens;

    Vector3 direction;

    void Start() {

        var height = 3;
        var width = 10;

        direction = new Vector3(1, 0);

        for(int i = 0; i < width; i++) {
            for(int j = 0; j < height; j++) {
                Instantiate(aliens[j], new Vector3(i + .5f - width / 2, j - height / 2) + transform.position, Quaternion.identity, transform);
            }
        }

    }

    float changeDirectionInterval = 0f;
    float movimentInterval = 0f;

    private void OnCollisionEnter(Collision collision) {
        // TODO: buscar uma forma de garantir que apenas o primeiro filho será utilizado
        if(changeDirectionInterval >= 2) {
            changeDirectionInterval = 0;
            direction = new Vector3(direction.x * -1, 0);
        }
    }

    void Update() {
        changeDirectionInterval += Time.deltaTime;
        movimentInterval += Time.deltaTime;

        if(movimentInterval >= 1) {
            movimentInterval = 0;
            transform.Translate(direction);
        }
    }
}
