# 🛤️ Subway Surfer — Prototype
A clean, modular infinite runner prototype inspired by Subway Surfers, built in Unity with scalable architecture and production-ready systems.

## 🎥 Demo
Replace these GIF paths with your exported gameplay GIFs located in docs/gifs/.

## ✨ Features
- Infinite procedural track generation
- Lane-based player movement (left / center / right)
- Keyboard input
- Obstacles, collisions, and fail-state logic
- Object pooling for tiles, obstacles & pickups
- Coin collection + scoring system
- Lightweight UI (score, pause, restart)

## 🛠️ Tech Stack
+ **Engine:** Unity 2022.3 LTS (recommended)
+ **Language:** C#
+ **Animation:** Animator Controller
+ **Systems:** ScriptableObjects, Object Pooling, Event Bus
+ **Target Platforms:** WebGL
+ **Version Control:** Git + GitHub


## 🧩 Architecture & Patterns Used
This prototype is built around clean, scalable systems:
**Core Patterns**
+ State Machine – game states & player movement states
+ Object Pooling – tiles, obstacles, items
+ Singleton (Lite) – GameManager, AudioManager
+ Event Bus / Observer – coin collection, player death, score updates
+ ScriptableObjects – skins, difficulty data, item data

**Design Philosophy**
+ Decoupled systems
+ Small, testable components
+ Data-driven configuration
+ Easy extension for shop, missions, or power-ups
