using UnityEngine;
using UnityEngine.Video;

public class CheckVideo : MonoBehaviour
{

    public float waitTime = 1;
    public int frameControls = 50;
    public GameObject creditPanel, controlsPanel;
    public string videoURL;
    bool displayedCreditPanel, displayedControls;
    int totalFrames, whichFrame, toInitfields;

    void Start()
    {
        //Debug.Log("CheckVideo script");
        SetURL();
    }

    public void SetURL()
    {
        if (GameObject.Find("ScriptFields").GetComponent<InitialSphereDisplay>().videoURL.Contains("https"))
        {
            //Debug.Log("URL to Pass to Sphere: " + GameObject.Find("ScriptFields").GetComponent<InitialSphereDisplay>().videoURL);
            this.gameObject.GetComponent<VideoPlayer>().url = GameObject.Find("ScriptFields").GetComponent<InitialSphereDisplay>().videoURL;
        }
        //Debug.Log("URL to Play: " + this.gameObject.GetComponent<VideoPlayer>().url);
        this.gameObject.GetComponent<VideoPlayer>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<VideoPlayer>().frame > 0)
        {
            toInitfields += 1;
            if (toInitfields == 1)
            {
                // Save URL to replay current video if they press restart
                GameObject.Find("ScriptFields").GetComponent<InitialSphereDisplay>().videoURL = this.gameObject.GetComponent<VideoPlayer>().url;
                //Debug.Log("Sphere URL: " + GameObject.Find("ScriptFields").GetComponent<InitialSphereDisplay>().videoURL + " saved");
            }

            totalFrames = (int)this.gameObject.GetComponent<VideoPlayer>().frameCount;
            whichFrame = (int)this.gameObject.GetComponent<VideoPlayer>().frame;

            if (this.gameObject.GetComponent<VideoPlayer>().isPlaying)
            {
                if (!displayedControls && whichFrame >= frameControls)
                {
                    displayedControls = true;
                    if (this.gameObject.GetComponent<VideoPlayer>().url.Contains("India"))
                    {
                        controlsPanel.transform.Find("ChangeMovieIceland").gameObject.SetActive(true);
                        controlsPanel.transform.Find("ChangeMovieIndia").gameObject.SetActive(false);
                    }
                    else
                    {
                        controlsPanel.transform.Find("ChangeMovieIndia").gameObject.SetActive(true);
                        controlsPanel.transform.Find("ChangeMovieIceland").gameObject.SetActive(false);
                    }
                    controlsPanel.SetActive(true);
                    //Debug.Log("Video Controls Displayed");
                }
            }
            else
            {
                if (whichFrame >= totalFrames && !displayedCreditPanel)
                {
                    Invoke("DisplayCredit", waitTime);
                    //Debug.Log("Should run DisplayCredit - last frame = " + whichFrame);
                    displayedCreditPanel = true;
                }
            }

        }

    }

    public void DisplayCredit()
    {
        controlsPanel.SetActive(false);
        //Debug.Log("Video Controls Deactivated");

        creditPanel.SetActive(true);
        //Debug.Log("Display Credit Panel");

        this.gameObject.SetActive(false);
    }

}