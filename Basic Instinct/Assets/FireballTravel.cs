using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballTravel : MonoBehaviour {
    void Update() {
        transform.position += transform.forward * Time.deltaTime;
    }
}
