using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerPlaybackCalculator : MonoBehaviour {

    [SerializeField]
    VideoPlayer player;

	// Use this for initialization
	void Start () {
        player = GetComponent<VideoPlayer>();
        player.playbackSpeed = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (player.isPlaying)
            player.playbackSpeed = (1.0f / 30.0f) / Time.unscaledDeltaTime;
        else
            player.playbackSpeed = 1.0f;
	}
}
