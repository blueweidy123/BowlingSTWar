using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //chỉnh mass thành 20, force là 400 sẽ giống thật nhất
    Rigidbody rb;
    public float force = 400f;
    public int Point { get; set; }
    private TextMeshProUGUI feedBack;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        feedBack = GameObject.FindGameObjectWithTag("FeedBack").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            ShootBall();
        }
    }

    void ShootBall()
    {
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
        GenerateFeedBack();
    }
    private void GenerateFeedBack()
    {
        feedBack.text = Point switch
        {
            0 => "nothing",
            > 0 and < 3 => "You are learning now!",
            >= 3 and < 6 => "It was close!",
            >= 6 and < 10 => "It was nice!",
            _ => "Perfect! You are a master!"
        };
        feedBack.GetComponent<Animator>().SetTrigger("Show");
    }
}
