using UnityEngine;

using System.Collections;


using Windows.Kinect;

public class Joints2 : MonoBehaviour {


	public GameObject BodysrcManager;
	public JointType TrackedJoint;
	private BodySourceManager bodyManager;
	private Body[] bodies;


	// Use this for initialization

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


	// Update is called once per frame

	void Update () 
	{

		if(bodyManager==null)
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
					var pos= body.Joints[TrackedJoint].Position;
					gameObject.transform.position=new Vector3(pos.X*10,pos.Y*10);
					x = false;
				}

			}

		}




	}

}
