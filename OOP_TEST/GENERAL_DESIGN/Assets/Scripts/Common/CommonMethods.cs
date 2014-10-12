using UnityEngine;
using System.Collections;

/*
 * Utility Class
 * Contain functions or methods  for training purposes.
*/

public static class CommonMthods {

	public static Mesh DrawPlaneMesh(float width, float height, Mesh m)
	{
		
		m.vertices = new Vector3[] {
			
			new Vector3(width, height, 0.01f),
			new Vector3(-width, height, 0.01f),
			new Vector3(-width, -height, 0.01f),
			new Vector3(width, -height, 0.01f)
		};
		
		m.uv = new Vector2[] {
			new Vector2 (0, 0),
			new Vector2 (0, 1),
			new Vector2(1, 1),
			new Vector2 (1, 0)
		};
		
		m.triangles = new int[] { 0, 1, 2, 0, 2, 3};
		
		m.RecalculateNormals();
		return m;
	}
	
	public static void TestScene(){

		//Alternative variants:
		//GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//GameObject newTag = new GameObject("MenuTag-"+id.ToString());

		Mesh m = new Mesh() ;
		m.name = "ScriptedMesh";
		m = DrawPlaneMesh (1, 1, m);
		
		GameObject obj = new GameObject("New_Plane_Fom_Script");
		obj.AddComponent<MeshFilter> ();
		obj.GetComponent<MeshFilter>().mesh= m;
		obj.AddComponent<MeshRenderer> ();
		obj.GetComponent<MeshRenderer> ().materials[0]  = new Material (Shader.Find("Diffuse")) ;
		obj.transform.rotation = Quaternion.Euler(60, 145, 30);

		//Alternative variants:
		//obj.transform.Rotate(Vector3.right * Time.deltaTime);
		
		
		
	}

}
