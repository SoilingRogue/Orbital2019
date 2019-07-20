using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraMovement : MonoBehaviour {
    public GameObject player;
    private Vector3 vectorDiff;

    void Start() {
        vectorDiff = gameObject.transform.position - player.transform.position;
    }

    void Update() {
        if (player.transform.hasChanged) {
            gameObject.transform.position = player.transform.position + vectorDiff;
        }
    }
}
