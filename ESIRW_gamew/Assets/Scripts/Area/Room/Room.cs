using UnityEngine;
using System.Collections.Generic;


public class Room : MonoBehaviour
{
    public static int Width { get; private set; } = 22;
    public static int Height { get; private set; }  = 12;

    public Skill skill;

    public AnchorDirection AnchorPosition;

    public void DestroyRoom()
    {
        Destroy(gameObject);
    }
}

public enum Skill
{
    pivot,
    mirror,
    none
}


[System.Serializable]
public class RoomNode
{
    public Room room;
    public Vector2 coords;
    public RoomNode(Room room, Vector2 coords)
    {
        this.room = room;
        this.coords = coords;
    }

    public void UpdatePos(Vector2 pos)
    {
        coords = pos;
        room.transform.position = new Vector3(coords.x * Room.Width, coords.y * Room.Height);
    }

    public void MirrorRoom()
    {
        room.transform.localScale = new(-room.transform.localScale.x, room.transform.localScale.y, room.transform.localScale.z);
        foreach (Door door in Doors())
        {
            door.ReverseSideDoor();
        }
    }
    
    public List<Door> Doors()
    {
        return new List<Door>(room.GetComponentsInChildren<Door>()) ;
    }

    public bool RoomHasDoor(AnchorDirection entrance)
    {
        foreach(Door door in Doors())
        {
            if (door.DoorAsEntrance() == entrance)
                return true;
        }
        return false;
    }
}

[System.Flags]
public enum AnchorDirection : byte
{
    CEIL_LEFT = 0b1000_0000,
    CEIL_RIGHT = 0b0100_0000,
    
    FLOOR_LEFT = 0b0010_0000,
    FLOOR_RIGHT = 0b0001_0000,

    LEFT_BOTTOM = 0b0000_1000,
    LEFT_TOP = 0b0000_0100,

    RIGHT_BOTTOM = 0b0000_0010,
    RIGHT_TOP = 0b0000_0001,
}


