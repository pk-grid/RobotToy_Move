// Enum to represent the possible directions the robot can face
public enum Direction
{
    NORTH,
    SOUTH,
    EAST,
    WEST
}

// Class to represent the robot
public class Robot
{
    // Properties to store the robot's position and direction
    public int X { get; set; }
    public int Y { get; set; }
    public Direction Facing { get; set; }

    // Method to place the robot on the table
    public void Place(int x, int y, Direction facing)
    {
        // Check if the position is within the table boundaries
        if (x >= 0 && x <= 4 && y >= 0 && y <= 4)
        {
            X = x;
            Y = y;
            Facing = facing;
        }
    }

    // Method to move the robot one unit forward
    public void Move()
    {
        // Move the robot based on its current direction
        //Ignore if the Robot is going to fall
        switch (Facing)
        {
            case Direction.NORTH:
                if (Y < 4)
                    Y++;
                break;
            case Direction.SOUTH:
                if (Y > 0)
                    Y--;
                break;
            case Direction.EAST:
                if (X < 4)
                    X++;
                break;
            case Direction.WEST:
                if (X > 0)
                    X--;
                break;
        }
    }

    // Method to turn the robot left
    public void Left()
    {
        // Check if the robot is placed on the table
        // Turn the robot left based on its current direction
        switch (Facing)
        {
            case Direction.NORTH:
                Facing = Direction.WEST;
                break;
            case Direction.SOUTH:
                Facing = Direction.EAST;
                break;
            case Direction.EAST:
                Facing = Direction.NORTH;
                break;
            case Direction.WEST:
                Facing = Direction.SOUTH;
                break;
        }
    }

    // Method to turn the robot right
    public void Right()
    {
        // Turn the robot right based on its current direction
        switch (Facing)
        {
            case Direction.NORTH:
                Facing = Direction.EAST;
                break;
            case Direction.SOUTH:
                Facing = Direction.WEST;
                break;
            case Direction.EAST:
                Facing = Direction.SOUTH;
                break;
            case Direction.WEST:
                Facing = Direction.NORTH;
                break;
        }
    }

    // Method to report the robot's position and direction
    public void Report()
    {
        // Print the robot's position and direction to the console
        Console.WriteLine($"{X},{Y},{Facing}");
    }
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
        // Create a new robot instance
        var robot = new Robot();

        var commandsFilePath = "";
        
        if (args.Length > 0)
        {
             commandsFilePath = args[0];
        }
        else
        {
            // Get the current directory
            var currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            // Get the path to the commands.txt file
             commandsFilePath = Path.Combine(currentDirectory, "commands.txt"); 
            //Console.WriteLine(currentDirectory);
             
        }

        // Check if the file exists
        if (File.Exists(commandsFilePath))
        {
            // Read the commands from the file
            var commands = File.ReadAllLines(commandsFilePath);

            // Execute each command
            foreach (var command in commands)
            {
                // Split the command into parts
                // To handle the Placement
                var parts = command.Split(' ');

                // Execute the command based on its type
                switch (parts[0].ToUpper())
                {
                    case "PLACE":
                        // Parse the place command and execute it
                        var placeParts = parts[1].Split(',');
                        robot.Place(int.Parse(placeParts[0]), int.Parse(placeParts[1]), (Direction)Enum.Parse(typeof(Direction), placeParts[2].ToUpper()));
                        break;
                    case "MOVE":
                        // Execute the move command
                        robot.Move();
                        break;
                    case "LEFT":
                        // Execute the left command
                        robot.Left();
                        break;
                    case "RIGHT":
                        // Execute the right command
                        robot.Right();
                        break;
                    case "REPORT":
                        // Execute the report command
                        robot.Report();
                        break;
                }
            }
        }
        else
        {
            // Print an error message if the file does not exist
            Console.WriteLine("File not found.");
        }
    } 
}