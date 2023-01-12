using UnityEngine;

namespace ShooterBot
{
    public class InputController : IExecute
    {
        private readonly Unit _player;
        private readonly CameraController _cameraController;

        private float forwardDir;
        private float sidesDir;

        public InputController(Unit player, CameraController cameraController)
        {
            _player = player;
            _cameraController = cameraController;

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
        }

    }
}