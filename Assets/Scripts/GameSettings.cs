using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Player")]
    public float playerSpeed = 5.0f;
    [Header("Camera")]
    public float cameraSpeed = 5.0f;
    [Header("Platform")]
	public float jumpForce = 10.0f;
}
