using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	[SerializeField] private float gameSpeed=4f;
	[SerializeField] private float switchingSpeed=0.001f;
	[SerializeField] private Cam camera;
	[SerializeField] private Player player;
	// Use this for initialization
	void Start () {
		resetParameters();
		camera.StartRunning();
		player.StartRunning();
	}
	void resetParameters(){
		camera.Speed=gameSpeed;
		player.Speed=gameSpeed;
		player.SwitchingSpeed=switchingSpeed;
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void orderCamera(float target){
		camera.GoToPlayer(target);
	}
}
