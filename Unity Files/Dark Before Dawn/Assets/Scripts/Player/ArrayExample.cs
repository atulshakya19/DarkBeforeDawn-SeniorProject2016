using UnityEngine;
using System.Collections;

public class ArrayExample : MonoBehaviour {

	public int[] Scores =  new int[10];
	public string[] Names = new string[10];

	public class ArrayClass
	{
	}
	//this one will not show up in the inspector panel
	public ArrayClass[] MyArray= new ArrayClass[10];

	public GameObject[] MyGameObjects;

	public int ArrayLength;

	// we can set the values in the array upon declaration
	public int[] Primes = new int[]{1,3,5,7,9};

	// Use this for initialization
	void Start () 
	{
		Debug.Log (MyGameObjects.Length);

		for (int i = 0; i < MyGameObjects.Length; i++)
		{
			MyGameObjects[i].name = i.ToString();
		}
		foreach (GameObject go in MyGameObjects) 
		{
			Debug.Log (go.name);
		}
		//dynamic initialization
		float[] DynamicFloats = new float[ArrayLength];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
