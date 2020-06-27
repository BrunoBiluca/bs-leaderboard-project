using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour {

    [SerializeField] public GameObject pfShoot;

    float playerSpeed;
    bool isShootActive;

    void Start() {
        playerSpeed = 3f;
    }

    void Update() {
        var direction = 0;

        if(Input.GetKey(KeyCode.RightArrow)) direction = 1;
        else if(Input.GetKey(KeyCode.LeftArrow)) direction = -1;

        transform.position += new Vector3(direction * playerSpeed * Time.deltaTime, 0, 0);

        if(!isShootActive && Input.GetKeyDown(KeyCode.Space)) {
            isShootActive = true;

            var goShoot = Instantiate(pfShoot, transform.position + new Vector3(0, .8f, 0), pfShoot.transform.rotation);
            var shoot = goShoot.GetComponent<Shoot>();
            shoot.Setup<Enemy>(5f, 1f, () => {
                isShootActive = false;
            });
        }
    }
}
