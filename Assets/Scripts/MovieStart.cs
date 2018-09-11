using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MovieStart : MonoBehaviour
{
    public GameObject movieSphere, titlePanel;
    public string videoURL, URLVideo;

    public void DisplaySphere()
    {
        Debug.Log("DisplaySphere");

        if (this.gameObject.name.Contains("ButtonRestart"))
        {
            // Do nothing - URL already saved in Check Video Script
        }
        else
        {
            GameObject.Find("ScriptFields").GetComponent<InitialSphereDisplay>().videoURL = videoURL;
        }
        //Debug.Log("Button Pressed: " + this.gameObject.name);
        //Debug.Log("URL to Play: " + GameObject.Find("ScriptFields").GetComponent<InitialSphereDisplay>().videoURL);

        // Reset scene to initial state
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Destroy title panel if active
        if (this.gameObject.name.Contains("ChangeMovie"))
        {
            // Movie is playing - No title to turn off
        }
        else if (titlePanel.activeSelf)
        {
            titlePanel.SetActive(false);
        }

    }

}
