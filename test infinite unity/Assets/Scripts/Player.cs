using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player : MonoBehaviour {
	[SerializeField] private GameManager gameManager;
	//Running V
	[SerializeField] private float switchingDiff=1;
	[SerializeField] List<float> positions;
	private float speed;
	//Switching Lane
	private float switchingSpeed;
	private int position=1;
	private int nextPosition=0;
	private bool orderToMove=false;
	private float diff;
	//jump
	private bool enableJump=false;
	private bool jumping=false;
	private float jumpButtum=0.5f;
	[SerializeField] private float jumpTop;
	[SerializeField] private float jumpDiff;
	[SerializeField] private float TimeInAir;
	[SerializeField] private float JumpTime;
	//Compoents
	private Rigidbody rb;
	private Animator animator;
	void Start () {
		rb = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator>();
	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow)&&position<2){
			nextPosition=position+1;
			orderToMove=true;
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)&&position>0){
			nextPosition=position-1;
			orderToMove=true;
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)&&!enableJump){
			enableJump=true;
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)&&jumping){
			//forceToGoDown();
		}
	}
	void FixedUpdate (){
		if(orderToMove){
			diff=switchingDiff;
			if(nextPosition<position)
				diff=-diff;
			position=nextPosition;
			StartCoroutine(MoveToLane());
			StartCoroutine(wait());
			orderToMove=false;
		}
		if (enableJump) {
			if(!jumping){
				jumping=true;
				jump();
			}
			enableJump=false;
		}
	}
	public float Speed 
	{
     get{return speed;}
     set
	 {   
        speed=value;
     }
	 }
	 public float SwitchingSpeed 
	{
     get{return switchingSpeed;}
     set
	 {   
        switchingSpeed=value;
     }
	 }
	//Running
	public void StartRunning(){
		GetComponent<Rigidbody>().velocity=new Vector3(0,0,speed);
	}
	//Switching
	IEnumerator MoveToLane(){
		while(Mathf.Abs(transform.position.x-positions[nextPosition])>0.001f){
			transform.position=new Vector3(transform.position.x+diff,transform.position.y,transform.position.z);
			yield return new WaitForSeconds(switchingSpeed);
		}
	}
	//For Camera	 
	IEnumerator wait(){
		yield return new WaitForSeconds(0.1f);
		gameManager.orderCamera(positions[nextPosition]);
	}
	//Jumping Methods
	void jump(){
		StartCoroutine(jumpUp());
	}
	IEnumerator jumpUp(){
		while(transform.position.y<jumpTop){
			transform.position=new Vector3(transform.position.x,transform.position.y+jumpDiff,transform.position.z);
			yield return new WaitForSeconds(JumpTime);
		}
		yield return new WaitForSeconds(TimeInAir);
		StartCoroutine(jumpDown());
	}
	IEnumerator jumpDown(){
		while(transform.position.y>jumpButtum){
			transform.position=new Vector3(transform.position.x,transform.position.y-jumpDiff,transform.position.z);
			yield return new WaitForSeconds(JumpTime);
		}
		jumping=false;
	}
}
