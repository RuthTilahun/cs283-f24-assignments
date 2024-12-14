using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUpdater : MonoBehaviour
{
    public Image[] mapOverlays; // Overlay images covering the map
    public float revealDuration = 0.2f; // Duration of the reveal animation

    // Reveals the map piece corresponding to the puzzle piece ID
    public void RevealMapPiece(int pieceID)
    { 
        StartCoroutine(FadeOutOverlay(mapOverlays[pieceID]));
    }

    private IEnumerator FadeOutOverlay(Image overlay)
    {
        float elapsedTime = 0;
        Color originalColor = overlay.color;
        Color targetColor = originalColor;
        targetColor.a = 0; // Set target alpha to 0 for full transparency

        while (elapsedTime < revealDuration)
        {
            elapsedTime += Time.deltaTime;
            overlay.color = Color.Lerp(originalColor, targetColor, elapsedTime / revealDuration);
            yield return null;
        }

        // Ensure it's fully transparent and deactivate the overlay
        overlay.color = targetColor;
        overlay.gameObject.SetActive(false);
    }

    // Check if all pieces are revealed
    public bool AreAllPiecesRevealed()
    {
        foreach (Image overlay in mapOverlays)
        {
            if (overlay.gameObject.activeInHierarchy)
                return false;
        }
        return true;
    }
}