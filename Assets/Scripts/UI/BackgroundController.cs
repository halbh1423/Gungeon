using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject backgroundPrefab;
    private Transform playerTransform;
    private GameObject currentBackground;
    private Vector3 lastPosition;
    private float backgroundSize = 30f;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
            lastPosition = playerTransform.position;
            CreateInitialBackground();
        }
    }

    void Update()
    {
        if (playerTransform != null && currentBackground != null)
        {
            Vector3 direction = playerTransform.position - lastPosition;
            if (ShouldCreateNewBackground(direction))
            {
                CreateBackground(direction);
                lastPosition = playerTransform.position;
            }
        }
    }

    void CreateInitialBackground()
    {
        currentBackground = Instantiate(backgroundPrefab, Vector3.zero, Quaternion.identity);
    }

    bool ShouldCreateNewBackground(Vector3 direction)
    {
        if (Mathf.Abs(direction.x) >= backgroundSize / 2 || Mathf.Abs(direction.y) >= backgroundSize / 2)
        {
            return true;
        }
        return false;
    }

    void CreateBackground(Vector3 direction)
    {
        Vector3 newPosition = lastPosition;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                newPosition += Vector3.right * backgroundSize;
            }
            else
            {
                newPosition += Vector3.left * backgroundSize;
            }
        }
        else
        {
            if (direction.y > 0)
            {
                newPosition += Vector3.up * backgroundSize;
            }
            else
            {
                newPosition += Vector3.down * backgroundSize;
            }
        }

        Destroy(currentBackground);
        currentBackground = Instantiate(backgroundPrefab, newPosition, Quaternion.identity);
    }
}
