using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform laserPosition;

    private void Start()
    {
        lineRenderer.enabled = false;
    }
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        lineRenderer.SetPosition(0, laserPosition.position);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(lineRenderer.isVisible)
            {
                Debug.Log("Is Visible");
                lineRenderer.enabled = false;
            }
            else
            {
                lineRenderer.enabled = true;
            }
        }
        if(hit)
        {
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(1, transform.right * 100);
        }
    }
}