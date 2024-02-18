using UnityEngine;

public class KozaChange : MonoBehaviour
{
    [SerializeField] GameObject[] koza;
    [SerializeField] Transform tirtilTransform;
    [SerializeField] LayerMask caterpillar;
    [SerializeField] BoxCollider2D BoxCollider2D;

    public GameObject Kelebek;
    bool metamorphosed;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        metamorphosed = false;
    }

    private void Update()
    {
        if(!metamorphosed)
        {
            if(Physics2D.IsTouchingLayers(BoxCollider2D, caterpillar))
            {
                Destroy(tirtilTransform.gameObject);
                metamorphosed = true;
                counter = 200;
            }
        }

    }

    void FixedUpdate()
    {
        if (counter > 0)
        {
            counter--;
        }
        if(metamorphosed)
        {
            if (counter == 199)
            {
                gameObject.transform.position = new Vector3(100, 0, 0);
                koza[0].transform.position = new Vector3(0.58f, -1.524f, -0.92f);
            }
            if (counter == 150)
            {
                Destroy(koza[0]);
                koza[1].transform.position = new Vector3(0.58f, -1.524f, -0.92f);
            }
            if (counter == 110)
            {
                Destroy(koza[1]);
                koza[2].transform.position = new Vector3(0.58f, -1.524f, -0.92f);
            }
            if (counter == 70)
            {
                Destroy(koza[2]);
                koza[3].transform.position = new Vector3(0.58f, -1.524f, -0.92f);
            }
            if (counter == 30)
            {
                Destroy(koza[3]);
                Kelebek.transform.position = new Vector3(0.59f, -2.33f, -1f);
                koza[4].transform.position = new Vector3(0.58f, -1.524f, -0.92f);
            }
        }
    }
}