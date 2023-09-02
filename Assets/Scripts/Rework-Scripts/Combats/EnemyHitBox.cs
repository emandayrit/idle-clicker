using System;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    public static Action takeHit;

    private void OnMouseDown()
    {
        takeHit?.Invoke();
    }
}
