using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResetGame : MonoBehaviour
{
    public GameObject pinsPrefab;
    public GameObject ballPrefab;
    public GameObject pinsSpawnPoint;
    public GameObject ballSpawnPoint;
    public Button button;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Simulate a click on the button
            button.onClick.Invoke();
        }
    }

    public void exitgame()
    {
        Application.Quit();
    }

    public void StartGameLevel()
    {
        GameObject[] pins = GameObject.FindGameObjectsWithTag("BowlingPin");
        foreach (GameObject pin in pins)
        {
            Destroy(pin);
        }
        Destroy(GameObject.FindGameObjectWithTag("BowlingBall"));

        InstantiateObjectOnClick();
    }

        public void ResetGameLevel()
    {

        GameObject[] pins = GameObject.FindGameObjectsWithTag("BowlingPin");
        foreach (GameObject pin in pins)
        {
            Destroy(pin);
        }
        Destroy(GameObject.FindGameObjectWithTag("BowlingBall"));

        InstantiateObjectOnClick();

        GameObject.FindGameObjectWithTag("Poing").GetComponent<TextMeshProUGUI>().text = "";
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
