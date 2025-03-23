using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System;

public class MinimapManager : MonoBehaviour
{

    [SerializeField] Level level; // later, the info are taken from the room manager

    [SerializeField] RoomManager roomManager;

    [SerializeField] GameObject mappedRoom;
    [SerializeField] public static int width = 100;
    [SerializeField] public static int height = 55;


    [SerializeField] Color pivotColor;
    [SerializeField] Color mirrorColor;
    [SerializeField] Color neutralColor;

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

    public void DisplayMinimap()
    {
        EmptyMap();
        foreach (RoomNode node in roomManager.roomList)
        {
            Debug.Log("there");
            GameObject room = GameObject.Instantiate(mappedRoom, transform);
            room.GetComponent<RectTransform>().anchoredPosition = new(node.coords.x * width, node.coords.y * height);
            maps.Add(new(node.coords, room.GetComponent<MinimapRoom>(), node));

        }
        foreach (Map map in maps)
        {
            if (map.RoomSkill() == Skill.pivot)
                map.SetColor(pivotColor);
            else if (map.RoomSkill() == Skill.mirror)
                map.SetColor(mirrorColor);
            else
                map.SetColor(neutralColor);

            if (roomManager.CurrentPos() == map.coords)
            {
                map.IsInRoom();
            }
        }
    }

    private void EmptyMap()
    {
        for (int i = maps.Count - 1; i >= 0; i--)
        {
            Destroy(maps[i].room.gameObject);
        }

        maps.Clear();

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

    public void SetColor(Color color)
    {
        Debug.Log("setting color for a room:"+color);
        room.SetColor(color);
    }

    public Skill RoomSkill()
    {
        return node.room.skill;
    }
    

}
