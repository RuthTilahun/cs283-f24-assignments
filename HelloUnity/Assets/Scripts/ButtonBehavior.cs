using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public MapCanvasController mapCanvasController;
    public CanvasGroup canvasGroup;
    public GameObject playerController;
    void Start()
    {
        //playerController.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Continue()
    {
        Debug.Log("You have clicked the button!");
        mapCanvasController.HideMapCanvas();
    }

    public void Expand()
    {
        Debug.Log("You have clicked the button!");
        mapCanvasController.ShowMapCanvas();
    }

   

    public void HidePage()
    {
        // Disable the welcome page
        playerController.SetActive(true);
        canvasGroup.alpha = 0; // Fully transparent
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        
    }

    // This function is linked to the Start button
    public void StartGame()
    {
        HidePage();

    }

   
}
