using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Crown : MonoBehaviour
{

    public float floatHeight = 0.5f; // Height of the floating effect
    public float floatDuration = 1.5f; // Duration of one floating cycle
    public float rotationDuration  = 90f; // Rotation speed in degrees per second

    void OnEnable()
    {
       // Floating animation
        Vector3 upPosition = transform.position + new Vector3(0, floatHeight, 0);
        Vector3 downPosition = transform.position;

        // Create a loop sequence for the floating effect
        Sequence floatSequence = DOTween.Sequence();
        floatSequence.Append(transform.DOMove(upPosition, floatDuration).SetEase(Ease.InOutSine));
        floatSequence.Append(transform.DOMove(downPosition, floatDuration).SetEase(Ease.InOutSine));
        floatSequence.SetLoops(-1); // Loop infinitely
    }


    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            GameBehaviour.Instance.ShowWinScreen();
        }
    }
}
