using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

	public GameObject words;

	private List<Transform> letterFragments;

	private float intervalRefresh = 0;
	private float interval = 0.075f;
	private float startTime;
	private float beginRender = 2.0f;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		letterFragments = new List<Transform> ();
		if (words) {
			for (int i = 0; i < words.transform.childCount; i++) {
				for (int j = 0; j < words.transform.GetChild (i).childCount; j++) {
					letterFragments.Add (words.transform.GetChild (i).GetChild (j));
					words.transform.GetChild (i).GetChild (j).gameObject.SetActive (false);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime > beginRender && letterFragments.Count > 0) {
			if (Time.time - intervalRefresh > interval) {
				int randomSpot = (int)Random.Range (0, letterFragments.Count);
				letterFragments [randomSpot].gameObject.SetActive (true);
				letterFragments.Remove (letterFragments [randomSpot]);
				intervalRefresh = Time.time;
			}
		}
	}
}
