using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable {

    public void Shoot() {
        var shoot = Instantiate(GameAssets.i.pfShoot, transform.position + new Vector3(0, -.5f, 0), Quaternion.identity);
        shoot.GetComponent<Shoot>()
            .Setup<Player>(3f, -1f, () => { });
    }

    public void Damage() {
        GameManager.i.gameScore.KillEnemy();
        Destroy(gameObject);
    }
}
