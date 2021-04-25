using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPrefab : MonoBehaviour
{
	public GameObject monster;
	public GameObject items;

	float timeElapsed = 0;
	float ItemCycle = 0.5f;
	bool ItemPowerup = true;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		timeElapsed += Time.deltaTime;
		if (timeElapsed > ItemCycle)
		{
			GameObject temp;
			if (ItemPowerup)
			{
				temp = (GameObject)Instantiate(items);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
			}
			else
			{
				temp = (GameObject)Instantiate(monster);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
			}

			timeElapsed -= ItemCycle;
			ItemPowerup = !ItemPowerup;
		}
	}
}
