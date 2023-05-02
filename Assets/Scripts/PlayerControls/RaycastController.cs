using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    Ray ray;
    RaycastHit2D hit;
    int layerMask;
    public Transform playerAvatar;
    public LineRenderer lineRenderer;
    public DynamicString targetName;
    public DynamicFloat targetDistance;

    // Start is called before the first frame update
    void Start()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(playerAvatar.position, playerAvatar.up, 100, layerMask);
        if (hit.collider != null)
        {
            Vector3 playerPoint = new Vector3(playerAvatar.position.x,
                playerAvatar.position.y, -5);
            Vector3 hitPoint = new Vector3(hit.point.x, hit.point.y, -5);

            lineRenderer.SetPosition(0, playerPoint);
            lineRenderer.SetPosition(1, hitPoint);

            targetName.Value = hit.transform.GetComponent<WorldObject>().visorName;
            targetDistance.Value = hit.distance - 0.1f;
        }
    }
}
