using DigitalRuby.Tween;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public CharacterController characterController;
    [SerializeField] GameObject map;

    [SerializeField] float duration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        characterController = new();
        characterController.MinimapActionMap.Disable();
        characterController.MovementActionMap.Enable();
        map.SetActive(false);

        characterController.MinimapActionMap.CloseMap.started += CloseMap;
        characterController.MovementActionMap.OpenMap.started += OpenMap;
        SetupMovementPlayer();
        SetupControllerRoomManager();
    }

    void SetupMovementPlayer()
    {
        GameObject.FindAnyObjectByType<Movement>().SetupController(characterController);
    }

    void SetupControllerRoomManager()
    {
        GetComponent<RoomManager>().SetupController(characterController);
    }


    void OpenMap(InputAction.CallbackContext context)
    {
        System.Action<ITween<float>> openWindow = (t) =>
        {
            map.transform.localScale = new (map.transform.localScale.x, t.CurrentValue, map.transform.localScale.z);
        };

        System.Action<ITween<float>> Setup = (t) =>
        {
            characterController.MinimapActionMap.Enable();
        };

        map.SetActive(true);
        map.GetComponentInChildren<MinimapManager>().DisplayMinimap();
        characterController.MovementActionMap.Disable();

        // completion defaults to null if not passed in
        map.Tween("MoveCircle", 0f, 1f, duration, TweenScaleFunctions.CubicEaseIn, openWindow, Setup);

        

        
    }

    void CloseMap(InputAction.CallbackContext context)
    {

        System.Action<ITween<float>> openWindow = (t) =>
        {
            map.transform.localScale = new(map.transform.localScale.x, t.CurrentValue, map.transform.localScale.z);
        };

        System.Action<ITween<float>> Setup = (t) =>
        {
            characterController.MovementActionMap.Enable();

            map.SetActive(false);
        };

        characterController.MinimapActionMap.Disable();

        // completion defaults to null if not passed in
        map.Tween("MoveCircle", 1f, 0f, duration, TweenScaleFunctions.CubicEaseIn, openWindow, Setup);


    }
}
