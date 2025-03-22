using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class MinimapManager : MonoBehaviour
{

    [SerializeField] Level level; // later, the info are taken from the room manager

    [SerializeField] RoomManager roomManager;
    [SerializeField] Vector2 currentPos;

    [SerializeField] GameObject mappedRoom;
    [SerializeField] public static int width = 100;
    [SerializeField] public static int height = 55;




    [SerializeField] List<Map> maps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisplayMinimap();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayMinimap()
    {
        foreach (RoomNode node in roomManager.roomList)
        {
            Debug.Log("there");
            GameObject room = GameObject.Instantiate(mappedRoom, transform);
            room.GetComponent<RectTransform>().anchoredPosition = new(node.coords.x * width, node.coords.y * height);
            maps.Add(new(node.coords, room.GetComponent<MinimapRoom>(), node));

        }
        foreach (Map map in maps)
        {
            if (currentPos == map.coords)
            {
                map.IsInRoom();
                break;
            }
        }
    }

    public void UpdateMap()
    {
        foreach (Map map in maps)
        {
            map.UpdatePos();
        }
    }

}


[System.Serializable]
public class Map
{
    public Vector2 coords;
    public MinimapRoom room;
    RoomNode node;

    public Map(Vector2 coords, MinimapRoom room, RoomNode node)
    {
        this.coords = coords;
        this.room = room;
        this.node = node;
    }

    public void IsInRoom()
    {
        room.isInRoom = true;
    }

    public void NoMoreInRoom()
    {
        room.isInRoom = false;
    }

    public void UpdatePos()
    {
        room.GetComponent<RectTransform>().anchoredPosition = new(node.coords.x * MinimapManager.width, node.coords.y * MinimapManager.height);
    }

    

}
