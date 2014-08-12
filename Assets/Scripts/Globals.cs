using UnityEngine;
using System.Collections;


/// <summary>
/// Globals. Some global definitions.
/// </summary>
public class Globals : MonoBehaviour {
	public delegate float Float();
	public delegate int Int();
	public delegate float Function(float x);
	public delegate Vector3 VectorField(Vector3 Coordinate);
	public delegate Vector3 ForceField(Vector3 Coordinate);

	/// <summary>
	/// Creats a radiant vector field.
	/// The magnitude of the vector is as the return value of Function "f"
	/// </summary>
	/// <returns>The vector field radiant.</returns>
	/// <param name="f">F. A function take the "vector.magnitude" as it parameter</param>
	public static VectorField CreatVectorFieldRadiant(Function f){
		return  x => {
			return f(x.magnitude) * x.normalized;
		};
	}


	/// <summary>
	/// Take a vector as parameter an return is rotation from global coordinate system.
	/// For example, take rigidbody.velocity as parameter and apply it's return value 
	/// to rigidbody.eulerAngles to parallelize it X axis to it's velocity.
	/// </summary>
	/// <returns>Rotation</returns>
	/// <param name="v">Vector.</param>
	public static Vector3 EulerAngles(Vector3 v){
		return EulerAnglesZ (v);
	}
	public static Vector3 EulerAnglesX(Vector3 v){
		return 180/Mathf.PI* new Vector3(
			0f,
			-Mathf.Atan2 (v.z,v.x),
			Mathf.Atan2 (v.y,Mathf.Sqrt(v.z*v.z+v.x*v.x))
			);
	}

	public static Vector3 EulerAnglesY(Vector3 v){
		return 180/Mathf.PI * new Vector3(
			Mathf.Atan2 (v.z,v.y),
			0,
			-Mathf.Atan2 (v.x,Mathf.Sqrt(v.y*v.y+v.z*v.z))
			);
	}
	public static Vector3 EulerAnglesZ(Vector3 v){
		return 180/Mathf.PI * new Vector3(
			-Mathf.Atan2 (v.y,Mathf.Sqrt(v.z*v.z+v.x*v.x)),
			Mathf.Atan2 (v.x,v.z),
			0
			);
	}

	/// <summary>
	/// Filters to smooth fluctuations(like random numbers)
	/// Put it in "Update" and 
	/// DON'T APPLY MORE THAN ONCE IN A SINGLE UPDATE OR IN OTHER PLACES!!! CREATE A NEW ONE IF YOU NEED TWO.
	/// </summary>
	public delegate float Filter(float x);
	/// <returns>The filter.</returns>
	/// <param name="K">K.The larger the smoother, but the reaction is also slower.</param>
	/// <param name="deltaTime">Delta time.</param>
	/// <param name="iniOutput">Ini output.</param>
	public static Filter CreateFilter(float K,Float deltaTime,float output=0){
		return x => output += K*(x-output)*deltaTime();
	}
	public delegate Vector3 Filter3(Vector3 v);
	public static Filter3 CreateFilter3(float K,Float deltaTime,float ix=0f,float iy=0f,float iz=0f){
		Filter fx = CreateFilter(K,deltaTime,ix);
		Filter fy = CreateFilter(K,deltaTime,iy);
		Filter fz = CreateFilter(K,deltaTime,iz);
		return v => new Vector3(fx(v.x),fy(v.y),fz(v.z));
	}
}
