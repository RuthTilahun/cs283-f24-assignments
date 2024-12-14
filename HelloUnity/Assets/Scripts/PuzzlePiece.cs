using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour
{
    public int pieceID; // Unique ID for each puzzle piece
    public Transform player;
    public GameObject mapPiece; // The 3D map piece object to rise, spin, and grow
    private Animation anim;
    private bool isOpen = false; // To track if the chest is already open
    public Transform mapDisplayPosition; // position the mapPiece will rise to
    public MapUpdater mapUpdater; // Reference to the MapUpdater to update the map
    public MapUpdater cornerMapUpdater; // Reference to the MapUpdater to update the corner map
    public MapCanvasController mapCanvasController; // Reference to the MapCanvasController to show the map
    public MapCanvasController instructionCanvasController;
    public MapCanvasController winnerCanvasController;
    public AudioSource audioSource; // Audio source for playing sounds
    public AudioClip fullMapRevealedClip; // Sound for full map revealed
    public AudioClip mapPieceRisingClip; // Sound for map piece rising
    public Transform gate;
    private Quaternion targetRotation;
    private float rotationSpeed = 2.0f;
    private bool isMapRevealed = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        if (mapPiece != null)
        {
            mapPiece.SetActive(false); // Ensure map piece is initially inactive
        }
        targetRotation = gate.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOpen && (player.position - transform.position).magnitude < 20.0f)
        {
            instructionCanvasController.ShowInstructionCanvas();
            if (Input.GetKeyDown(KeyCode.O))
            {
                StartCoroutine(OpenChestAndRevealMap());
            }
        }
        //if all piece are revealed, open gate by rotating it  180 degrees along the Y axis
        if (mapUpdater.AreAllPiecesRevealed() && !isMapRevealed)
        {
            isMapRevealed = true;
            Debug.Log("All pieces are revealed!");
            audioSource.PlayOneShot(fullMapRevealedClip);
            mapCanvasController.ShowMapCanvas();
            gate.transform.rotation = Quaternion.Euler(90, 270, 0);
            
        }
        if ((player.position - gate.position).magnitude < 10.0f && isMapRevealed)
        {
            winnerCanvasController.ShowInstructionCanvas();

        }

    }
    
    IEnumerator OpenChestAndRevealMap()
    {
        isOpen = true; // Mark chest as open

        // Play chest opening animation
        Debug.Log("Opening chest...");
        anim.Play("Open");

        // Wait for the animation to finish
        yield return new WaitForSeconds(anim.clip.length - 1.0f);

        // Play the map piece animation, map piece comes out of chest
        StartCoroutine(MapPieceAnimation());
        yield return new WaitForSeconds(5.0f);
        mapPiece.SetActive(false);
        // Reveal the map canvas
        cornerMapUpdater.RevealMapPiece(pieceID);
        //mapCanvasController.ShowMapCanvas();
        mapUpdater.RevealMapPiece(pieceID);
    }
    public void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        mapCanvasController.ShowMapCanvas();
    }
     IEnumerator MapPieceAnimation()
     {
        // Activate the map piece
        mapPiece.SetActive(true);

        // Play the sound for the map piece rising
        //audioSource.PlayOneShot(mapPieceRisingClip);

        // Animate the map piece rising, spinning, and growing
        Vector3 originalPosition = mapPiece.transform.position;
        Vector3 targetPosition = mapDisplayPosition.position;

        Vector3 originalScale = mapPiece.transform.localScale;
        Vector3 targetScale = Vector3.one * 3.0f; 


        float riseTime = 3.0f; // Time for the map piece to rise
        float elapsedTime = 0;

        while (elapsedTime < riseTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / riseTime;
            audioSource.PlayOneShot(mapPieceRisingClip);

            // Interpolate position
            mapPiece.transform.position = Vector3.Lerp(originalPosition, targetPosition, progress);

            // Rotate the map piece
            //mapPiece.transform.Rotate(Vector3.up, 360 * Time.deltaTime);

            // Increase scale
            mapPiece.transform.localScale = Vector3.Lerp(originalScale, targetScale, progress);

            yield return null;
        }
        //mapPiece.transform.position = targetPosition;
        //mapPiece.transform.localScale = targetScale;
     }
}
