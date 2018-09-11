using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControls : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public Sprite playImage, pauseImage;

    public void PlayPauseVideo()
    {

        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            GetComponent<Image>().sprite = playImage;
        }
        else
        {
            videoPlayer.Play();
            GetComponent<Image>().sprite = pauseImage;
        }

    }
}
