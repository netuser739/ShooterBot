using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShooterBot
{

    public class Main : MonoBehaviour
    {
        [SerializeField] private Unit _player;
        [SerializeField] private Camera _camera;
        [SerializeField] private Vector3 _offset = new Vector3(0f, 7f, -15f);

        private CameraController _cameraController;
        private InputController _controller;
        private ListExecuteObjectController _executeObjects;

        private void Awake()
        {
            _cameraController = new CameraController(_camera, _player, _offset);
            _controller = new InputController(_player, _cameraController);
            _executeObjects = new ListExecuteObjectController();

            _executeObjects.Add(_controller);
            _executeObjects.Add(_cameraController);

            Cursor.lockState = CursorLockMode.Locked;

        }

        private void Update()
        {

            for (int i = 0; i < _executeObjects.Lenght; i++)
            {
                _executeObjects[i].Update();
            }

        }


    }
}