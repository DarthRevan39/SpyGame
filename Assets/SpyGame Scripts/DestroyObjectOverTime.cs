using UnityEngine;
using System.Collections;

public class DestroyObjectOverTime : MonoBehaviour {

    public float timeToWait = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, timeToWait);
	}
}
