using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObject : MonoBehaviour {

    [SerializeField]
    GameObject lockObject = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (lockObject)
        {
            Destroy(lockObject);
            Destroy(gameObject);
        }
    }
}
