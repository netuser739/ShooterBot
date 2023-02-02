using UnityEngine;
using UnityEngine.UIElements;

namespace ShooterBot
{
    public class InputController : IExecute
    {
        private readonly Player _player;
        private readonly CameraController _cameraController;
        
        private float forwardDir;
        private float sidesDir;

        private float timeToRealse;

        public InputController(Player player, CameraController cameraController)
        {
            _player = player;
            _cameraController = cameraController;

            timeToRealse = 0f;

        }

        public void Update()
        {
            sidesDir = Input.GetAxis("Horizontal");
            forwardDir = Input.GetAxis("Vertical");
            
            Vector3 cameraLook = _player.Position - _cameraController.Position;
            cameraLook.y = 0f;

            Vector3 move = cameraLook * forwardDir + Vector3.Cross(Vector3.up, cameraLook) * sidesDir;

            _player.Move(move);
            _player.Rotate(move);
            _player.Animation(_player.Animator, move.magnitude);

            if (Input.GetKeyDown(KeyCode.E) && _player.WeaponGrab)
            {
                _player.WeaponTake(_player.WeaponCollider.gameObject);
                timeToRealse = 0f;

            }

            if (Input.GetKey(KeyCode.E))
            {
                timeToRealse += Time.deltaTime;
            }
            if(timeToRealse > 1f && _player.WithWeapon) 
            {
                _player.WeaponRelease(_player.WeaponCollider.gameObject);
                timeToRealse = 0f;
            }

            if (Input.GetMouseButtonDown(1) && _player.WithWeapon)
            {
                _player.Aming = true;
            }
            if(Input.GetMouseButtonUp(1)) 
            {
                _player.Aming = false;
            }
           
        }
        
    }
}