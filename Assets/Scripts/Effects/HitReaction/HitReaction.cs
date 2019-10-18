using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitReaction : MonoBehaviour
{

    public abstract void StartBlinking();

    public abstract IEnumerator Blink();

}
