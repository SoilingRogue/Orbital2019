using UnityEngine;
 
public class CameraOrbit : MonoBehaviour
{
    // camera & pivot
    protected Transform cam, pivot;
    // storing rotations of camera pivot
    protected Vector3 camRotation;
    protected float camDistance = 3f;
 
    // Edit settings to change orbit/scroll
    /* 
        Dampening - enables faster scrolling the further we are from the object, but slower scrolling when closer 
        Sigmoidal effect when scrolling
    */
    public float mouseSensitivity = 4f, scrollSensitivity = 2f;
    protected float orbitDampening = 10f, scrollDampening = 6f;
 
    // Use this for initialization
    void Start() {
        this.cam = this.transform;
        this.pivot = this.transform.parent;
    }
 
    // LateUpdate called after Update() on every game object in the scene, for rendering
    void LateUpdate() {
            // Rotation of the Camera based on Mouse Coordinates
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                camRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                camRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;
 
                // Clamp the y Rotation to horizon and not flipping over at the top
                camRotation.y = Mathf.Clamp(camRotation.y, 0f, 85f);
            }

            // Zooming Input from our Mouse Scroll Wheel
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;
                scrollAmount *= (this.camDistance * 0.3f);
 
                this.camDistance += scrollAmount * -1f;
 
                // Set distance from target to be 1.5m < distance < 10m
                this.camDistance = Mathf.Clamp(this.camDistance, 1.5f, 10f);
            }
 
        // Actual Camera Rig Transformations - has to be inside of LateUpdate()
        // setting pitch and yaw for rotation
        Quaternion QT = Quaternion.Euler(camRotation.y, camRotation.x, 0);
        
        // Lerp - linear interpolation btw current rotation at start of frame & animate towards target rotation
        this.pivot.rotation = Quaternion.Lerp(this.pivot.rotation, QT, Time.deltaTime * orbitDampening);
 
        if ( this.cam.localPosition.z != this.camDistance * -1f )
        {
            this.cam.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this.cam.localPosition.z, this.camDistance * -1f, Time.deltaTime * scrollDampening));
        }
    }
} 
