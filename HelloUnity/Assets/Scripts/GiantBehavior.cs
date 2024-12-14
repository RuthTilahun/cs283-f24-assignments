using UnityEngine;
using UnityEngine.AI;

public class GiantBehavior : MonoBehaviour
{
    public Transform player; // Reference to the player character
    public float stoppingDistance = 0.5f; // Distance at which the NPC stops following
    public float soundTriggerDistance = 10f; // Distance within which the player hears the walk sound
    public float maxVolume = 1f; // Maximum volume of the walking sound
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip walkSound; // Sound to play while walking
    private NavMeshAgent agent; // Reference to the NavMeshAgent component
    private bool isPlayingSound = false; // Tracks if the walking sound is currently playing

    void Start()
    {
        // Get the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component not found on NPC!");
        }

        // Set the stopping distance on the NavMeshAgent
        agent.stoppingDistance = stoppingDistance;

        // Ensure the audio source is ready
        if (audioSource != null && walkSound != null)
        {
            audioSource.clip = walkSound;
            audioSource.loop = true;
            audioSource.volume = 0; // Start with volume at 0
            audioSource.Play(); // Start playing the sound
        }
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player transform is not assigned!");
            return;
        }

        // Set the player's position as the target for the NavMeshAgent
        agent.SetDestination(player.position);

        // Check distance to the player
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= soundTriggerDistance)
        {
            // Calculate the volume based on the distance
            float volume = Mathf.Lerp(0, maxVolume, 1 - (distanceToPlayer / soundTriggerDistance));
            audioSource.volume = volume;
        }
        else
        {
            // Smoothly lower the volume to 0 when out of range
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0, Time.deltaTime * 2f);
        }

        // Optional: Make the NPC face the player when close
        if (agent.remainingDistance <= stoppingDistance && !agent.pathPending)
        {
            FacePlayer();
        }
    }

    private void FacePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0; // Keep the NPC upright
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}
