﻿using UnityEngine;
using System.Collections;

public class trigger : MonoBehaviour {

	public Transform roadPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter (Collider othercollider){
		
		Instantiate (roadPrefab, new Vector3 (-4, 0, transform.parent.position.z+571f), roadPrefab.rotation);

	}


}
