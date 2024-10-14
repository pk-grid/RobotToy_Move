# RobotToy_Move

## Installation

1. Clone the repository to your local machine.
2. Open the project in your preferred text editor or IDE.
3. Compile the project using the `csc` command (for Windows) or `mcs` command (for macOS/Linux).

## Usage(1)

1. Create a text file named `commands.txt` in the parent directory of the project.
2. Add your commands to the `commands.txt` file.
3. Run the program using the compiled executable.

## Usage(2)

1. Create a text file containing the commands for the robot (`commands.txt`).
2. Run the program using the compiled executable and pass the path to the commands file as an argument.
   
## Commands

The following commands are supported:

* `PLACE X,Y,F`: Place the robot on the table at position (X, Y) facing direction F (NORTH, SOUTH, EAST, or WEST).
* `MOVE`: Move the robot one unit forward in the direction it is facing.
* `LEFT`: Turn the robot left 90 degrees.
* `RIGHT`: Turn the robot right 90 degrees.
* `REPORT`: Report the robot's position and direction.

## Example Use Cases

* Place the robot on the table at position (0, 0) facing north: `PLACE 0,0,NORTH`
* Move the robot one unit forward: `MOVE`
* Turn the robot left 90 degrees: `LEFT`
* Report the robot's position and direction: `REPORT`
