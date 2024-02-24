using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera playerCamera;
    public Camera gameCamera;

    public bool isGameCameraActive = false;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera.enabled = true;
        gameCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isGameCameraActive = !isGameCameraActive;

            playerCamera.enabled = isGameCameraActive;
            gameCamera.enabled = !isGameCameraActive;
        }
    }
}
