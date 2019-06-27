using UnityEngine;

public class FollowSphere : MonoBehaviour {
    public GameObject sphere;
    private Vector3 initialVector;

    void Start() {
        initialVector = transform.position - sphere.transform.position;
    }

    void Update() {
        transform.position = sphere.transform.position + initialVector;
    }
}
