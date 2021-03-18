using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class MotionClip : PlayableAsset, ITimelineClipAsset {

    [SerializeField]
    private MotionBehaviour template = new MotionBehaviour();


    public ClipCaps clipCaps => ClipCaps.Blending;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) {
        return ScriptPlayable<MotionBehaviour>.Create(graph, template);
    }
}
