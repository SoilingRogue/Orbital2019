using UnityEngine;

public class FollowPosition : MonoBehaviour {
    public GameObject objectToFollow;
    private Animator anim;
    private Vector3 positionDifference;
    void Start() {
        anim = objectToFollow.GetComponent<Animator>();
        positionDifference = objectToFollow.transform.position - transform.position;
    }

    void Update() {
        if (!anim.GetBool("emote") || anim.GetBool("slide"))
        {
        transform.position = objectToFollow.transform.position - positionDifference;
        }
    }
}
