using System.Collections;
using UnityEngine;

public class MapCanvasController : MonoBehaviour
{
    public CanvasGroup mapCanvasGroup; // Reference to the CanvasGroup of the map canvas
    public float fadeDuration = 0.5f; // Duration for fade in/out animations
    private bool isVisible = false; // Tracks whether the map is currently visible

    void Start()
    {
        // Ensure the map canvas starts hidden
        SetCanvasVisibility(false, instant: true);
    }

    void Update()
    {
        // Toggle the map canvas when the player presses the C key
        if (isVisible && Input.GetKeyDown(KeyCode.C))
        {
            HideMapCanvas();
        }
    }

    // Shows the map canvas with a fade-in effect
    public void ShowMapCanvas()
    {
        if (!isVisible)
        {
            isVisible = true;
            StartCoroutine(FadeCanvasGroup(mapCanvasGroup, 0, 1));
        }
    }

    // Hides the map canvas with a fade-out effect
    public void HideMapCanvas()
    {
        if (isVisible)
        {
            isVisible = false;
            StartCoroutine(FadeCanvasGroup(mapCanvasGroup, 1, 0));
        }
    }

    // Sets the canvas visibility instantly (used for initial setup)
    public void SetCanvasVisibility(bool visible, bool instant = false)
    {
        isVisible = visible;
        if (instant)
        {
            mapCanvasGroup.alpha = visible ? 1 : 0;
            mapCanvasGroup.interactable = visible;
            mapCanvasGroup.blocksRaycasts = visible;
        }
        else
        {
            StartCoroutine(FadeCanvasGroup(mapCanvasGroup, mapCanvasGroup.alpha, visible ? 1 : 0));
        }
    }

    // Coroutine for fading the CanvasGroup
    private IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float startAlpha, float endAlpha)
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            yield return null;
        }

        // Finalize the visibility state
        canvasGroup.alpha = endAlpha;
        canvasGroup.interactable = endAlpha > 0;
        canvasGroup.blocksRaycasts = endAlpha > 0;
    }
    public void ShowInstructionCanvas()
    {
   
            mapCanvasGroup.alpha = 1; // Make the canvas fully visible
            mapCanvasGroup.interactable = true; // Enable interaction with the canvas
            mapCanvasGroup.blocksRaycasts = true; // Enable the canvas to block raycasts
        
    }
}

