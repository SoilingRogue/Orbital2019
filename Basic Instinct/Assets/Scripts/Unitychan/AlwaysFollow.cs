using UnityEngine;

public class AlwaysFollow : MonoBehaviour {
    public GameObject objectToFollow;
    public Vector3 positionDifference;

    void Start() {
        objectToFollow = GameObject.FindGameObjectWithTag("Player");

        transform.position = objectToFollow.transform.position - positionDifference;
    }

    void Update() {
        transform.position = objectToFollow.transform.position - positionDifference;
    }
}
