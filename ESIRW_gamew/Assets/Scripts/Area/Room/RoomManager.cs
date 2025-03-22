using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class RoomManager : MonoBehaviour
{
    [SerializeField] Transform roomParent;

    [SerializeField] GameObject room;

    [SerializeField] public List<RoomNode> roomList;

    [SerializeField] Level level;

    GameObject DoorOpen;
    GameObject DoorClose;

    private void Awake()
    {
        roomList.Clear();
        LoadLevel(level);
    }

    public void InstantiateRoom(GameObject room, Vector2 coords)
    {
        GameObject newRoom = GameObject.Instantiate(room, new Vector3(coords.x * Room.Width, coords.y * Room.Height), roomParent.rotation, roomParent);
        roomList.Add(new(newRoom.GetComponent<Room>(), coords));
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.S))
        {
            Vector2 coord = new(0, 0);
            if (CheckPos(coord))
                DestroyRoom(coord);
            else
                InstantiateRoom(room, coord);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector2 coord = new(-1, 0);
            if (CheckPos(coord))
                DestroyRoom(coord);
            else
                InstantiateRoom(room, coord);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector2 coord = new(1, 0);
            if (CheckPos(coord))
                DestroyRoom(coord);
            else
                InstantiateRoom(room, coord);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector2 coord = new(0, 1);
            if (CheckPos(coord))
                DestroyRoom(coord);
            else
                InstantiateRoom(room, coord);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Vector2 coord = new(0, -1);
            if (CheckPos(coord))
                DestroyRoom(coord);
            else
                InstantiateRoom(room, coord);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2 coord = new(0, 1);
            foreach(RoomNode node in roomList)
            {
                MoveRoom(node, node.coords + coord);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2 coord = new(-1, 0);
            foreach (RoomNode node in roomList)
            {
                MoveRoom(node, node.coords + coord);
            }

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector2 coord = new(1, 0);
            foreach (RoomNode node in roomList)
            {
                MoveRoom(node, node.coords + coord);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector2 coord = new(0, -1);
            foreach (RoomNode node in roomList)
            {
                MoveRoom(node, node.coords + coord);
            }
        }*/
    }

    bool CheckPos(Vector2 pos)
    {
        foreach (RoomNode node in roomList)
        {
            if (node.coords == pos)
            { return true; }
        }
        return false;
    }

    void DestroyRoom(Vector2 pos)
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].coords == pos)
            {
                roomList[i].room.DestroyRoom();
                roomList.RemoveAt(i);
                return;
            }
        }
    }

    bool MoveRoom(RoomNode room, Vector2 newPos)
    {
        room.UpdatePos(newPos);
        return true;
    }

    void CheckAdjacency()
    {
        foreach(RoomNode node in roomList)
        {
            foreach(Door door in node.Doors())
            {
                switch (door.DoorAsExit())
                {
                    case AnchorDirection.RIGHT_TOP:
                    case AnchorDirection.RIGHT_BOTTOM:
                        if (RoomHasDoor(node.coords + new Vector2(1, 0), door.DoorAsExit()))
                            door.SetOpened();
                        else 
                            door.SetClosed();
                        break;

                    case AnchorDirection.LEFT_TOP:
                    case AnchorDirection.LEFT_BOTTOM:
                        if (RoomHasDoor(node.coords + new Vector2(-1, 0), door.DoorAsExit()))
                            door.SetOpened();
                        else
                            door.SetClosed();
                        break;

                    case AnchorDirection.CEIL_LEFT:
                    case AnchorDirection.CEIL_RIGHT:
                        if (RoomHasDoor(node.coords + new Vector2(0, 1), door.DoorAsExit()))
                            door.SetOpened();
                        else
                            door.SetClosed();
                        break;

                    case AnchorDirection.FLOOR_LEFT:
                    case AnchorDirection.FLOOR_RIGHT:
                        if (RoomHasDoor(node.coords + new Vector2(0, -1), door.DoorAsExit()))
                            door.SetOpened();
                        else
                            door.SetClosed();
                        break;
                }
            }
        }
    }

    public bool RoomHasDoor(Vector2 pos, AnchorDirection entrance)
    {
        foreach (RoomNode node in roomList)
        {
            if (node.coords == pos)
            { return node.RoomHasDoor(entrance); }
        }
        return false;
    }

    void LoadLevel(Level level)
    {
        foreach(RoomNode node in level.RoomNodes)
        {
            InstanciateNode(node);
        }
        CheckAdjacency();
    }

    private void InstanciateNode(RoomNode node)
    {
        GameObject newRoom = GameObject.Instantiate(node.room.gameObject, new Vector3(node.coords.x * Room.Width, node.coords.y * Room.Height), roomParent.rotation, roomParent);
        roomList.Add(new(newRoom.GetComponent<Room>(), node.coords));
    }
}




/*public class RoomManager : MonoBehaviour
{

    [SerializeField]
    private Room startGraph;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Assert(startGraph != null);
        List<Room> alreadySeenRoom = new();
        createGraphFrom(startGraph, alreadySeenRoom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void createGraphFrom(Room room, List<Room> alreadySeenRoom)
    {

    }


}
*/
