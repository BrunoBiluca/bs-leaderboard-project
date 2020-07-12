using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable {

    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.gameObject.name);
        var other = collision.gameObject.name;

        if(other != "left_bound" && other != "right_bound") {
            return;
        }
        var enemyMoviment = transform.parent.gameObject.GetComponent<EnemyMoviment>();
        if(enemyMoviment.changeDirectionInterval >= 2) {
            enemyMoviment.changeDirectionInterval = 0;
            enemyMoviment.direction = new Vector3(enemyMoviment.direction.x * -1, 0);
        }
    }

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
