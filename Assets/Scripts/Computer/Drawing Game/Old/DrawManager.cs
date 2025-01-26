using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public GameObject drawPrefab;
    public TrailRenderer trailRenderer;
    private GameObject Trail;
    public List<GameObject> TrailList = new List<GameObject>();
    private Plane planeObj;
    private Vector3 mousePos;

    public bool trailIsActive = false;

    void Start()
    {
        //planeObj = new Plane(Camera.main.transform.forward * -1, this.transform.position);
        trailRenderer.emitting = false;
    }

    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        drawPrefab.transform.position = Vector2.Lerp(transform.position, mousePos, 1);
        transform.position = Vector2.Lerp(transform.position, mousePos, 1);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            Trail = (GameObject)Instantiate(drawPrefab, this.transform.position, Quaternion.identity);
            TrailList.Add(Trail);
            if (TrailList.Count > 0)
            {
                Destroy(TrailList[0].gameObject);
                TrailList.RemoveAt(0);
            }

        }
        else
        {
            trailRenderer.emitting = false;
            trailIsActive = false;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButton(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            trailRenderer.emitting = true;
            trailIsActive = true;
        }
        else
        {
            trailRenderer.emitting = false;
            trailIsActive = false;
        }
    }
}
