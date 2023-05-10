using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EffectsBehaviour : PlayableBehaviour
{
    public float intensity;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        Material effect = playerData as Material;

        float strength = intensity * info.weight;
        effect.SetFloat("_Strength", strength);
    }
}
