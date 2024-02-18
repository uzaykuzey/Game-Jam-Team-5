using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSummoner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool original;
    [SerializeField] AudioSource boom;

    int lifeTime;

    public void summonExplosion(Vector2 position)
    {
        GameObject clonedObject = Instantiate(gameObject);
        clonedObject.transform.position = position;
        clonedObject.GetComponent<ExplosionSummoner>().original = false;
        lifeTime = 120;
        boom.Play();
    }

    private void FixedUpdate()
    {
        lifeTime=lifeTime==0?0 : lifeTime-1;
        if(lifeTime==0&&!original)
        {
            Destroy(gameObject);
        }
    }
}
