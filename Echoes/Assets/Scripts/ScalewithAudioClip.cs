using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalewithAudioClip : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioLoudnessDetection detector;
    [SerializeField] private Vector2 minScale;
    [SerializeField] private Vector2 maxScale;
    [SerializeField] private float loudnessSensibility = 100f;
    [SerializeField] private float audioThreshold = 0.1f;

    private void Update()
    {
        float loudness = detector.GetLoudnessFromAudioClip(source.timeSamples, source.clip) * loudnessSensibility;

        if(loudness<audioThreshold)
        {
            loudness = 0;
        }
        //lerp value from minScale to maxScale dpending on loudness
        transform.localScale = Vector2.Lerp(minScale, maxScale, loudness);

    }

}
