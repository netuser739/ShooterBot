using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShooterBot
{

    public class Main : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Camera _camera;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private Vector3 _offset = new Vector3(0f, 7f, -15f);

        private CameraController _cameraController;
        private InputController _controller;
        private ListExecuteObjectController _executeObjects;
        private EnemyManager _enemyManager;

        ////для костыля врага
        //float _time = 10f;
        //Vector3 dir;

        private void Awake()
        {
            _cameraController = new CameraController(_camera, _player, _offset);
            _controller = new InputController(_player, _cameraController);
            _executeObjects = new ListExecuteObjectController();
            _enemyManager = new EnemyManager();

            AmoPool amoPool = new AmoPool(30);
            if(amoPool.GetBullet(BulletType.DefaultBullet) != null)
            {
                var bullet = amoPool.GetBullet(BulletType.DefaultBullet); 
                bullet.transform.position = Vector3.one;
                bullet.gameObject.SetActive(true);
            }
           

            _executeObjects.Add(_controller);
            _executeObjects.Add(_cameraController);
            _executeObjects.Add(_weapon);

            Cursor.lockState = CursorLockMode.Locked;

        }

        private void Update()
        {
            for (int i = 0; i < _executeObjects.Lenght; i++)
            {
                _executeObjects[i].Update();
            }

            ////Сейчай будет жесткий временный костыль перемещения врага
            //if (_time > 12f)
            //{
            //    dir = Enemy.RandomDir();
            //    _time = 0f;
            //}

            //это тоже пока так, но мб и конечный варик
            foreach(IWork enemy in _enemyManager.SpiderBots)
            {
                enemy.Work();
            }
            //_time += Time.deltaTime;
            //_enemy.Move(dir);
            //_enemy.Rotate(dir);

        }

    }
}