using UnityEngine;

public class DaggerObject : MonoBehaviour {
    public GameObject character;
    private Vector3 direction;
    void Start() {
        gameObject.transform.position = character.transform.position;
        gameObject.AddComponent(typeof(SphereCollider));
        Rigidbody body = (Rigidbody)gameObject.AddComponent(typeof(Rigidbody));
        body.useGravity = false;
        
        // Object[] cameras = FindObjectsOfType(typeof(GameObject));
        // Object playerCamera = System.Array.Find(cameras, obj => ((GameObject)obj).tag == "PlayerCamera");
        // direction = ((GameObject)playerCamera).transform.forward;
        direction = new Vector3(0, 0, 50);

        MeshFilter meshFilter = (MeshFilter)gameObject.AddComponent(typeof(MeshFilter));

        // This is a hack
        GameObject tempCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        meshFilter.mesh = tempCylinder.GetComponent<MeshFilter>().mesh;
        GameObject.Destroy(tempCylinder);

        MeshRenderer meshRenderer = (MeshRenderer)gameObject.AddComponent(typeof(MeshRenderer));
        // gameObject.transform.localScale = new Vector3(10, 10, 10);    

        body.AddForce(direction, ForceMode.VelocityChange);    
    }

    void Update() {
        // gameObject.transform.position += direction;
    }
}
