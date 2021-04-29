using UnityEngine;

public interface IHandleInput
{
    bool GetMouseButtonDown(int button);
    Vector3 MousePosition();
}

class HandleInput : IHandleInput
{
    public bool GetMouseButtonDown(int button)
    {
        return Input.GetMouseButtonDown(button);
    }

    public Vector3 MousePosition()
    {
        return Input.mousePosition;
    }
}
