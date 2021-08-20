using UnityEngine;

public class RaycastControllerAden : MonoBehaviour
{
    public LayerMask collisionMask;

    public float skinWidth;
    public float extraInnerRayDist;

    public int numVerticalRays;
    public int numHorizontalRays;

    [HideInInspector]
    public BoxCollider2D boxCollider;

    public RaycastOrigins raycastOrigins;

    [HideInInspector]
    public float verticalRaySpacing;
    [HideInInspector]
    public float horizontalRaySpacing;


    public virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        CalculateRaySpacing();
    }

    public void UpdateRaycastOrigins()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
    }

    public void CalculateRaySpacing()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinWidth * -2);

        verticalRaySpacing = bounds.size.x / (numVerticalRays - 1);
        horizontalRaySpacing = bounds.size.y / (numHorizontalRays - 1);
    }

    public struct RaycastOrigins
    {
        public Vector2 topLeft, topRight, bottomLeft, bottomRight;
    }
}
