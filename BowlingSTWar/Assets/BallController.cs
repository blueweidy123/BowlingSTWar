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

    public GameObject Marcador;
    public float followSpeed = 30f;
    public float rotationSpeed = 30f;

    public GameObject Direction;
    private ResetGame resetGame;
    Vector3 launchDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Marcador = GameObject.FindWithTag("Marcador");
        if (Marcador == null)
        {
            Debug.LogError("Marcador GameObject not found.");
        }

        _pins = GameObject.FindGameObjectsWithTag("BowlingPin").ToList();
        _startPosition = transform;
        foreach (var pin in _pins)
        {
            _pinsDefaultTransform.Add(pin, pin.transform);
        }
        feedBack = GameObject.FindGameObjectWithTag("FeedBack").GetComponent<TextMeshProUGUI>();

        Marcador = GameObject.FindWithTag("Marcador");
        if (Marcador == null)
        {
            Debug.LogError("Marcador GameObject not found.");
        }
        //animn = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (_ballMoving)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(Shoot());
        }

        // Find the object with the "Direction" tag
        GameObject directionObject = GameObject.FindGameObjectWithTag("Direction");

        // Check if the directionObject is not null
        if (directionObject != null)
        {
            // Enable the object
            directionObject.SetActive(true);
        }

        FollowMarcador();
    }


    void FollowMarcador()
    {
        Vector3 directionToMarcador = Marcador.transform.position - transform.position;

        directionToMarcador.y = 0f;

        directionToMarcador.Normalize();

        Quaternion targetRotation = Quaternion.LookRotation(directionToMarcador, Vector3.up);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }


    void ShootBall()
    {
        Vector3 forwardDirection = transform.forward;

        forwardDirection = Quaternion.Euler(0f, 10f, 0f) * forwardDirection;

        rb.AddForce(forwardDirection * force, ForceMode.Impulse);
    }
    private IEnumerator Shoot()
    {
        _ballMoving = true;
        rb.isKinematic = false;
        ShootBall();
        yield return new WaitForSecondsRealtime(7);

        _ballMoving = false;
        yield return new WaitForSecondsRealtime(2);

        ResetGame();

    }
    private static void ResetGame()
    {
        

    }

}
