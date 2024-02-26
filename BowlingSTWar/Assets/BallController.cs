using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    //chỉnh mass thành 20, force là 400 sẽ giống thật nhất
    Rigidbody rb;
    public float force = 400f;
    private bool _ballMoving;
    private Transform _startPosition;
    public int Point { get; set; }
    private TextMeshProUGUI feedBack;
    private List<GameObject> _pins = new();
    private readonly Dictionary<GameObject, Transform> _pinsDefaultTransform = new();
    [SerializeField] private Animator cameraAnim;
    public Player player;
    
    void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        _pins = GameObject.FindGameObjectsWithTag("BowlingPin").ToList();
        _startPosition = transform;
        foreach (var pin in _pins)
        {
            _pinsDefaultTransform.Add(pin, pin.transform);
        }
        feedBack = GameObject.FindGameObjectWithTag("FeedBack").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //if (Input.GetButtonUp("Fire1"))
        //{
        //    ShootBall();
        //}
        if (_ballMoving)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Shoot());
        }
    }

    void ShootBall()
    {
        rb.AddForce(transform.forward * force, ForceMode.Impulse);


    }
    private IEnumerator Shoot()
    {
        _ballMoving = true;
        rb.isKinematic = false;
        ShootBall();
        yield return new WaitForSecondsRealtime(7);

        _ballMoving = false;
        GenerateFeedBack();
        yield return new WaitForSecondsRealtime(2);

        ResetGame();

    }
    private static void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

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


        //GameObject.FindGameObjectWithTag("Feedback").GetComponent<TextMeshProUGUI>().text = $"{feedBack.text}";
        feedBack.GetComponent<Animator>().SetTrigger("Show");
    }
}
