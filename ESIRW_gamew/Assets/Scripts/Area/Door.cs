using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] AnchorDirection position; // la porte EN TANT QUE SORTIE (on la considère "dans" la salle)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetOpened() // la fonction qui détermine si on peut passer par la porte
    {
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void SetClosed() // la fonction qui détermine si on peut passer par la porte
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public AnchorDirection DoorAsEntrance()
    {
        switch (position)
        {// si elle est en haut à gauche, on entre par la droite
            case (AnchorDirection.LEFT_TOP):
                return AnchorDirection.RIGHT_TOP;
            case (AnchorDirection.LEFT_BOTTOM):
                return AnchorDirection.RIGHT_BOTTOM;
            case (AnchorDirection.RIGHT_TOP):
                return AnchorDirection.LEFT_TOP;
            case (AnchorDirection.RIGHT_BOTTOM):
                return AnchorDirection.LEFT_BOTTOM;

            case (AnchorDirection.CEIL_LEFT):
                return AnchorDirection.FLOOR_LEFT;
            case (AnchorDirection.CEIL_RIGHT):
                return AnchorDirection.FLOOR_RIGHT;
            case (AnchorDirection.FLOOR_LEFT):
                return AnchorDirection.CEIL_LEFT;
            case (AnchorDirection.FLOOR_RIGHT):
                return AnchorDirection.CEIL_RIGHT;
            default:
                return position;
        }
    }

    public AnchorDirection DoorAsExit()
    {
        return position;
    }
}
