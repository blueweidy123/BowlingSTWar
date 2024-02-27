using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private string bowlingBallTag;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;
    private Transform target;

    void Start()
    {
        // Initially, find the BowlingBall object with the specified tag
        FindBowlingBallWithTag();
    }

    void Update()
    {
        // Check if the target is null (Ball not found)
        if (target == null)
        {
            // If the target is null, try to find it again
            FindBowlingBallWithTag();
            return;
        }

        // Calculate the target position with the offset applied
        Vector3 targetPosition = target.position + _offset;

        // Smoothly move towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }

    void FindBowlingBallWithTag()
    {
        // Find the BowlingBall object with the specified tag
        GameObject ballObject = GameObject.FindGameObjectWithTag(bowlingBallTag);
        if (ballObject != null)
        {
            target = ballObject.transform;
            // Calculate the initial offset between this object and the BowlingBall
            _offset = transform.position - target.position;
            Debug.Log("BowlingBall found with tag: " + bowlingBallTag);
        }
        else
        {
            Debug.LogError("BowlingBall object not found with tag: " + bowlingBallTag);
        }
    }

    public void Resetpos()
    {
            // Set the new position of the camera using specific coordinates
            transform.position = new Vector3(34.24f, -0.67f, 16.45f);
    }
}
