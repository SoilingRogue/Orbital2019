using UnityEngine;

public class WaveObject : MonoBehaviour {
    public GameObject character;
    private Vector3 direction;
    void Start() {
        transform.position = character.transform.position;
        direction = character.transform.forward;

        MeshFilter meshFilter = (MeshFilter)gameObject.AddComponent(typeof(MeshFilter));

        // This is a hack
        GameObject tempSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        meshFilter.mesh = tempSphere.GetComponent<MeshFilter>().mesh;
        GameObject.Destroy(tempSphere);

        gameObject.AddComponent(typeof(MeshRenderer));
    }

    void Update() {
        transform.position += direction * Time.deltaTime;
    }
}
