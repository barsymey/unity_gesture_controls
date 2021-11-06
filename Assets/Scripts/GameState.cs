using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    [SerializeField] 
    private PlayerControls _player;

    [SerializeField] 
    private Dropdown _dropdown;
    
    public void ChangeControls()
    {
        switch (_dropdown.value)
        {
            case 0:
                _player.ChangeControls(PlayerControls.ControlMethods.Keys);
                break;
            case 1:
                _player.ChangeControls(PlayerControls.ControlMethods.Swipe);
                break;
            case 2:                
                _player.ChangeControls(PlayerControls.ControlMethods.Drag);
                break;
        }
    }
}
