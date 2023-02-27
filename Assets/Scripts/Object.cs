using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        Debug.Log(gameObject.name);
        Debug.Log(mesh.vertices.Length);
        Debug.Log(mesh.triangles.Length);
        Debug.Log(mesh.bounds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
