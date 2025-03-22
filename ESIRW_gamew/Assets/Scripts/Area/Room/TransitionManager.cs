using UnityEngine;
using DigitalRuby.Tween;

public class TransitionManager : MonoBehaviour
{
    public Vector2 currentRoom = Vector2.zero;
    public Vector2 lastRoom = Vector2.zero;

    public Vector3 currentCameraPosition = Vector3.zero;
    public Vector3 lastCameraPosition = Vector3.zero;

    [SerializeField] private GameObject cameraFollow;
    [SerializeField] private float cameraFollowSpeed = 0.33f;
    [SerializeField] private GameObject player;

    private Tween<float> tweenCamera;


    private void Awake()
    {
        currentCameraPosition = gameObject.transform.position + new Vector3((currentRoom.x) * Room.Width, (currentRoom.y) * Room.Height, cameraFollow.transform.localPosition.z);
    }
    private void UpdateTweenCamera()
    {
        System.Action<ITween<Vector3>> updateCirclePos = (t) =>
        {
            cameraFollow.gameObject.transform.transform.position = t.CurrentValue;
        };
        
        cameraFollow.gameObject.Tween("TweenCamera", lastCameraPosition, currentCameraPosition, cameraFollowSpeed, TweenScaleFunctions.Linear, updateCirclePos);
    }

    private void UpdateGridPlayerPosition()
    {

        Debug.Log(currentRoom);

        Vector3 realAbsolutePosition = player.transform.position + gameObject.transform.position;
        Vector2 realCurrentPosGrid = new Vector2(
            Mathf.Round(realAbsolutePosition.x / Room.Width), 
            Mathf.Round(realAbsolutePosition.y / Room.Height)
           );

        

        if (!realCurrentPosGrid.Equals(currentRoom))
        {
            lastRoom = currentRoom;
            currentRoom = realCurrentPosGrid;

            lastCameraPosition = cameraFollow.transform.localPosition;
            currentCameraPosition = gameObject.transform.position + new Vector3((currentRoom.x) * Room.Width, (currentRoom.y) * Room.Height, cameraFollow.transform.localPosition.z);

            UpdateTweenCamera();
        }
        
        
    }



    // Update is called once per frame
    void Update()
    {
        UpdateGridPlayerPosition();
    }
}
