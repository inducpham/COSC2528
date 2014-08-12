using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Globals))]
public class SteerWander : SteeringBehaviour
{
	//non nullable, ini at "Awake"
	private Globals.Filter3 filter1 = null;
	private Globals.Filter3 filter2 = null;

	private Vector3 Random3(float range){
		return new Vector3(
			Random.Range(-range,range),
			Random.Range(-range,range),
			Random.Range(-range,range));
	}
//	private Vector3 _randomSteering;
	public float desire = 1f;

	public override float GetPriority (){
		return desire;
	}

    public override Vector3 GetSteering()
    {
		if (filter1 == null && filter2 == null) {
			desire = 0f;
			return new Vector3(0f,0f,0f);
		}
		desire = 1f;
 		return rigidbody.velocity += filter2(filter1(Random3(2f)));
    }
	void Awake(){
		Globals.Float rand = ()=> Random.Range(-1f,1f);
		filter1 = Globals.CreateFilter3(1f,()=>Time.deltaTime,rand(),rand(),rand());
		filter2 = Globals.CreateFilter3(1f,()=>Time.deltaTime,rand(),rand(),rand());
	}
}
/*

[RequireComponent(typeof(RotationMatrix))]
public class Test2 : MonoBehaviour {
	public Transform center = null;
	private static List<Test2> all = new List<Test2>();
	Inertia ix=new Inertia();
	Inertia iy=new Inertia();
	Inertia iz=new Inertia();
	Inertia ix2=new Inertia();
	Inertia iy2=new Inertia();
	Inertia iz2=new Inertia();
	// Use this for initialization
	void Start () {
		rigidbody.velocity = new Vector3(Random.Range(-10,10),Random.Range(-10,10),Random.Range(-10,10));
		all.Add (this);
	}
	float Rand() {
		return	Random.Range (-1f, 1f);
	}
	// Update is called once per frame
	Vector3 Random_movement_force(){
		return  new Vector3 (
			ix2.IO (ix.IO (Rand ())) * 20f,
			iy2.IO (iy.IO (Rand ())) * 20f,
			iz2.IO (iz.IO (Rand ())) * 20f);
	}
	Vector3 avoid_force(){
		Vector3 v = new Vector3 (0f,0f,0f);
		foreach (var i in all) {
			if( i != this){
				Vector3 s = rigidbody.position - i.rigidbody.position;
				//if (rigidbody.velocity.sqrMagnitude<.1f)
				float K = 0.1f;
				v +=  s.normalized * 100/(s.sqrMagnitude+K); 
			}
		}
		return v;
	}
	Vector3 foo_force(){
		Vector3 v = Random_movement_force();
		if (all.Count <= 1)
			return v;
		Vector3 ds = new Vector3();
		Vector3 dv = new Vector3();
		float w = 0;
		foreach (var i in all) {
			if( i != this){
				float K=10f;
				Vector3 s = i.rigidbody.position - rigidbody.position;
				//if (rigidbody.velocity.sqrMagnitude<.1f)
				float f = 1/s.sqrMagnitude;
				//f-=0.05f;
				if(f<0f)f=0f;
				//float wi = (Vector3.Dot(rigidbody.velocity,s)+K)*f/(rigidbody.velocity.magnitude + K)
				//	+ rigidbody.velocity.magnitude/(rigidbody.velocity.magnitude + K);
				float wi= (Vector3.Dot(rigidbody.velocity,s)/rigidbody.velocity.magnitude/s.magnitude + 1)
					/s.magnitude;
				ds += wi*s;
				dv += wi*i.rigidbody.velocity;
				w+=wi;
			}
		}
		w = w / (all.Count - 1);
		float w0 = 0.001f;
		w0 = w0;
		w = w ;
		ds = 1f/ (w + w0) *(w  * ds  + w0*rigidbody.position);
		dv = 1f/ (w + w0) *(w  * (dv + 1f*(ds-rigidbody.position)) + w0*rigidbody.velocity);
		Vector3 da = 1f * (dv - rigidbody.velocity);
		return 1f/ (w + w0)*(w*da + w0*v);
	}
	void Update () {
		Vector3 fuck = (foo_force()+avoid_force());
		if (fuck.sqrMagnitude > 400)
			fuck = fuck.normalized * 20;
		rigidbody.velocity += Time.deltaTime*fuck;
		//rigidbody.velocity = rigidbody.velocity.normalized*20;
		
		if (center == null)
			fuck = (new Vector3(0,0,0) - rigidbody.position);
		else
			fuck = (center.position - rigidbody.position);
		//if (fuck.sqrMagnitude > 400)
		//				fuck = fuck.normalized * 20;
		rigidbody.velocity += 0.03f*fuck.normalized*fuck.sqrMagnitude/100;
		rigidbody.velocity -= 0.001f*rigidbody.velocity.sqrMagnitude * rigidbody.velocity.normalized;
		//if(rigidbody.velocity.sqrMagnitude<100){
		//	rigidbody.velocity = 10*rigidbody.velocity.normalized;
		//}
	}
}*/
