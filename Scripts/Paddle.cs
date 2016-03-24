using UnityEngine;
using System.Collections;
using Windows.Kinect;
public class Paddle : MonoBehaviour {
	public GameObject BodysrcManager;
	public JointType TrackedJoint;
	private BodySourceManager bodyManager;
	private Body[] bodies;
	public float paddleSpeed = 1f;	
	
	private Vector3 playerPos = new Vector3 (0, -9.5f, 0);
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
	{		if(bodyManager==null)
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
		{
			if(body==null)
			{	continue;}
			if(body.IsTracked){
				if (x) {
					x = false;
					continue;
				}
				var pos= body.Joints[TrackedJoint].Position;
				gameObject.transform.position=new Vector3(pos.X*10,pos.Y*10);
			}
			
		}

		//float xPos = transform.position.x;// + (Input.GetAxis("Horizontal") * paddleSpeed);
		//playerPos = new Vector3 (Mathf.Clamp (xPos, -16f, 16f), -9.5f, 0f);
		//transform.position = playerPos;
		
	}
}
