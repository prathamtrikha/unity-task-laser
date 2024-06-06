using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIPopUpAnimation : MonoBehaviour
{
    public float animationDuration = 0.5f; // Duration of the popup animation
    public float initialScale = 0.0f; // The initial scale of the UI element (e.g., completely shrunk)
    public float targetScale = 1.0f; // The final scale of the UI element (e.g., normal size)

    private void OnEnable()
    {
        // Ensure the UI element starts at the initial scale
        transform.localScale = Vector3.one * initialScale;

        // Play the pop-up animation
        PlayPopupAnimation();
    }

    private void PlayPopupAnimation()
    {
        // Animate the UI element scaling up to the target scale
        transform.DOScale(targetScale, animationDuration).SetEase(Ease.OutBounce);
    }
}
