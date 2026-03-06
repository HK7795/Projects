'''
project: Data Tracker
'''

class Player:
    players_count = 0

    def __init__(self, name, position, points):
        self.name = name
        self.position = position
        self.points = points
        Player.players_count += 1

    def display_player_info(self):
        print(f"\nName : {self.name}")
        print(f"Position : {self.position}")
        print(f"Points : {self.points}")
        print()

    def add_points(self, points_add):
        if points_add > 0:
            self.points += points_add
            print(f"Added {points_add} points to {self.name}.")
        else:
            print("Enter a positive number.")


def display_player_count():
    print(f"Number of players: {Player.players_count}")


def add_player(players):
    while True:
        name = input("Enter player name: ")
        if not name:
            print("Enter valid name.")
        if not name.replace(" ", "").isalpha():
            print("Player name must contain only letter.")
            continue
        break

    while True:
        position = input("Enter player position: ")
        if not position:
            print("Enter valid position.")
            continue
        if not position.replace(" ", "").isalpha():
            print("Enter valid position.")
            continue
        break

    while True:
        try:
            points = int(input("Enter points: "))
            if points < 0:
                print("Points must be a positive integer.")
                continue
            break
        except ValueError:
            print("Please enter a valid number for points.")

    new_player = Player(name, position, points)
    players.append(new_player)
    print(f"Player {name} added.")


def add_points(players):
    while True:
        name = input("Enter player's name to add points: ")
        if not name:
            print("Player name cannot be blank.")
            continue
        break

    player_found = False
    for player in players:
        if player.name == name:
            player_found = True
            while True:
                try:
                    new_points = int(input(f"Enter points to add: "))
                    if new_points < 0:
                        print("Enter positive points.")
                        continue
                    player.add_points(new_points)
                    break
                except ValueError:
                    print("Please enter a valid number for points.")
            break

    if not player_found:
        print(f"Player not found.")


def display_players(players):
    display_player_count()
    if not players:
        print("No players added.")
    else:
        for player in players:
            player.display_player_info()


players = []
while True:
    print("\nMain Menu:")
    print("[1] Add New Player")
    print("[2] Add Player's Points")
    print("[3] Display All Players")
    print("[4] Exit")
    try:
        choice = int(input("Enter your choice: "))
        match choice:
            case 1:
                add_player(players)
            case 2:
                add_points(players)
            case 3:
                display_players(players)
            case 4:
                print("Bye. See you next time!")
                break
            case _:
                print("Please enter number between 1-4.")
    except ValueError:
        print("Please enter a valid number.")
