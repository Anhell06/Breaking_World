using UnityEngine;


//---------------------------------------------------------------------------
//-----------------TEST CLASS--------DONT USE IN PROJECT---------------------
//---------------------------------------------------------------------------

public class Solver : MonoBehaviour
{

    [SerializeField]
    private int fieldWidth;
    [SerializeField]
    private int fieldLength;
    [SerializeField]
    private Field field;
    [SerializeField]
    private int difficulty;


    #region Debag
    #endregion

    private const int boundaries = 2;
    

    private void Start()
    {
        fieldWidth += boundaries;
        fieldLength += boundaries;
        field = new Field(fieldWidth, fieldLength);

        #region Debag
        var movable = new Block(true, false, false, "movable");
        var deathle = new Block(false, true, false, "deathle");
        var destroyable = new Block(true, false, true, "destroy");
        #endregion


        FillEdges();
        FillRandomFild(movable, deathle, destroyable);
    }

    [ContextMenu("Do Something")]
    private void MoveFieldDown()
    {
        Vector2 moveVector = Vector2.down;
        for (int i = 1; i < fieldWidth - 1; i++)
        {
            for (int j = 1; j < fieldLength - 1; j++)
            {
                if ((field.uField[i + (int)moveVector.x, j + (int)moveVector.y] == null || field.uField[i + (int)moveVector.x, j + (int)moveVector.y].IsDestroyable)
                    && field.uField[i, j] != null
                    && field.uField[i, j].IsMoveble)
                {

                    field.uField[i + (int)moveVector.x, j + (int)moveVector.y] = field.uField[i, j];
                    field.uField[i, j] = null;

                }

            }
        }
        Debug.Log(field.ToString());
    }

    private void FillRandomFild(Block movable, Block deathle, Block destroyable)
    {
        for (int i = 1; i < fieldWidth - 1; i++)
        {
            for (int j = 1; j < fieldLength - 1; j++)
            {
                if (Random.Range(0, 10) == 0)
                {
                    field.uField[i, j] = deathle;
                }
                if (Random.Range(0, 2) == 0)
                {
                    field.uField[i, j] = movable;
                }
                if (Random.Range(0, 5) == 0)
                {
                    field.uField[i, j] = destroyable;
                }
            }
        }
        Debug.Log(field.ToString());

    }

    private void FillEdges()
    {
        for (int i = 0; i < fieldWidth; i++)
        {
            field.uField[i, 0] = new Block(false, true, false, "deathle");
            field.uField[i, fieldLength - 1] = new Block(false, true, false, "deathle");
        }
        for (int i = 0; i < fieldLength; i++)
        {
            field.uField[0, i] = new Block(false, true, false, "deathle");
            field.uField[fieldWidth - 1, i] = new Block(false, true, false, "deathle");
        }
    }
}

class Field
{
    public Block[,] uField;
    int x;
    int y;

    public Field(int x, int y)
    {
        uField = new Block[x, y];
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        string s = string.Empty;

        for (int i = 1; i < x - 1; i++)
        {

            for (int j = 1; j < y - 1; j++)
            {
                s += uField[i, j]?.ToString();
                if (uField[i, j]?.ToString() == null)
                    s += "__________";
                s += "|";
            }
            s += System.Environment.NewLine;
        }
        return s;
    }
}

public class Block
{
    public Block(bool isMoveble, bool isDeathle, bool isDestroyable, string type)
    {
        this.isMoveble = isMoveble;
        this.isDeathle = isDeathle;
        this.isDestroyable = isDestroyable;
        this.type = type;
    }
    private bool isMoveble;
    private bool isDeathle;
    private bool isDestroyable;
    private string type;

    public bool IsMoveble { get => isMoveble; }
    public bool IsDeathle { get => isDeathle; }
    public bool IsDestroyable { get => isDestroyable; }
    public string Type { get => type; }

    public override string ToString()
    {
        return type;
    }
}
