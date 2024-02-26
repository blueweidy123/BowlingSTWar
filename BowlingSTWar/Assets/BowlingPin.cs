
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    private bool _done;
    public bool isFallen;
    public float limit = 0.4f;
    public Transform pinBody;
    [SerializeField] private Animator cameraAnim;
    public Player player;
    void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.collider.CompareTag("BowlingBall") || collision.collider.CompareTag("BowlingPin")) && !_done)
        {
            float velocity = GetComponent<Rigidbody>().velocity.magnitude;

            if (velocity < 10)
            {
                UpdatePoints();
                _done = true;
            }
        }
    }
    private void UpdatePoints()
    {
        int point = 0;

        // Iterate through all the pins in the scene
        GameObject[] pins = GameObject.FindGameObjectsWithTag("BowlingPin");

        foreach (GameObject pin in pins)
        {
            // Get the initial and current rotations
            Quaternion initialRotation = Quaternion.Euler(-90, 0, 0) * Quaternion.Euler(pin.GetComponent<InitialRotation>().initialRotation);
            Quaternion currentRotation = pin.transform.rotation;

            // Calculate the absolute rotation difference
            float rotationDifference = Quaternion.Angle(initialRotation, currentRotation);

            // Check if the rotation difference exceeds the threshold
            if (Mathf.Abs(rotationDifference) > limit)
            {
                point++;
                pin.GetComponent<BowlingPin>().isFallen = true;
            }
        }

        // Update the UI or any other logic based on the points
        GameObject.FindGameObjectWithTag("Poing").GetComponent<TextMeshProUGUI>().text = $"Number of fallen pins: {point}";
        GameObject.FindGameObjectWithTag("BowlingBall").GetComponent<BallController>().Point = point;

    }
}
