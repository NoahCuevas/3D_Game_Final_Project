using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class video_player : MonoBehaviour
{
    [SerializeField]
    VideoPlayer myVideoPlayer;

    void Start()
    {
        // how we know the end of the video has been reached
        myVideoPlayer.loopPointReached += endOfVideo;
    }

    // Function to skip the video
    public void SkipVideo()
    {
        myVideoPlayer.Stop();
        SceneManager.LoadScene("SampleScene");
    }

    // once video ends, we want to load the scene of the actual game
    void endOfVideo(VideoPlayer vp)
    {
        SceneManager.LoadScene("SampleScene");
    }
}
