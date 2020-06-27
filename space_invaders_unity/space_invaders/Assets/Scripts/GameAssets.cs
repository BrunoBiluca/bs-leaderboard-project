using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour {

    private static GameAssets _i;
    public static GameAssets i {
        get {
            if(_i == null) _i = FindObjectOfType<GameAssets>();
            return _i;
        }
    }

    [SerializeField] public GameObject pfShoot;
    [SerializeField] public GameObject[] pfAliens;

}
