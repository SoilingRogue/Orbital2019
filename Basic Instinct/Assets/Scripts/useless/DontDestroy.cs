using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
    void Start() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Config");
        if (objs[0] != this.gameObject) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
