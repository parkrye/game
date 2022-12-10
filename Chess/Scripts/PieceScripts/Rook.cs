using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : PieceManager
{
    public override bool Move(int c, int r)
    {
        if (GetMovable(c, r))
        {
            SetPosition(c, r);
            MoveRule();
            return true;
        }
        return false;
    }

    public override bool GetMovable(int c, int r)
    {
        MoveRule();
        return zone[c, r];
    }

    public override void Initialize()
    {
        if (int.Parse(gameObject.name.Substring(1, 1)) == 1)
            col = 0;
        else
            col = 7;
        row = 0;
        base.Initialize();
    }

    public override void MoveRule()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                zone[i, j] = false;
            }
        }

        // 위쪽으로 이동
        for (int i = 1; i < 8; i++)
        {
            if (board.GetBoard(col + i, row) == 0)
            {
                zone[col + i, row] = true;
            }
            else if (board.GetBoard(col + i, row) == isPlayer)
            {
                zone[col + i, row] = false;
                break;
            }
            else if (board.GetBoard(col + i, row) == -isPlayer)
            {
                zone[col + i, row] = true;
                break;
            }
            else
            {
                break;
            }
        }
        // 아래쪽으로 이동
        for (int i = 1; i < 8; i++)
        {
            if (board.GetBoard(col - i, row) == 0)
            {
                zone[col - i, row] = true;
            }
            else if (board.GetBoard(col - i, row) == isPlayer)
            {
                zone[col - i, row] = false;
                break;
            }
            else if (board.GetBoard(col - i, row) == -isPlayer)
            {
                zone[col - i, row] = true;
                break;
            }
        }
        // 오른쪽으로 이동
        for (int i = 1; i < 8; i++)
        {
            if (board.GetBoard(col, row + i) == 0)
            {
                zone[col, row + i] = true;
            }
            else if (board.GetBoard(col, row + i) == isPlayer)
            {
                zone[col, row + i] = false;
                break;
            }
            else if (board.GetBoard(col, row + i) == -isPlayer)
            {
                zone[col, row + i] = true;
                break;
            }
            else
            {
                break;
            }
        }
        // 왼쪽으로 이동
        for (int i = 1; i < 8; i++)
        {
            if (board.GetBoard(col, row - i) == 0)
            {
                zone[col, row - i] = true;
            }
            else if (board.GetBoard(col, row - i) == isPlayer)
            {
                zone[col, row - i] = false;
                break;
            }
            else if (board.GetBoard(col, row - i) == -isPlayer)
            {
                zone[col, row - i] = true;
                break;
            }
            else
            {
                break;
            }
        }

    }
}
