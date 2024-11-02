using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CollectionGame : MonoBehaviour
{
    public TextMeshProUGUI score;
    public int scoreCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            scoreCount++;
            other.gameObject.SetActive(false);
            score.SetText(scoreCount.ToString());
        }
    }
}
