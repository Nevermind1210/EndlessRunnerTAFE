using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGeneration : MonoBehaviour
{
    public float obsticleCount;
    public GameObject[] obstacleSpawner;
    [SerializeField] GameObject ObsticalePattern01;
    [SerializeField] GameObject ObsticalePattern02;
    [SerializeField] GameObject ObsticalePattern03;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (obsticleCount == 0)
        {
            //then skip obsticleCount;
        }
        else
        {
            obsticleCount += 1;
        }
    }
}
