using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject prefabSpawnee;

    // Use this for initialization
    void Start () {
        GameObject tGO = Instantiate(prefabSpawnee) as GameObject;
        tGO.transform.SetParent(transform.parent);
        tGO.transform.localPosition = transform.localPosition;
        tGO.transform.localRotation = tGO.transform.localRotation * transform.localRotation;
        Vector3 scale = tGO.transform.localScale;
        scale.Scale(transform.localScale);
        tGO.transform.localScale = scale;
        Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
