using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera playerCamera;
    public Camera gameCamera;

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera.enabled = true;
        gameCamera.enabled = false;
        player = GetComponent<Player>();

        // Subscribe to the event
        player.OnIsPlayingChanged += OnIsPlayingChangedHandler;
    }

    void OnDestroy()
    {
        // Unsubscribe from the event to avoid memory leaks
        player.OnIsPlayingChanged -= OnIsPlayingChangedHandler;
    }

    void OnIsPlayingChangedHandler(bool newValue)
    {
        playerCamera.enabled = !newValue;
        gameCamera.enabled = newValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            player.isPlaying = !player.isPlaying;

            playerCamera.enabled = !player.isPlaying;
            gameCamera.enabled = player.isPlaying;
        }
    }
}
