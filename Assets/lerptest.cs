using UnityEditor.Rendering;
using UnityEngine;

public class lerptest : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float speed;
    private float elapsedtime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedtime += Time.deltaTime;
        float percentage = elapsedtime / speed;
        transform.position = Vector3.Lerp(start.position, end.position, percentage);
    }
}
