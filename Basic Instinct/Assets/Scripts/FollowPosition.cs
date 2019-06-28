using UnityEngine;

public class FollowPosition : MonoBehaviour {
    public GameObject objectToFollow;

    private Vector3 positionDifference;

    void Start() {
        positionDifference = objectToFollow.transform.position - transform.position;
    }

    void Update() {
        transform.position = objectToFollow.transform.position - positionDifference;
    }
}
