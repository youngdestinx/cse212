/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>


/// <plan>
/// 1. Define the functions: create four functions: MoveLeft, MoveRight, MoveUp and MoveDown. Each function will
/// take the current position(x, y) as input.
/// 
/// 2. Check valid movements: for each function, check if the movement is valid by looking up the current position
/// (x, y) in the maze dictionary and checking the corresponding movement direction. (left, right, up or down)
/// 
/// 3. Return new position: If the movement is valid, return the new position(x, y) after applying the movement.
/// If the movement is not valid, throw an InvalidOperationException with the message "Can't go that way!"
/// 
/// 4. Update position: To move left, decrement x. To move right, increment x. To move up, decrement y. To move
/// down, increment y.
/// 

public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE
        if (_mazeMap[(_currX, _currY)][0])
        {
            _currX -= 1;
        }

        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE
        if (_mazeMap[(_currX, _currY)][1])
        {
            _currX += 1;
        }

        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE
        if (_mazeMap[(_currX, _currY)][2])
        {
            _currY -= 1;
        }

        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE
        if (_mazeMap[(_currX, _currY)][3])
        {
            _currY += 1;
        }

        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}