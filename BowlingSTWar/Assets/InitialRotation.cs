using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialRotation : MonoBehaviour
{
    // Store the initial rotation during initialization
    public Vector3 initialRotation;

    void Start()
    {
        // Set the initial rotation when the object is instantiated
        initialRotation = transform.rotation.eulerAngles;
    }
}
