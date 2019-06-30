using UnityEngine;

public class FollowUnitychan : MonoBehaviour {
    public GameObject unitychan;
    public Camera unitychanCamera;
    public Vector3 separationVector;
    private Vector3 initialMousePosition;
    public float baseAngle;
    private Vector3 initialRotation;

    void Start() {
        // To prevent null pointer exception
        initialRotation = unitychan.transform.eulerAngles;
    }

    void Update() {
        // Set camera position
        unitychanCamera.transform.position = unitychan.transform.position + separationVector;

        // Use "2" to reset angle
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            unitychanCamera.transform.eulerAngles = unitychan.transform.eulerAngles;
            initialRotation = unitychanCamera.transform.eulerAngles;
        }

        else {
            if (Input.GetMouseButtonDown(1)) {
                initialMousePosition = Input.mousePosition;
            }

            // Set camera rotation
            if (Input.GetMouseButton(1)) {
                Vector3 currentMousePosition = Input.mousePosition;
                float deltaX = currentMousePosition.x - initialMousePosition.x;
                float deltaY = currentMousePosition.y - initialMousePosition.y;
                float xAngle = Mathf.Clamp(deltaY * baseAngle, -90, 90);
                float yAngle = Mathf.Clamp(deltaX * baseAngle, -90, 90);
                unitychanCamera.transform.eulerAngles = new Vector3(initialRotation.x + xAngle, initialRotation.y -yAngle, initialRotation.z);
                // x and y are intentionally swapped!!
            }

            if (Input.GetMouseButtonUp(1)) {
                initialRotation = unitychanCamera.transform.eulerAngles;
            }
        }
    }

    // int getScreenVerticalMidpoint() {
    //     return Screen.currentResolution.height / 2;
    // }

    // int getScreenHorizontalMidpoint() {
    //     return Screen.currentResolution.width / 2;
    // }    
}
