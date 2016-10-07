using UnityEngine;
using System.Collections;

public class CloudCrafter : MonoBehaviour {

    // fields set in the Unity Inspector pane
    public int numClouds = 40; // The # of clouds to make
    public GameObject[] cloudPrefabs; // The prefabs to make
    public Vector3 cloudPosMin; // Min position of each cloud
    public Vector3 cloudPosMax; // Max position of each cloud
    public float cloudScaleMin = 1; // Min scale of each cloud
    public float cloudScaleMAx = 5; // Max scale of each cloud
    public float cloudSpeedMult = 0.5f; // Adjust speed of clouds

    public bool ________________________; // keeping us on the straight and narrow

    // fields ste dynamically
    public GameObject[] cloudInstances;

    void Awake () {
        // Make an array large enough to hold all the Cloud_ instances
        cloudInstances = new GameObject[numClouds];
        // Find the CloudAnchor parend GameObject
        GameObject anchor = GameObject.Find("CloudAnchor");
        // Iterate through and make Cloud_s
        GameObject cloud;
        for (int i=0; i<numClouds; i++) {
            // Pick an int between 0 and cloudPrefabs.Length-1
            // Random.Range will not even pick as high as the top number
            int prefabNum = Random.Range(0, cloudPrefabs.Length);
            // Make an instance
            cloud = Instantiate(cloudPrefabs[prefabNum]) as GameObject;
            // Position cloud
            Vector3 cpos = Vector3.zero;
            cpos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            cpos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);
            // Scale cloud
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMAx, scaleU);
            // Smaller clouds (with smaller scaleU) should be nearer the ground
            cpos.y = Mathf.Lerp(cloudPosMin.y, cpos.y, scaleU);
            // Smaller clouds should be further away
            cpos.z = 100 - 90 * scaleU;
            // Apply these transformations to the cloud
            cloud.transform.position = cpos;
            cloud.transform.localScale = Vector3.one * scaleVal;
            // Make cloud a shild of the anchor
            cloud.transform.parent = anchor.transform;
            // Add the cloud to cloudInstances
            cloudInstances[i] = cloud;
        }
	}
	
	void Update () {
	    // Iterate over each cloud that was created
        foreach (GameObject cloud in cloudInstances) {
            // Get the cloud scale and position
            float scaleVal = cloud.transform.localScale.x;
            Vector3 cPos = cloud.transform.position;
            // Move larger clouds faster
            cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;
            // If a cloud has moved too far to the left...
            if (cPos.x <= cloudPosMin.x) {
                // Move it to the far right
                cPos.x = cloudPosMax.x;
            }
            // Apply the new position to cloud
            cloud.transform.position = cPos;
        }
	}
}
