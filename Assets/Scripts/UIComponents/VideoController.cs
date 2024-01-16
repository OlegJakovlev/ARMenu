using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] private RawImage _rawImage;

    private RenderTexture _renderTexture;
    private VideoPlayer _videoPlayer;

    public void Setup()
    {
        _videoPlayer = gameObject.AddComponent<VideoPlayer>();
        _videoPlayer.playOnAwake = true;
        _videoPlayer.waitForFirstFrame = true;
        _videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        _videoPlayer.isLooping = true;

        _renderTexture = new RenderTexture(1920, 1080, 0, RenderTextureFormat.ARGB32)
        {
            wrapMode = TextureWrapMode.Clamp,
            filterMode = FilterMode.Bilinear
        };
        _renderTexture.Create();
        
        _videoPlayer.targetTexture = _renderTexture;
        _rawImage.texture = _renderTexture;
        
        _videoPlayer.Prepare();
        _videoPlayer.prepareCompleted += OnVideoPrepared;
    }
    
    public void SetClip(VideoClip clip)
    {
        _videoPlayer.clip = clip;
        for (ushort i = 0; i < _videoPlayer.audioTrackCount; i++)
        {
            _videoPlayer.SetDirectAudioVolume(i, 0.01f);
        }
        _videoPlayer.Play();
    }

    public void Play()
    {
        if (_videoPlayer == null)
        {
            return;
        }
        
        _videoPlayer.Play();
    }

    public void Stop()
    {
        _videoPlayer.Stop();
    }

    public void Release()
    {
        _videoPlayer.prepareCompleted -= OnVideoPrepared;
        
        _videoPlayer.targetTexture.Release();
        _renderTexture.Release();

        _rawImage.texture = null;
        _videoPlayer.targetTexture = null;
    }

    public void ToggleSound()
    {
        _videoPlayer.Pause();

        for (ushort i = 0; i < _videoPlayer.audioTrackCount; i++)
        {
            _videoPlayer.EnableAudioTrack(i, !_videoPlayer.IsAudioTrackEnabled(i));
        }

        _videoPlayer.Play();
    }
    
    private void OnVideoPrepared(VideoPlayer player)
    {
        _videoPlayer = player;
    }
}
