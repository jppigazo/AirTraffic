// Builds a Mesh containing a single triangle with uvs.
// Create arrays of vertices, uvs and triangles, and copy them into the mesh.

using UnityEngine;

public class meshTriangles : MonoBehaviour
{
    private Mesh mesh;
    private float x0 = 0f;
    private float y0 = 0f;
    private float x1 = -0.125f;
    private float y1 = 0.35f;
    private float x2 = 0.125f;
    private float y2 = 0.35f;
    
    // Use this for initialization
    void Start()
    {

  //      gameObject.AddComponent<MeshFilter>();
  //      gameObject.AddComponent<MeshRenderer>();
        mesh = GetComponent<MeshFilter>().mesh;

        mesh.Clear();

        // make changes to the Mesh by creating arrays which contain the new values
        mesh.vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(-0.125f, 0.35f, 0), new Vector3(0.125f, 0.35f, 0) };
        mesh.uv = new Vector2[] { new Vector2(1, 1), new Vector2(0, 1), new Vector2(1, 1) };
        mesh.triangles = new int[] { 0, 1, 2 };
    }


}
