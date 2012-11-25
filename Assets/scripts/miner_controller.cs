using UnityEngine;
using System.Collections;

public class miner_controller : MonoBehaviour {
	
	public static CharacterController CharacterController;
	public static miner_controller Instance;
	
	
	void Awake () 
	{
		CharacterController = GetComponent("CharacterController") as CharacterController;
		Instance = this;
	}
	
	void Update () 
	{
		
		if (Camera.mainCamera == null) 
		{
			return;
		}
		
		GetLocomotionInput();
		
		miner_motor.Instance.UpdateMotor();
	}
	
	void GetLocomotionInput() 
	{
		var deadZone = 0.1f;
		
		//This keeps the motion from being additive. It is being recalculated for every frame
		miner_motor.Instance.MoveVector = Vector3.zero;
		
		//if (Input.GetAxis("Vertical") > deadZone || Input.GetAxis("Verticle") < -deadZone) 
		//	miner_motor.Instance.MoveVector += new Vector3(0,0, Input.GetAxis("Vertical"));	
		
		if (Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone) 
		{
			miner_motor.Instance.MoveVector += new Vector3(Input.GetAxis("Horizontal"),0, 0);	
		}
		
	}
	
}
