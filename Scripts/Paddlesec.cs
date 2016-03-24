using UnityEngine;
using System.Collections;
using Windows.Kinect;
public class Paddlesec : MonoBehaviour {
	public GameObject BodysrcManager;
	public JointType TrackedJoint;
	private BodySourceManager bodyManager;
	private Body[] bodies;

	public float paddleSpeed = 1f;	
	
	private Vector3 playerPos = new Vector3 (0, 9f, 0);
	void Start () 
	{
		
		
		if(BodysrcManager == null)	
		{
			Debug.Log("Assign Game object with body source manager");
		}
		else
		{
			bodyManager=BodysrcManager.GetComponent<BodySourceManager>();
		}
	}

	void Update () 
	{if(bodyManager==null)
		{
			return;
		}
		bodies=bodyManager.GetData();
		if(bodies==null)
		{
			return;
		}
		var x = true;
		foreach(var body in bodies)
		{	Debug.Log(body.IsTracked);
			if(body==null)
			{	Debug.Log("1");continue;}
			if(body.IsTracked){
				if (x) {
					Debug.Log("2");
					var pos= body.Joints[TrackedJoint].Position;

					gameObject.transform.position=new Vector3(pos.X*10,pos.Y*10);
					x = false;
				}
			
				
			}
			
		}
		

		//float xPos = transform.position.x;// + (Input.GetAxis("Vertical") * paddleSpeed);
		//playerPos = new Vector3 (Mathf.Clamp (xPos, -16f, 16f), 9f, 0f);
		//transform.position = playerPos;
		
	}
}
