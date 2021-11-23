using UnityEngine;

namespace PlatformerMVC
{
    public class CameraController
    {
        private float X;
        private float Y;

        private float offsetY;
        private float offsetX;

        private int _camSpeed = 300;

        private Transform _playerTransform;
        private Transform _cameraTransform;

        public CameraController(Transform player, Transform camera)
        {
            _playerTransform = player;
            _cameraTransform = camera;
        }


        public void Update()
        {
            Y = _playerTransform.transform.position.y;
            X = _playerTransform.transform.position.x;

            _cameraTransform.transform.position = Vector3.Lerp(_cameraTransform.position, 
                new Vector3(X + offsetX, Y + offsetY, _cameraTransform.position.z), Time.deltaTime * _camSpeed);
        }
    }
}

