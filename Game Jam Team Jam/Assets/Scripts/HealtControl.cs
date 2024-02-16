using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtControl : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer[] spriteRenderersOfHealths;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        for(int i=0;i<spriteRenderersOfHealths.Length;i++)
        {
            if(health/2>=i+1)
            {
                spriteRenderersOfHealths[i].sprite = sprites[0];
            }
            else if(health==(i+1)*2-1)
            {
                spriteRenderersOfHealths[i].sprite = sprites[1];
            }
            else
            {
                spriteRenderersOfHealths[i].sprite = sprites[2];
            }
        }
    }

    public void increaseHealth(int amount)
    {
        health += amount;
    }
}
