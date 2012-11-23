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
	}
	
	void GetLocomotionInput() 
	{
		
	}
	
}
