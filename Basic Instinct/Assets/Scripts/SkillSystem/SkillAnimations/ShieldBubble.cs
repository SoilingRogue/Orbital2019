using UnityEngine;

public class ShieldBubble : MonoBehaviour {
    public GameObject character;

    void Start() {
        MeshFilter meshFilter = (MeshFilter)gameObject.AddComponent(typeof(MeshFilter));

        // This is a hack
        GameObject tempSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        meshFilter.mesh = tempSphere.GetComponent<MeshFilter>().mesh;
        GameObject.Destroy(tempSphere);

        MeshRenderer meshRenderer = (MeshRenderer)gameObject.AddComponent(typeof(MeshRenderer));
        gameObject.transform.localScale = new Vector3(3, 3, 3);
    }

    void Update() {
        gameObject.transform.position = character.transform.position;
    }
}
