using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    [SerializeField] LeafCollector collector;
    [SerializeField] BoxCollider2D boxCollider;
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
        if (Physics2D.IsTouchingLayers(boxCollider, playerLayer))
        {
            collector.collectedLeafAmount++;
            transform.position = new Vector3(1000, 0, 0);
            print(collector.collectedLeafAmount);
        }
    }
}
