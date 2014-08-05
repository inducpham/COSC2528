using UnityEngine;
using System.Collections.Generic;

public class SpikeMeshGenerator : MonoBehaviour {

	// The list of vertices used for the mesh
	public List<Vector3> newVertices = new List<Vector3>();
	// The vertices index for building the triangles
	public List<int> newTriangles = new List<int>();
	// UV list to show texture mapping
	public List<Vector2> newUV = new List<Vector2>();

	// A mesh is made up of vertices, triangles and UVs, after
	// they are defined they are stored in the Mesh object
	private Mesh mesh;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		mesh = GetComponent<MeshFilter> ().mesh;
//		
//		float x = transform.position.x;
//		float y = transform.position.y;
//		float z = transform.position.z;
		
		
		newVertices.Add( new Vector3 (0F, 0.25F, -0.5F));
		newVertices.Add( new Vector3 (-0.25F, -0.25F, -0.5F));
		newVertices.Add( new Vector3 (0.25F, -0.25F, -0.5F));
		newVertices.Add( new Vector3 (0F , 0F, 0.5F));
		
		newTriangles.Add(0);
		newTriangles.Add(1);
		newTriangles.Add(3);
		newTriangles.Add(2);
		newTriangles.Add(0);
		newTriangles.Add(3);
		newTriangles.Add(1);
		newTriangles.Add(2);
		newTriangles.Add(3);
		newTriangles.Add(0);
		newTriangles.Add(2);
		newTriangles.Add(1);
		
		mesh.Clear ();
		mesh.vertices = newVertices.ToArray();
		mesh.triangles = newTriangles.ToArray();
		mesh.Optimize ();
		mesh.RecalculateNormals ();

	}
}
