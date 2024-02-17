using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafCollector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite[] numbers;
    [SerializeField] SpriteRenderer spriteRenderer;
    public int collectedLeafAmount;
    void Start()
    {
        collectedLeafAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = numbers[collectedLeafAmount%10];
    }
}
