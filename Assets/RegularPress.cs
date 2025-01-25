using System.Collections;
using UnityEngine;

public class RegularPress : MonoBehaviour
{
    public GameObject movingpart;
    public Transform end;
    public Transform start;
    public float speed = 5f;
    public float waittime = 10f;
    private float elapsedtime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        while (true)
        {
            StartCoroutine("Lerping");
            
           
          
        }

    }
    IEnumerator Lerping()
    {

        elapsedtime += Time.deltaTime;
        float percentage = elapsedtime / speed;
        movingpart.transform.position = Vector3.Lerp(start.position, end.position, percentage);
        yield return new WaitForSeconds(waittime);
        movingpart.transform.position = Vector3.Lerp(end.position, start.position, percentage);
        yield return new WaitForSeconds(waittime);
    }

}