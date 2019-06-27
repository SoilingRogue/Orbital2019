using UnityEngine;

public class SphereMovement : MonoBehaviour {
    private Rigidbody sphere;
    public float lateralForce;
    public float jumpForce;

    void Start() {
        sphere = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
       if (Input.GetKey(KeyCode.W)) {
           sphere.AddForce(0, 0, lateralForce, ForceMode.Impulse);
       }
       if (Input.GetKey(KeyCode.A)) {
            sphere.AddForce(-lateralForce, 0, 0, ForceMode.Impulse);
       }
       if (Input.GetKey(KeyCode.S)) {
           sphere.AddForce(0, 0, -lateralForce, ForceMode.Impulse);
       }
       if (Input.GetKey(KeyCode.D)) {
           sphere.AddForce(lateralForce, 0, 0, ForceMode.Impulse);
       }
       if (Input.GetKeyDown(KeyCode.Space)) {
           sphere.AddForce(0, jumpForce, 0, ForceMode.Impulse);
       }
    }
}
