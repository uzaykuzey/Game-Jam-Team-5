using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;

    int attacked;
    int attackCooldown;
    // Update is called once per frame
    void Update()
    {
        if (attackCooldown<=0&&attacked <= 0 && Input.GetKeyDown("x"))
        {
            attacked = 7;
            boxCollider.enabled = true;
            spriteRenderer.enabled = true;
            attackCooldown = 30;
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
            if(attacked/4==1)
            {
                spriteRenderer.sprite = sprites[0];
            }
            else
            {
                spriteRenderer.sprite = sprites[1];
            }
        }
        attacked = attacked == 0 ? 0 : attacked - 1;
        attackCooldown = attackCooldown == 0 ? 0 : attackCooldown - 1;
    }
}
