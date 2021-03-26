using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;
    private Transform lastPlatform;

    // Start is called before the first frame update
    void Start()
    {
        platformWidth = thePlatform.transform.localScale.x;
        distanceBetween = platformWidth;
        lastPlatform = thePlatform.transform;

        generationPoint.position = new Vector3(lastPlatform.position.x + distanceBetween, lastPlatform.position.y, lastPlatform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(generationPoint.position.x - transform.position.x < distanceBetween)
        {
            //transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            //Instantiate(thePlatform, transform.position, transform.rotation);

            generationPoint.position = new Vector3(lastPlatform.position.x + distanceBetween, lastPlatform.position.y, lastPlatform.position.z);

            lastPlatform = Instantiate(thePlatform, generationPoint.position, transform.rotation).transform;
        }

        // If the position - generation point is less than some amount (threshold)
            // Spawn platform
            // Move generation point to position + threshold
    }
}
