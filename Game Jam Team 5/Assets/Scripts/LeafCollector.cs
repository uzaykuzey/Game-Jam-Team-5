using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LeafCollector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite[] numbers;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] TilemapCollider2D tilemapCollider;
    [SerializeField] TilemapRenderer tilemapRenderer;

    public int collectedLeafAmount;
    void Start()
    {
        collectedLeafAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = numbers[collectedLeafAmount%10];
        if(collectedLeafAmount>=5)
        {
            tilemapCollider.enabled = false;
            tilemapRenderer.enabled = false;
        }
    }
}
