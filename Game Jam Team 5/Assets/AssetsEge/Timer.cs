using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] Sprite[] numbers;
    [SerializeField] SpriteRenderer spriteRenderer_01;
    [SerializeField] SpriteRenderer spriteRenderer_10;
    [SerializeField] KelebekMotion kelebek;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;


    public int butterflyLife;
    private int second;
    // Start is called before the first frame update
    void Start()
    {
        butterflyLife = 3000;
        second = butterflyLife / 50;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);


        butterflyLife--;
        second = butterflyLife / 50;
        spriteRenderer_01.sprite = numbers[second % 10];
        spriteRenderer_10.sprite = numbers[second / 10];

        if (butterflyLife <= 0)
        {
            //change into proper death command !!
            //Destroy(kelebek);
            butterflyLife = 3000;
        }
    }
}
