using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EffectsClip : PlayableAsset
{
    public float intensity;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<EffectsBehaviour>.Create(graph);

        EffectsBehaviour effectsBehaviour = playable.GetBehaviour();
        effectsBehaviour.intensity = intensity;

        return playable;
    }
}
