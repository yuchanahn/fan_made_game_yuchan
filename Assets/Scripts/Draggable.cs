using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool draggable;
    private bool hasBeenDragged = false;
    private Camera mainCamera;
    private Vector2 originalPosition;
    private Collider2D myCollider; // 콜라이더 추가

    private void Awake()
    {
        mainCamera = Camera.main;
        myCollider = GetComponent<Collider2D>(); // 콜라이더 참조
    }

    private void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (hasBeenDragged)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = CastRay2D();

            if (hit.transform == transform)
            {
                draggable = true;
                myCollider.enabled = false; // 드래그 시작 시 콜라이더 비활성화
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (draggable)
            {
                hasBeenDragged = true;
                SnapToSlot();
                myCollider.enabled = true; // 드래그 종료 시 콜라이더 활성화
            }
            draggable = false;
        }

        if (draggable)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.nearClipPlane);
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(position);
            transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
        }
    }

    private RaycastHit2D CastRay2D()
    {
        Vector3 screenMousePos = Input.mousePosition;
        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(screenMousePos);

        RaycastHit2D hit = Physics2D.Raycast(worldMousePos, Vector2.zero);
        return hit;
    }

    private void SnapToSlot()
    {
        RaycastHit2D hit = CastRay2D();
        if (hit.collider != null && hit.collider.CompareTag("Slot"))
        {
            transform.position = hit.collider.transform.position;
        }
        else
        {
            hasBeenDragged = false;
            transform.position = originalPosition;
        }
    }
}
