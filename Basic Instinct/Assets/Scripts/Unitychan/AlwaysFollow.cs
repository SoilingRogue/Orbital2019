using UnityEngine;

public class AlwaysFollow : MonoBehaviour {
    public GameObject objectToFollow;
    public Vector3 positionDifference;

    void Start() {
        transform.position = objectToFollow.transform.position - positionDifference;
    }

    void Update() {
        transform.position = objectToFollow.transform.position - positionDifference;
    }
}
