using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    public event Action<Vector2> Moved;
    public event Action<Vector2> Looked;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw(Horizontal);
        float vertical = Input.GetAxisRaw(Vertical);
        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
        Moved?.Invoke(moveDirection);

        float mouseX = Input.GetAxis(MouseX);
        float mouseY = Input.GetAxis(MouseY);
        Looked?.Invoke(new Vector2(mouseX, mouseY));
    }
}
