using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MotionMixer : PlayableBehaviour
{
    private Vector3 defaultPosition;

    private Transform transform;
    private bool firstFrameHappened;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData) {
        transform = playerData as Transform;

        if(transform == null) {
            Debug.Log("Transform Null");
            return;
        }

        if (!firstFrameHappened) {
            defaultPosition = transform.position;
            firstFrameHappened = true;
        }

        int inputCount = playable.GetInputCount();

        Vector3 blendedPosition = Vector3.zero;
        float totalHeight = 0f;

        for (int i = 0; i < inputCount; ++i) {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<MotionBehaviour> inputPlayable = (ScriptPlayable<MotionBehaviour>)playable.GetInput(i);
            MotionBehaviour behaviour = inputPlayable.GetBehaviour();

            blendedPosition += behaviour.trackPosition * inputWeight;
            totalHeight += inputWeight;
        }

        //float remainingWeight = 1 - totalHeight;
        //Debug.Log($"Blend: {blendedPosition} \n  Default: {defaultPosition} * remaining: {remainingWeight}");

        transform.position = blendedPosition + defaultPosition; // * remainingWeight;
    }

    public override void OnPlayableDestroy(Playable playable) {

        firstFrameHappened = false;

        if (transform == null)
            return;

        transform.position = defaultPosition;

    }
}
