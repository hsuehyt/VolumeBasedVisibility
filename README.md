# VolumeBasedVisibility

A Unity script that controls the visibility of a visual object based on the volume level of an audio source. The visibility is toggled based on a user-defined threshold, set in decibels (dB). The default threshold is set to **-10 dB**, but can be customized as needed.

## Features
- Visual object is initially hidden and becomes visible when the audio volume exceeds a specified dB threshold.
- The threshold is adjustable, allowing users to modify the volume level at which the visual object becomes visible.
- Works with any `AudioSource` component in Unity.
  
## Getting Started

### Prerequisites
- Unity 2021.1 or newer
- Basic knowledge of Unity's `AudioSource` and `GameObject` components

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/hsuehyt/VolumeBasedVisibility.git
   ```
2. Open your Unity project and import the script `VolumeBasedVisibilityController.cs` into your desired folder (e.g., `Assets/Scripts`).

### Usage
1. **Attach Script**: Attach the `VolumeBasedVisibilityController` script to an empty `GameObject` in the scene.
2. **Set Audio Source**: In the Unity Inspector, drag and drop the `AudioSource` component that plays the audio file into the `audioSource` field.
3. **Set Visual Object**: Drag and drop the visual object (e.g., `GameObject`, 3D model, UI element) into the `visualObject` field.
4. **Adjust Threshold**: By default, the script uses a threshold of **-10 dB**. To adjust this, you can either change the value directly in the Inspector or use the `SetVolumeThresholdDB()` method in your code.

### Example
In this example, the visual object will become visible when the audio volume exceeds -10 dB.

```csharp
// Adjust the threshold dynamically (optional)
volumeBasedVisibilityController.SetVolumeThresholdDB(-8.0f);
```

### Customization
- **Threshold**: You can set the volume threshold directly in the Unity Inspector or change it programmatically during runtime.
- **Visual Object**: Any `GameObject` in the scene can be assigned to toggle its visibility, whether it's a 3D model or UI component.

## Script Overview

```csharp
public AudioSource audioSource; // Reference to the audio source playing the music
public GameObject visualObject; // The visual object to toggle based on volume
public float volumeThresholdDB = -10.0f; // Default threshold set to -10 dB
```

- `GetCurrentVolumeInDB()`: This method calculates the current volume in decibels using the RMS (Root Mean Square) value of the audio samples.
- `SetVolumeThresholdDB()`: This method allows you to set the threshold dynamically during runtime.