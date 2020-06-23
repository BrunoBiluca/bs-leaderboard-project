using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour {

    [SerializeField] public GameObject[] aliens;

    int[,] enemyGrid;

    Vector3 direction;

    void Start() {

        var height = 3;
        var width = 10;

        direction = new Vector3(1, 0);

        enemyGrid = new int[width, height];

        var boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(width, height);

        for(int i = 0; i < width; i++) {
            for(int j = 0; j < height; j++) {
                enemyGrid[i, j] = 1;
                Instantiate(aliens[j], new Vector3(i + .5f - width / 2, j - height / 2) + transform.position, Quaternion.identity, transform);
            }
        }

    }

    float movimentInterval = 0f;
    void Update() {
        movimentInterval += Time.deltaTime;

        if(movimentInterval >= 1) {
            movimentInterval = 0;
            transform.Translate(direction);
        }
    }

    private void OnTriggerEnter(Collider other) {
        direction *= -1;       
    }
}
