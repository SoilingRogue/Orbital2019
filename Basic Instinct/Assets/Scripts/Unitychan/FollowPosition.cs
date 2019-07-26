using UnityEngine;

public class FollowPosition : MonoBehaviour {
    public GameObject objectToFollow;
    public Vector3 positionDifference;
    private Animator anim;
    void Start() {
        anim = objectToFollow.GetComponent<Animator>();
        transform.position = objectToFollow.transform.position - positionDifference;
    }

    void Update() {
        if (!anim.GetBool("emote") || anim.GetBool("slide"))
        {
        transform.position = objectToFollow.transform.position - positionDifference;
        }
    }
}
