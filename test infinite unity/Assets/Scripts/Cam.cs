using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {
	private float speed;
	private float diff;
	private float target;
	[SerializeField] private float sideMovingSpeed;
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity=new Vector3(0,0,speed);
	}
	public void StartRunning(){
		
	}
	public float Speed 
	{
     get{return speed;}
     set
	 {   
        speed=value;
     }
	 }
	public void GoToPlayer(float t){
		StopAllCoroutines();
		if(transform.position.x<t)
			diff=1f;
		else
			diff=-1f;
		target=t;
		print (target);
		StartCoroutine(move());
	}
	IEnumerator move(){
		while(Mathf.Abs(transform.position.x-target)>0.1f){
			transform.position=new Vector3(transform.position.x+diff,transform.position.y,transform.position.z);
			yield return new WaitForSeconds(sideMovingSpeed);
		}
	}
}
