# 🏃‍♂️ 2D-SPRINT-CJ: Sprint Style Action Platformer

## 🕹️ Description
**2D-SPRINT-CJ** is a fast-paced 2D sprint-style action platformer. Players must navigate multi-floor levels, avoid environmental hazards, and engage with various enemy types while racing to reach the final checkpoint.

---

## 👥 Contributors
Developed by **Jonathan Lopez** and **Christopher Poche**, who contributed equally to:

- **Game Mechanics & Programming** – Player movement, enemy behaviors, bullet mechanics, and checkpoints.
- **UI & UX Design** – HUD elements, health/lives tracking, and game flow interfaces.
- **Level Design** – Layout and placement of interactive environments, moving platforms, and enemy zones.
- **Testing & Debugging** – Identifying and resolving gameplay bugs and UI issues.

---

## ✨ Features

- **Win & Loss Conditions**  
  Reach the final checkpoint to win. Losing all lives triggers the Game Over screen.

- **UI Tracking System**  
  - Player health and remaining lives shown via HUD.

- **Dynamic Environments**  
  - Moving platforms (vertical and horizontal)  
  - Diverse enemy behaviors (patrolling, flying, dropping hammers)

---

## 🛠️ How to Build and Run

### 🔧 Unity Version
Built using **Unity 60000.0.37f1**  
➡️ Use this version or a compatible release to open and build the project.

### 📦 Building the Game
1. Open Unity Hub and locate the project folder.
2. Open the project in Unity Editor.
3. Go to `File → Build Settings`.
4. Choose your target platform (Windows/macOS/WebGL, etc.).
5. Set build options, then click `Build`.
6. Select a folder for the output and wait for the build to complete.

### ▶️ Running the Game
- Navigate to the output folder.
- Launch the `.exe`, `.app`, or WebGL `index.html` file.
- Ensure all assets stay in the same folder as the main executable.

---

## 🎮 Controls

| Action        | Key/Button    |
|---------------|---------------|
| Move          | `W`, `A`, `S`, `D` |
| Interact      | `E`           |
| Aim           | Mouse Cursor  |
| Jump          | `Spacebar`    |
| Fire Bullet   | Left Click    |

---

## 📜 Key Scripts

- `Checkpoint.cs` – Manages player checkpoints.
- `EnemyBullet.cs` – Controls enemy projectile behavior.
- `EnemyPatrol.cs` – Handles ground enemy patrol routes.
- `EnemyTrigger.cs` – Activates enemy attacks when detecting the player.
- `FlyingEnemy.cs` – Controls aerial enemy patterns.
- `GameManager.cs` – Oversees win/loss states and game flow.
- `HammerDropEnemy.cs` – Controls enemies that drop hammers from above.
- `HealthUI.cs` – Displays player's health on the screen.
- `LivesUI.cs` – Shows remaining lives.
- `Platform Ping Pon.cs` – Controls side-to-side platform movement.
- `PlatformUpDown.cs` – Controls vertical platform movement.
- `PlayerBullet.cs` – Handles bullet firing from the player.
- `PlayerController2D.cs` – Main player movement and control script.
- `PlayerHealth.cs` – Manages damage, health tracking, and death.
- `PlayerRespawn.cs` – Manages respawning logic and spawn points.

---

## 🔊 Audio

- **Background Music:**  
  “Game Music Player Console 8bit” – [Pixabay](https://pixabay.com/)  
  License: Free for use (no attribution required)

---

## 🎨 Assets

- **Sprites & Tilesets:**  
  [Kenney.nl – Abstract Platformer Pack](https://kenney.nl/assets/abstract-platformer)  
  License: Public Domain / CC0

---

## ⚠️ Known Issues

- None reported.

---

## 📂 Project Name
**2D-SPRINT-CJ**

---

> Thanks for checking out our sprint-style platformer! 🕹️