/*public class Room : MonoBehaviour
{
    [SerializeField] 
    private AnchorDirectionSerialized[] possibleAnchorsConnectionsSerialized;

    [SerializeField]
    private Room ceil;
    [SerializeField]
    private Room floor;
    [SerializeField]
    private Room right;
    [SerializeField]
    private Room left;

    private AnchorPosition[] possibleAnchorPosition;
    public List<Anchor> currentAnchor = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        possibleAnchorPosition = new AnchorPosition[possibleAnchorsConnectionsSerialized.Length];

        for (int i = 0; i < possibleAnchorsConnectionsSerialized.Length; i++)
        {
            possibleAnchorPosition[i] = new AnchorPosition(possibleAnchorsConnectionsSerialized[i]);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public AnchorPosition[] GetPossibleAnchorsConnections()
    {
        return possibleAnchorPosition;
    }

    public List<AnchorPosition> GetavaibleConnections(AnchorDirection otherRelativePosition)
    {
        List<AnchorPosition> possibleConnections = new();
        foreach (AnchorPosition anchorPos in possibleAnchorPosition)
        {
            if (otherRelativePosition == anchorPos.wall)
            {
                possibleConnections.Add(anchorPos);
            }
        }
        return possibleConnections;
    }

    public bool IsCompatible(Room other, AnchorDirection otherRelativePosition)
    {
        List<AnchorPosition> possibleConnections = GetavaibleConnections(otherRelativePosition);

        if (possibleConnections.Count == 0) { return false;}

        List<AnchorPosition> possibleConnectionsOther = other.GetavaibleConnections(AnchorPosition.ReverseAnchorDirection(otherRelativePosition));

        if (possibleConnectionsOther.Count == 0) { return false; }

        return true;
    }




    public void CreateConnections(Room other, AnchorDirection otherRelativePosition)
    {
        List<AnchorPosition> possibleConnections = GetavaibleConnections(otherRelativePosition);

        if (possibleConnections.Count == 0) { return; }

        List<AnchorPosition> possibleConnectionsOther = other.GetavaibleConnections(AnchorPosition.ReverseAnchorDirection(otherRelativePosition));

        if (possibleConnectionsOther.Count == 0) { return; }

        foreach (AnchorPosition anchorPos in possibleConnections)
        {
            AnchorPosition oppositeAnchorPos = anchorPos.GetCompatible();

            foreach (AnchorPosition anchorPosOther in possibleConnectionsOther)
            {
                if (anchorPosOther.Equals(oppositeAnchorPos))
                {
                    CreateConnection(other, anchorPos);
                    other.CreateConnection(this, anchorPosOther);
                }
            }

        }


    }


    public void CreateConnection(Room other, AnchorPosition anchorPosition)
    {
        this.currentAnchor.Add(new Anchor(other, anchorPosition));
    }

}

public enum AnchorDirectionSerialized : byte
{
    CEIL_LEFT = 0b0001_0100,
    CEIL_RIGHT = 0b0001_1100,

    FLOOR_LEFT = 0b0011_0100,
    FLOOR_RIGHT = 0b0011_1100,
    
    RIGHT_TOP = 0b0100_0001,
    RIGHT_BOTTOM = 0b0100_0011,

    LEFT_TOP = 0b1100_0001,
    LEFT_BOTTOM = 0b1100_0011,
    
}

public enum AnchorDirection : byte
{
    CEIL = 0b0000_0001, 
    FLOOR = 0b0000_0011,
    LEFT = 0b0000_0100, 
    RIGHT = 0b0000_1100
}

public struct AnchorPosition
{
    public AnchorDirection wall;
    public AnchorDirection inWall;

    public AnchorPosition(AnchorDirection wall, AnchorDirection inWall)
    {
        Debug.Assert((wall & inWall) == 0);

        this.wall = wall;
        this.inWall = inWall;
    }

    public AnchorPosition(AnchorDirectionSerialized value)
    {
        byte temp = ((byte) (0b1111_0000 & (byte)value));
        temp >>= 4;

        this.wall = (AnchorDirection) temp;

        temp = ((byte)(0b0000_1111 & (byte)value));
        this.inWall = (AnchorDirection)temp;
    }

    public bool Equals(AnchorPosition other)
    {
        return (wall == other.wall) && (inWall == other.inWall);
    }


    public AnchorPosition GetCompatible()
    {
        return new AnchorPosition(ReverseAnchorDirection(this.wall), inWall);
    }

    public static AnchorDirection ReverseAnchorDirection(AnchorDirection current)
    {
        switch (current)
        {
            case AnchorDirection.LEFT: { return AnchorDirection.RIGHT; }

            case AnchorDirection.RIGHT: { return AnchorDirection.LEFT; }

            case AnchorDirection.FLOOR: { return AnchorDirection.CEIL; }

            case AnchorDirection.CEIL: { return AnchorDirection.FLOOR; }

            default: { Debug.Assert(false); return AnchorDirection.RIGHT; }
        }
    }

    public bool IsCompatible(AnchorPosition other)
    {
        if (other.inWall != this.inWall) {  return false; }

        return this.wall == ReverseAnchorDirection(other.wall);
    }
}


public class Anchor
{
    public Room other;
    public AnchorPosition connections;

    public Anchor(Room other, AnchorPosition connections)
    {
        this.other = other;
        this.connections = connections;
    }
}*/

/*
 * 




public class Room : MonoBehaviour
{
    [SerializeField] 
    private AnchorWall[] possibleAnchors;

    [SerializeField]
    private Room ceil;
    [SerializeField]
    private Room floor;
    [SerializeField]
    private Room right;
    [SerializeField]
    private Room left;

    public Anchor ceilAnchor = null;
    public Anchor floorAnchor = null;
    public Anchor rightAnchor = null;
    public Anchor leftAnchor = null;}


public enum AnchorWall : byte
{
    NONE = 0,
    CEIL_LEFT = 0b00100010,
    FLOOR_LEFT = 0b00000011,
    CEIL_RIGHT = 0b00100100, 
    FLOOR_RIGHT = 0b00000101,
    LEFT_TOP = 0b00001000,
    RIGHT_TOP = 0b00001001,
    LEFT_BOTTOM = 0b00010000,
    RIGHT_BOTTOM = 0b00010001,

}

public enum AnchorDesired : byte {
    FLOOR = 0b0000000,
    CEIL = 0b0010000,
    LEFT,
    RIGHT,
}

public struct LinkDesired {

    public AnchorDesired anchorDesired;
    public Room other;


    public LinkDesired( AnchorDesired anchorDesired, Room other )
    {
        this.anchorDesired = anchorDesired;
        this.other = other;
    }

    public void canConnect(Room room)
    {
        switch ()

        foreach (AnchorWall possibleAnchor in room.GetPossibleAnchors())
        {
            if (possibleAnchor & )
        }
    }
}

public class Anchor
{
    private Room other;
    private AnchorWall connection1;
    private AnchorWall connection2;

    public Anchor(Room other = null, AnchorWall connection1 = AnchorWall.NONE, AnchorWall connection2 = AnchorWall.NONE)
    {
        this.other = other;
        this.connection1 = connection1;
        this.connection2 = connection2;
    }
}
*/