# Description
PlaneVR - Virtual Reality Flight Simulator
Description
PlaneVR is an immersive VR flight simulator developed in Unity for the Oculus Quest 2, designed as a learning tool for aviation students and enthusiasts. The simulator provides a simplified but interactive flying experience, allowing users to:

- Interact with cockpit instruments using VR hand controllers
- Learn basic flight operations: startup, taxi, takeoff, cruising, landing, and shutdown
- Explore educational flashcards explaining cockpit controls and aviation concepts
- Fly over selected areas in different weather conditions.
- Engage in guided training modes for learning and practicing piloting skills

# Designs and Demo
- Figma File Mockup: https://www.figma.com/design/jff40TwggmqGiT5MobWZ92/Virtual-Reality-Real-Estate-Site-Tour-App--VR----with-Heads-Up-Display--HUD---Community-?node-id=31-141&t=7VyIh0GKK5MReEjf-0
- Figma Prototype Mockup: https://www.figma.com/proto/jff40TwggmqGiT5MobWZ92/Virtual-Reality-Real-Estate-Site-Tour-App--VR----with-Heads-Up-Display--HUD---Community-?node-id=31-141&t=pzlZ9ZyCsHZSKEEo-1&scaling=min-zoom&content-scaling=fixed&page-id=8%3A4284&starting-point-node-id=2008%3A593
- Video Demo: https://drive.google.com/file/d/13zedpJhEbcK55z5fXYpc4oLQ_0D5mMSA/view?usp=sharing

# Installation
## Requirements
- Unity 2022.3 LTS with Android Build Support
- Oculus Integration SDK
- Unity XR Interaction Toolkit
- Eagle Light Aircraft Asset: https://assetstore.unity.com/packages/3d/vehicles/air/sky-eagle-light-aircraft-low-poly-109070
- Hangar Asset: https://assetstore.unity.com/packages/3d/environments/hq-hangar-free-212795
- Environment: https://assetstore.unity.com/packages/tools/terrain/mapmagic-2-165180
- Oculus Quest 2
  
## Project Setup Instructions
- Clone the repository: https://github.com/lanaarafat/Plane_Sim.git
- Open the project in Unity:
- Install Dependencies: Oculus Integration, GameAssets, and XR Interaction ToolKit via Package Manager
- Configure XR settings: Go to Project Settings> XR Plugin Management and enable Oculus for Android.
- Scene Setup: include all necessary scenes in the Build Settings

## Build & Deployment
- Build the APK: Go to File > Build Settings > Android > Build, and save the APK file.
- Connect the headset via USB
- Launch and begin simulation.

## Testing
- Unit Testing: Core flight control and UI functionality are tested using Unity’s built-in test framework.
- Device Testing: Manual testing performed on Oculus Quest 2.
- User Feedback: Iterative feedback from test users is used to improve UI, interactions, and performance.

# Hardware Integration – User Interaction in VR
PlaneVR is designed for immersive interaction using the Meta Quest 2 headset and its handheld VR controllers. The user interacts with the aircraft and interface elements directly in 3D space using natural hand motions and controller input, powered by Unity’s XR Interaction Toolkit.

### Headset: Meta Quest 2
- Provides 6DoF (six degrees of freedom) head tracking.
- Allows the user to look around the cockpit freely.
- Enables immersive environment viewing from the pilot’s perspective.

### Hand Controllers
Each controller is mapped to specific interactions inside the virtual cockpit:
- Controller Input	In-App Function
- Trigger (index)	Grab/interact with cockpit levers, switches, yoke
- Grip (side button)	Hold and manipulate physical instruments
- Thumbstick: Navigate UI menus or reposition the hand if needed
- Button A/B or X/Y: Toggle flashcards, menu shortcuts, or pause

The user grabs the yoke, adjusts the throttle, and activates aircraft systems by physically reaching out and interacting with in-cockpit objects. When hovering over a control, contextual tooltips appear, explaining its function. This supports beginner pilots through visual guidance.


Developed By
Mutoni Lana Arafat
