using UnityEngine;
using System.Collections;

public class miner_motor : MonoBehaviour 
	{
	
	public static miner_motor Instance;
	
	public float MoveSpeed = 10f;
	
	public Vector3 MoveVector { get; set; }
	
	void Awake () 
	{
		Instance = this;
	}
	
	void UpdateMotor () 
	{
		RotateCharacter ();
		ProcessMotion ();
	}
	
	void ProcessMotion () 
	{
		
		//Transform MoveVector to World Space
		MoveVector = transform.TransformDirection(MoveVector);
		
		//Normalize Move Vector if Magnitude > 1
		if (MoveVector.magnitude > 1) 
		{
			MoveVector = Vector3.Normalize(MoveVector);
		}
		
		//Multiply MoveVector by Speed
		MoveVector *= MoveSpeed;
		
		
		//Multiply Move Vector by DeltaTime
		MoveVector *= Time.deltaTime;
		
		//Move the Character in the World
		miner_controller.CharacterController.Move(MoveVector);
		
	}
	
	//This will can the direction in which the character is facing
	void RotateCharacter () 
	{
		if (MoveVector.x < 0) {
        	transform.eulerAngles = Vector3(0,180,0);
 		}
		
		if (MoveVector.x  >= 0) {
        	transform.eulerAngles = Vector3(0,0,0);
 		}
	}
}
