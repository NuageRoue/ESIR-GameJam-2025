using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public CharacterController characterController;
    [SerializeField] GameObject map;
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

        characterController.MinimapActionMap.Enable();
        characterController.MovementActionMap.Disable();

        map.SetActive(true);
        map.GetComponentInChildren<MinimapManager>().DisplayMinimap();
    }

    void CloseMap(InputAction.CallbackContext context)
    {
        map.gameObject.SetActive(false);
        characterController.MinimapActionMap.Disable();
        characterController.MovementActionMap.Enable();
    }
}
