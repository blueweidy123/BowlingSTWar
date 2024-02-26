using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    private bool _done;
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.collider.CompareTag("BowlingBall") || collision.collider.CompareTag("BowlingPin")) && !_done)
        {
            float velocity = GetComponent<Rigidbody>().velocity.magnitude;
            if (velocity < 10)
            {
                var point = GameObject.FindGameObjectWithTag("BowlingBall").GetComponent<BallController>().Point;
                point += 1;
                GameObject.FindGameObjectWithTag("Poing").GetComponent<TextMeshProUGUI>().text = $"Number of fallen pins: {point}";
                GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>().Point = point;
                _done = true;

            }
        }
    }
}
