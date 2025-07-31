using UnityEngine;
[RequireComponent(typeof(Camera))]
public class CharacterEditor : MonoBehaviour
{
    public float zoomSensitivity = 1;
    public int cellWidth = 3;
    public int cellHeight = 7;
    public int baseLinePosition = 2;
    public int halfLinePosition = 5;
    [Header("Prefabs")]
    public GameObject linePrefab;

    private Camera camera;
    private LineRenderer lineRenderer;
    public GameObject lineContainer;

    private Vector2 mousePosLastFrame = Vector2.zero;
    private Vector2Int selectedPoint = new Vector2Int(int.MaxValue, int.MaxValue);
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int closestPoint = new Vector2Int(Mathf.RoundToInt(mouseWorldPos.x), Mathf.RoundToInt(mouseWorldPos.y));

            if (Vector2.Distance(mouseWorldPos, closestPoint) <= 0.25f)
            {
                lineRenderer.enabled = true;
                selectedPoint = closestPoint;
            }
            else
            {
                lineRenderer.enabled = false;
                selectedPoint = new Vector2Int(int.MaxValue, int.MaxValue);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (selectedPoint.x != int.MaxValue || selectedPoint.y != int.MaxValue)
            {
                lineRenderer.enabled = true;
                Vector2 mouseWorldPos = camera.ScreenToWorldPoint(Input.mousePosition);
                Vector2Int closestPoint = new Vector2Int(Mathf.RoundToInt(mouseWorldPos.x), Mathf.RoundToInt(mouseWorldPos.y));

                if (closestPoint != selectedPoint && Vector2.Distance(mouseWorldPos, closestPoint) <= 0.25f)
                {
                    GameObject line = Instantiate(linePrefab, lineContainer.transform);
                    line.name = $"Line [({selectedPoint.x}, {selectedPoint.y}), ({closestPoint.x}, {closestPoint.y})]";
                    line.GetComponent<LineRenderer>().SetPositions(new Vector3[] { (Vector2)selectedPoint, (Vector2)closestPoint });

                    selectedPoint = closestPoint;
                }

                lineRenderer.SetPositions(new Vector3[] { (Vector2)selectedPoint, mouseWorldPos });
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }
        else
        {
            lineRenderer.enabled = false;
            selectedPoint = new Vector2Int(int.MaxValue, int.MaxValue);
            if (Input.GetMouseButton(1))
            {
                Vector2 pixelsPerUnit = new Vector2(Screen.width / ((camera.orthographicSize * 2) * camera.aspect), Screen.height / (camera.orthographicSize * 2));
                Vector2 mouseMoveDelta = (Vector2)Input.mousePosition - mousePosLastFrame;

                transform.position = new Vector3(transform.position.x - (mouseMoveDelta.x / pixelsPerUnit.x), transform.position.y - (mouseMoveDelta.y / pixelsPerUnit.y), -10);
            }
            else
            {
                camera.orthographicSize += Input.mouseScrollDelta.y * Time.deltaTime * -200 * zoomSensitivity;
                camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, 1.0f, 15.0f);
            }
        }
        mousePosLastFrame = Input.mousePosition;
    }
}