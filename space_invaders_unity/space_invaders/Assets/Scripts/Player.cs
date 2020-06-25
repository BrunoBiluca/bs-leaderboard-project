using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable {
    public void Damage() {
        Destroy(gameObject);
    }
}
