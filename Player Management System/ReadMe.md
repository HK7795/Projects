# Data Tracker - Player Management System

## Project Description
The **Data Tracker** project is a simple Python console application used to manage player data.  
It allows users to add players, update their points, and display all player information through a menu-driven interface.

This program demonstrates the use of **Python classes, object-oriented programming, input validation, loops, and lists**.

---

## Features
- Add a new player
- Add points to an existing player
- Display all player details
- Track the total number of players
- Input validation for names, positions, and points
- Menu-driven console interface

---

## Technologies Used
- Python 3

---

## Program Structure

### Player Class
The `Player` class stores player information and handles player-related actions.

#### Attributes
- `name` – Player's name
- `position` – Player's position
- `points` – Player's points
- `players_count` – Class variable that counts total players

#### Methods
- `display_player_info()` – Displays the player's details
- `add_points(points_add)` – Adds points to a player

---

### Functions

#### `add_player(players)`
Adds a new player to the player list with validation for:
- Name
- Position
- Points

#### `add_points(players)`
Searches for a player by name and adds points to that player.

#### `display_players(players)`
Displays all players currently stored in the system.

#### `display_player_count()`
Displays the total number of players created.

---

## How the Program Works

When the program runs, it displays a menu:

```
Main Menu:
[1] Add New Player
[2] Add Player's Points
[3] Display All Players
[4] Exit
```

The user selects an option to perform actions such as adding players, updating points, or displaying player information.

---

## Example Output

```
Main Menu:
[1] Add New Player
[2] Add Player's Points
[3] Display All Players
[4] Exit

Enter your choice: 1
Enter player name: John
Enter player position: Forward
Enter points: 10
Player John added.
```

```
Name : John
Position : Forward
Points : 10
```

---

## Input Validation
The program ensures:
- Player names contain only letters
- Positions contain only letters
- Points must be valid positive integers
- Blank inputs are not allowed

---

## How to Run the Program

1. Install Python 3 if it is not installed.
2. Save the program file (for example `player_tracker.py`).
3. Open the folder in VS Code.
4. Run the program using the terminal:

```
python player_tracker.py
```

---

## Author
Created as part of a **Python programming practice project**.
