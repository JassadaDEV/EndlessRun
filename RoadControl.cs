using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadControl : MonoBehaviour
{
	float speed = .5f;
		
	void Start()
	{

	}

	void Update()
	{
		float offset = Time.time * speed;
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -offset);
	}
}
