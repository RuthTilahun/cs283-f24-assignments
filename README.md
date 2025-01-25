## **Project: Maze of Redemption**
<img width="401" alt="RepImage" src="https://github.com/user-attachments/assets/db9691a0-5946-4c96-ba59-612fb139f150" />

### **Description**
*Maze of Redemption* is a 3D puzzle-adventure game where the player navigates a maze to find hidden puzzle pieces. Each collected piece reveals a part of the maze map, guiding the player closer to the end. Once all the pieces are collected, the exit gate opens, marking the completion of the adventure.

### **Videos and Screenshots**
https://github.com/user-attachments/assets/325f1c85-600f-45c6-a3fa-acb80881b84c

https://github.com/user-attachments/assets/28b6f204-a627-4ab9-8887-8e3a1f434be2

https://github.com/user-attachments/assets/893f6158-30e0-4aa1-8db9-39667531ee8e

![Screenshot 2024-12-13 222112](https://github.com/user-attachments/assets/f34fb7e4-3661-42ab-bb52-73a6db19ddff)

![Screenshot 2024-12-13 221648](https://github.com/user-attachments/assets/c4b5254b-574a-4dbd-ad98-da52c0b1b89d)

![Screenshot 2024-12-13 221714](https://github.com/user-attachments/assets/77e422c7-627c-4b08-8bc0-ebdc4b8c8292)

![Screenshot 2024-12-13 225240](https://github.com/user-attachments/assets/a3e25def-aa9c-4d19-bfad-dbd447cb5455)

![Screenshot 2024-12-13 225401](https://github.com/user-attachments/assets/d337b89a-e346-48b0-bca3-758036d12c0f)

### **How to Play**
1. **Objective:**
   - Navigate the maze to find all hidden puzzle pieces.
   - Each piece reveals part of the maze map to help you navigate.
   - Collect all pieces to open the gate and complete the maze.
2. **Controls:**
   - **W/A/S/D**: Move forward, left, backward, and right.
   - **Mouse**: Look around.
   - **Space**: Jump (if enabled).
   - **O**: Interact with objects (e.g., open chests)
3. **Hints:**
   - Look for treasure chests.
   - Use the map to orient yourself in the maze.

### **Building and Running in Unity**
   - Open the project in Unity.
   - Go to **File > Build Settings**.
   - Add the "Project" scene in the build.
   - Select your target platform (e.g., Windows, Mac, WebGL).
   - Click **Build**, and choose a location to save the build.
   - Navigate to the built game folder and open the .exe file(Windows) or .app file(Mac).

### **Implemented Features**
#### **1. Puzzle Piece Collection**
   - **Description:** Collect puzzle pieces to reveal parts of the maze map.
   - **Script:** `PuzzlePiece.cs`
     - Detects player proximity and interaction with puzzle pieces.
     - Triggers map updates when pieces are collected.

#### **2. Gate Mechanism**
   - **Description:** The exit gate opens when all puzzle pieces are collected.
   - **Script:** `GateController.cs`
     - Rotates the gate by 180 degrees when triggered.
     - Displays a UI message to inform the player of progress.

#### **3. Map Reveal System**
   - **Description:** Reveals hidden parts of the map as pieces are collected.
   - **Script:** `MapCanvasController.cs` and `MapUpdater.cs`
     - Handles the visibility of map overlays.
     - Updates the map dynamically when puzzle pieces are discovered.

#### **4. NPC Follower**
   - **Description:** An NPC follows the player at a fixed distance and catches up if the player stops.
   - **Script:** `GiantBehavior.cs`
     - Uses Unity’s NavMesh system for obstacle-aware movement.
     - Smoothly rotates the NPC to face the player.

#### **5. Welcome Page**
   - **Description:** A minimalist welcome page with a "Start" button to begin the game.
     - Handles the display and hiding of the welcome UI.
     - Transitions into gameplay when the button is clicked.

#### **6. Button Interaction**
   - **Description:** Buttons enable various interactions in the game, such as starting gameplay or toggling the map.
   -  **Script:** `ButtonBehavior.cs`
      - Manages the interaction of UI buttons.
      - Includes functionality for the "Start" button on the welcome page.

### **Future Enhancements**
- Add a timer or scoring system to challenge players.
- Include different maze levels with increasing complexity.

## Assignment 10: Behavior
### NPC1 attacks Player
https://github.com/user-attachments/assets/c68e0bcb-b599-4f4a-846e-24ae90360207

### NPC2 Defends Player(attacks NPC1)
https://github.com/user-attachments/assets/e75dccb1-aae5-4209-9169-669867305282

## Assignment 9: Wander
https://github.com/user-attachments/assets/c2295ed3-d5f4-408c-a1ab-9ecd57cac73c

## Assignment 8: Collection Game
https://github.com/user-attachments/assets/df0b2b28-67c7-4d9f-bc64-f2956668cb0c

## Assignment 7: Motion and Collision
https://github.com/user-attachments/assets/3182794b-7b37-4ac6-93d4-916d7ad275d0

## Assignment 6
### Spline with degree-1 polynomial
https://github.com/user-attachments/assets/a9ab48b2-60f5-403f-bd6f-af6f7263a856

### Spline with degree-3 polynomial
https://github.com/user-attachments/assets/13203e04-3d62-46b8-875f-d2e4dfd0c09c

## Assignment 5
### Spring Follow Camera
https://github.com/user-attachments/assets/c24a0632-6f8d-4f96-b801-7e35ddd46f73

### Rigid Body Camera
https://github.com/user-attachments/assets/fbddf5f9-7292-42cb-930d-99bc5d13ab66

## Assignment 4
![Screenshot 2024-09-28 010454](https://github.com/user-attachments/assets/f6b5ad0c-531f-4559-ab93-c5f1018bb3db)

## Assignment 3
![Screenshot 2024-09-21 005550](https://github.com/user-attachments/assets/f61321c7-26f7-4d03-bd9d-4f1cf21d503f)

![Screenshot 2024-09-21 005433](https://github.com/user-attachments/assets/91d1fe48-b264-42ff-b34f-a5e20b161753)

## Assignment 1
[GIF](https://github.com/user-attachments/assets/fb9bdf9b-b9d3-40f4-8c6f-35888fed36cb)

## Assets used
<img width="1200" alt="Screenshot 2024-09-28 011304" src="https://github.com/user-attachments/assets/8d0a6507-9433-47c4-9165-09d04cc92d16">
