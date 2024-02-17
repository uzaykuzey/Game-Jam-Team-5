using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafCollector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite[] numbers;
    [SerializeField] SpriteRenderer spriteRenderer;
    int collectedLeafAmount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = numbers[collectedLeafAmount];
    }
}
