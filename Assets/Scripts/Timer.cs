using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;
using UnityEngine.TextCore.Text;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;

    private GameObject Boat;
    public GameObject Explosion;
    private GameObject selectedHuman;

    private DateTime startTime;
    private DateTime endTime;

    private bool isGameEnded = false;

    private void Start()
    {
        startTime = DateTime.Now;
        Debug.Log("StartTime" + startTime);

        Boat = GameObject.Find("Boat");

        string logFilePath = Application.persistentDataPath;
        Debug.Log(logFilePath);
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(logFilePath, 1 + ".txt"), true))
        {
            outputFile.WriteLine("StartTime: " + startTime);
            Debug.Log(outputFile);
        }

    }

    void Update()
    {
        GameObject selectedObject = GameObject.FindGameObjectWithTag("selected");
        string type = selectedObject.name.Split(' ')[0];

        if (selectedObject != selectedHuman)
        {
            selectedHuman = selectedObject;
            Debug.Log("Human selected" + type + " at: " + DateTime.Now);
        }
        
        if (!isGameEnded)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }

            if (remainingTime < 0)
            {
                remainingTime = 0;
                timerText.color = Color.red;
                GameObject canvas = GameObject.Find(type + " " + "Canvas");
                canvas.GetComponent<Canvas>().enabled = false;
                Instantiate(Explosion, Boat.transform.position, Quaternion.identity);
                Boat.SetActive(false);
                Debug.Log("EndTime" + DateTime.Now);
                isGameEnded = true; 
            }

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    /*
    void LogSelection(GameObject selectedObject)
    {
        // Log the selected object's information
        string logEntry = "";
        if (selectedObject != null)
        {
            logEntry = "Object selected: " + selectedObject.name + ", Position: " + selectedObject.transform.position + ", Time: " + DateTime.Now;
        }
        else
        {
            logEntry = "Object deselected" + ", Time: " + DateTime.Now;
        }

        // Write the log entry to the log file
        logStreamWriter.WriteLine(logEntry);
    }

    public void EndStudy()
    {
        // Record the end time when the study ends
        endTime = DateTime.Now;

        // Log the start and end time
        logStreamWriter.WriteLine("Study started: " + startTime);
        logStreamWriter.WriteLine("Study ended: " + endTime);

        // Close the log file
        logStreamWriter.Close();
        Debug.Log("closed file");

        // Indicate that the game has ended
        isGameEnded = true;
    }*/
}
