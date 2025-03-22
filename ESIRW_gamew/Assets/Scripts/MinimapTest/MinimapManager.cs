using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class MinimapManager : MonoBehaviour
{

    [SerializeField] Level level; // later, the info are taken from the room manager

    [SerializeField] RoomManager roomManager;
    [SerializeField] Vector2 currentPos;

    [SerializeField] GameObject mappedRoom;
    [SerializeField] int width;
    [SerializeField] int height;

    RectTransform rectTransform;


    [SerializeField] List<RoomNode> roomNodes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void displayMinimap()
    {
        foreach (RoomNode node in roomNodes)
        {
            Debug.Log("there");

            GameObject.Instantiate(mappedRoom, transform).GetComponent<RectTransform>().anchoredPosition = new(node.coords.x * width, node.coords.y * height);
        }
    }


}
