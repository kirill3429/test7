
using UnityEngine;
using UnityEngine.UI;

public class JoystickInputHandler : InputHandler
{
    private void Update()
    {
        action = false;
        direction = Vector3.zero;
    }
    public void onUpButtonDown()
    {
        direction.x = 1;
        direction.y = 0;
    }
    public void onDownButtonDown()
    {
        direction.x = -1;
        direction.y = 0;
    }
    public void onLeftButtonDown()
    {
        direction.y = 1;
        direction.x = 0;
    }
    public void onRightButtonDown()
    {
        direction.y = -1;
        direction.x = 0;
    }

    public void onBombButtonDown()
    {
        action = true;
    }
}
