using UnityEngine;

public class ResetGame : MonoBehaviour
{
    public GameObject pinsPrefab;
    public GameObject ballPrefab;
    public GameObject pinsSpawnPoint;
    public GameObject ballSpawnPoint;

    public void ResetGameLevel()
    {
        Destroy(GameObject.FindGameObjectWithTag("BowlingPin"));
        Destroy(GameObject.FindGameObjectWithTag("BowlingBall"));

        InstantiateObjectOnClick();
    }

    public void InstantiateObjectOnClick()
    {
        if (pinsPrefab != null && pinsSpawnPoint != null)
        {
            Instantiate(pinsPrefab, pinsSpawnPoint.transform.position, pinsSpawnPoint.transform.rotation);
        }

        if (ballPrefab != null && ballSpawnPoint != null)
        {
            Instantiate(ballPrefab, ballSpawnPoint.transform.position, ballSpawnPoint.transform.rotation);
        }
    }
}
