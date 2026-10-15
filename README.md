# MW2-style Aim Trainer (Unity)

This repository contains a standalone native desktop aim trainer inspired by Modern Warfare 2 feel, implemented as a Unity project. It is designed as an offline training tool and does not interact with online multiplayer games or anti-cheat systems.

Features
- Mouse and controller support (legacy Input)
- Adjustable sensitivity, ADS multiplier, and smoothing
- Static, moving, and strafing target scenarios
- Shot/hit tracking and accuracy metrics
- Reaction time logging and CSV export
- Simple scene setup with target prefab and game manager

Project structure
- Assets/Scripts: game logic and gameplay systems
- Assets/Scenes: sample scene for playtesting
- Assets/Prefabs: target prefab and reusable objects
- Packages/manifest.json: Unity package manifest
- ProjectSettings: Unity project settings

Requirements
- Unity 2021.3 LTS or later
- Windows/macOS/Linux supported as a project target; the code is cross-platform but the exported build depends on your Unity platform settings

Quick start
1. Open this folder in Unity 2021.3 LTS.
2. Load `Assets/Scenes/Main.unity`.
3. Press Play.
4. Use the mouse to look, left click to fire, and right mouse click to simulate ADS.
5. Adjust parameters in the inspector for sensitivity, smoothing, and scene layout.

Notes
- This is a training-focused prototype, not a cheat tool.
- The project does not read or modify running game processes and does not inject input into external applications.
- For advanced controller support, consider migrating to the Unity Input System in a later pass.

License
- MIT (if you add a LICENSE file later)
