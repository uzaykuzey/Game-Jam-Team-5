using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;

    int attacked;
    // Update is called once per frame
    void Update()
    {
        if (attacked <= 0 && Input.GetKeyDown("x"))
        {
            attacked = 25;
            boxCollider.enabled = true;
            spriteRenderer.enabled = true;
        }
        if(attacked==0)
        {
            boxCollider.enabled = false;
            spriteRenderer.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if(attacked!=0)
        {
            if(attacked/13==1)
            {
                spriteRenderer.sprite = sprites[0];
            }
            else
            {
                spriteRenderer.sprite = sprites[1];
            }
        }
        attacked = attacked == 0 ? 0 : attacked - 1;
    }
}
