using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestWebRequests : MonoBehaviour {
    void Start() {
        var url = "http://localhost:5000/v1/players/1";
        WebRequests.Get(url,
            (string response) => { Debug.Log(response); },
            (string error) => { Debug.LogError(error); }
        );
    }
}
