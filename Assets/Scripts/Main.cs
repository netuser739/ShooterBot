using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServiceLocator;

namespace ShooterBot
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Camera _camera;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private Vector3 _offset = new Vector3(0f, 7f, -15f);
        [SerializeField] private Vector3 _amingOffset = new Vector3(4.7f, 7f, -6.20f);

        private CameraController _cameraController;
        private InputController _controller;
        private ListExecuteObjectController _executeObjects;
        private EnemyManager _enemyManager;
        private ServiceLocator<IService> _servicesController;

        ////для костыля врага
        //float _time = 10f;
        //Vector3 dir;

        private void Awake()
        {
            _cameraController = new CameraController(_camera, _player, _offset, _amingOffset);
            _controller = new InputController(_player, _cameraController);
            _executeObjects = new ListExecuteObjectController();
            _enemyManager = new EnemyManager();
            _servicesController = new ServiceLocator<IService>();

            AmoPool amoPool = new AmoPool(30, 1);

            //не понимаю зачем здесь использовать сервис если мы регистрируем пулл в сервисе,
            // а потом просто возвращаем этот пулл в другую переменную. Надо решить как это использовать
            _servicesController.Register(amoPool);
            var ammoPoolService = _servicesController.GetService<AmoPool>();

            if (amoPool.GetBullet(BulletType.DefaultBullet) != null)
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