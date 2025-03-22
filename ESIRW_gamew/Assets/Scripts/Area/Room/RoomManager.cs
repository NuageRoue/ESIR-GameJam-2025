using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class RoomManager : MonoBehaviour
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
