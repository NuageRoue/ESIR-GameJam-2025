using UnityEngine;
using DigitalRuby.Tween;

public class TransitionManager : MonoBehaviour
{
    public Vector2 currentRoom = Vector2.zero;
    public Vector2 lastRoom = Vector2.zero;

    [SerializeField] private float cameraFollowSpeed = 0.33f;
    [SerializeField] private GameObject player;


    private Vector3 currentCameraPosition = Vector3.zero;
    private Vector3 lastCameraPosition = Vector3.zero;
    private Tween<float> tweenCamera;
    private GameObject cameraFollow;
    
    private Vector3 lastSpawner;
    private bool updatePlayerPosition = false;

    private void Awake()
    {
        cameraFollow = GameObject.FindAnyObjectByType<Camera>().gameObject;
        currentCameraPosition = gameObject.transform.position + new Vector3((currentRoom.x) * Room.Width, (currentRoom.y) * Room.Height, cameraFollow.transform.localPosition.z);
        lastCameraPosition = currentCameraPosition;

        lastSpawner = player.transform.position;
    }

    private void UpdateTweenCamera()
    {
        System.Action<ITween<Vector3>> updateCirclePos = (t) =>
        {
            cameraFollow.gameObject.transform.transform.position = t.CurrentValue;
        };
        cameraFollow.gameObject.Tween("TweenCamera", lastCameraPosition, currentCameraPosition, cameraFollowSpeed, TweenScaleFunctions.Linear, updateCirclePos);
    }


    public static Vector2 GridPosition(Vector3 position)
    {
        return new Vector2(Mathf.Round(position.x / Room.Width), Mathf.Round(position.y / Room.Height));
    }

    private void UpdateGridPlayerPosition()
    {

        Vector2 realCurrentPosGrid = GridPosition(player.transform.position + gameObject.transform.position);


        if (!realCurrentPosGrid.Equals(currentRoom))
        {
            lastRoom = currentRoom;
            currentRoom = realCurrentPosGrid;

            lastCameraPosition = cameraFollow.transform.localPosition;
            currentCameraPosition = gameObject.transform.position + new Vector3((currentRoom.x) * Room.Width, (currentRoom.y) * Room.Height, cameraFollow.transform.localPosition.z);

            UpdateTweenCamera();
        }




    }

    public void UpdateOnTriggerDoor(Transform spawner)
    {

        Vector2 spawnerGrid = GridPosition(spawner.transform.position);

        if (!spawnerGrid.Equals(currentRoom))
        {
            player.transform.position = spawner.transform.position;
            lastSpawner = spawner.transform.position;
        }

    }


    public void UpdateDeath()
    {

        updatePlayerPosition = true;
        
    }



    // Update is called once per frame
    void Update()
    {

        Debug.Log(player.transform.position);
        if (updatePlayerPosition)
        {

            player.transform.position = lastSpawner;
            updatePlayerPosition = !updatePlayerPosition;
        }
        UpdateGridPlayerPosition();

    }
}
