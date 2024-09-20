using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echolocation : MonoBehaviour
{
   [SerializeField] private AudioLoudnessDetection detector;
    [SerializeField] private Vector2 minScale;
    [SerializeField] private Vector2 maxScale;
    [SerializeField] private float loudnessSensibility = 100f;
    [SerializeField] private float audioThreshold = 0.1f;
    [SerializeField] private float tres = 2f;
    public AnimationCurve loudnessCurve;
    private void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < audioThreshold)
        {
            loudness = 0;
        }

        //lerp value from minScale to maxScale dpending on loudness
        transform.localScale = Vector2.Lerp(minScale*tres, maxScale*tres, loudnessCurve.Evaluate(loudness));

    }

}
