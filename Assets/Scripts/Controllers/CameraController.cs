using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

namespace ShooterBot
{

    public class CameraController : IExecute
    {
        private Camera _camera;
        private Unit _player;
        private Vector3 _offset;

        private float vertical;
        private float horizontal;

        private float x, y;

        public CameraController(Camera camera, Unit player, Vector3 offset)
        {
            _camera = camera;
            _player = player;
            _offset = offset;
        }

        public Vector3 Position => _camera.transform.position;

        public void Update()
        {
            vertical = Input.GetAxis("Mouse Y");
            horizontal = Input.GetAxis("Mouse X");

            x = _camera.transform.localEulerAngles.y + horizontal;
            y -= vertical;
            _camera.transform.localEulerAngles = new Vector3(y, x, 0);
            _camera.transform.position = _camera.transform.localRotation * _offset + _player.transform.position;


        }
    }
}