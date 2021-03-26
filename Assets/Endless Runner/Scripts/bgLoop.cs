using UnityEngine;

public class bgLoop : MonoBehaviour
{
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;

    public Transform backGroundParent;
    public SpriteRenderer lastBackground;

    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach (GameObject obj in levels)
        {
           // loadChildObjects(obj);
        }
    }


    private void Update()
    {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        /* foreach (GameObject obj in levels)
         {
             loadChildObjects(obj);
         }*/

        loadNextBG(levels[0]);
       
    }

    //void loadChildObjects(GameObject obj)
    //{
    //    SpriteRenderer spriteRen = obj.GetComponent<SpriteRenderer>();
    //    float objectWidth = spriteRen.bounds.size.x;
    //    int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);
    //   // GameObject clone = Instantiate(obj) as GameObject;
    //    for (int i = 0; i <= childsNeeded; i++)
    //    {
    //        GameObject c = Instantiate(obj) as GameObject;
    //        c.transform.SetParent(backGroundParent);
    //        c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
    //        c.name = obj.name + i;
    //    }
    //    //Destroy(clone);
    //    //Destroy(obj.GetComponent<SpriteRenderer>());
    //}

    void loadNextBG(GameObject obj)
    {
        //Thank you Daniel!! 
        if(lastBackground.bounds.max.x  > screenBounds.x)
        {
            GameObject nextBG = Instantiate(obj);

            Vector3 BGPos = lastBackground.transform.position;
            BGPos.x += lastBackground.size.x;

            nextBG.transform.position = BGPos;

            lastBackground = nextBG.GetComponent<SpriteRenderer>();
        }
    }
}
