using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Scriptable Bool")]
public class ScriptableBool : ScriptableObject
{
    public bool value;

    public IEnumerator SetAfterDelay(bool newVal, float delay)
    {
        yield return new WaitForSeconds(delay);
        value = newVal;
    }
}
