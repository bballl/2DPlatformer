using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private CannonView _cannonView;

        private SpriteAnimatorController _playerAnimator;
        private CameraController _cameracontroller;
        private CannonAimController _cannon;
        private BulletEmitterController _bulletEmitterController;

        private PlayerController _playerController;

        void Start()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");

            if (_playerConfig)
            {
                _playerAnimator = new SpriteAnimatorController(_playerConfig);
            }

            _playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Run, true, _animationSpeed);

            _playerController = new PlayerController(_playerView, _playerAnimator);

            _cameracontroller = new CameraController(_playerView._transform, Camera.main.transform);

            _cannon = new CannonAimController(_cannonView._muzzleTransform, _playerView._transform);
            _bulletEmitterController = new BulletEmitterController(_cannonView._bullets, _cannonView._emitterTransform);
        }

        void Update()
        {
            _playerController.Update();
            _cameracontroller.Update();
            _cannon.Update();
            _bulletEmitterController.Update();
        }
    }
}

