using UnityEngine;

public class Draggable : MonoBehaviour
{
    #region Public Variables
    [Tooltip("false = 이동 가능, true = 이동 불가")]
    public bool hasBeenDragged = false;
    #endregion

    #region Private Variables
    private bool draggable;
    private Camera mainCamera;
    private Vector2 originalPosition;
    private Collider2D myCollider;
    #endregion

    private void Awake()
    {
        mainCamera = Camera.main;
        myCollider = GetComponent<Collider2D>();
        originalPosition = transform.position;
    }

    void Update()
    {
        if (ShouldIgnoreInput()) return;

        ProcessInput();
        DragObject();
    }

    private bool ShouldIgnoreInput()
    {
        return hasBeenDragged && !GameManager.Instance.canMove && GameManager.Instance.isGameStart;
    }

    private void ProcessInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttemptStartDrag();
        }

        if (Input.GetMouseButtonUp(0))
        {
            AttemptEndDrag();
        }
    }

    private void AttemptStartDrag()
    {
        RaycastHit2D hit = CastRay2D();
        if (hit.transform == transform)
        {
            draggable = true;
            myCollider.enabled = false;
        }
    }

    private void AttemptEndDrag()
    {
        if (!draggable) return;

        if (GameManager.Instance.canMove && hasBeenDragged)
        {
            GameManager.Instance.canMoveCount--;
        }

        hasBeenDragged = true; // 기획 수정됨 라운드 전은 자유 이동
        SnapToSlot();
        myCollider.enabled = true;
        draggable = false;
    }

    private void DragObject()
    {
        if (!draggable) return;

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.nearClipPlane);
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
    }

    private RaycastHit2D CastRay2D()
    {
        Vector3 screenMousePos = Input.mousePosition;
        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(screenMousePos);

        return Physics2D.Raycast(worldMousePos, Vector2.zero);
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
