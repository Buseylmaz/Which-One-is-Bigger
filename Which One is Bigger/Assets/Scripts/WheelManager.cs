using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelManager : MonoBehaviour
{

    [Header("Speed")]
    [SerializeField] float wheelSpeed;

    [Header("Wheel Prefabs")]
    [SerializeField] GameObject[] posWheelPrefabs;
    [SerializeField] GameObject[] negWheelPrefabs;


    void Update()
    {
        PosRotatorController(posWheelPrefabs, wheelSpeed);
        PosRotatorController(negWheelPrefabs, -wheelSpeed);

    }

    void PosRotatorController(GameObject[] wheelsPrefabs, float speed)
    {
        foreach (var wheel in wheelsPrefabs)
        {
            wheel.transform.Rotate(Vector3.forward * speed * Time.deltaTime);

        }
    }

}
