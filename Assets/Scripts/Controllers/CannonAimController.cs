using UnityEngine;

namespace PlatformerMVC
{
    public class CannonAimController
    {
        private Transform _muzzleTransform;
        private Transform _targetTransform;

        private Vector3 _dir;
        private float _angle;
        private Vector3 _axes;

        public CannonAimController(Transform muzzleTransform, Transform playerTransform)
        {
            _muzzleTransform = muzzleTransform;
            _targetTransform = playerTransform;
        }
        
        public void Update()
        {
            _dir = _targetTransform.position - _muzzleTransform.position; //вычисляем направление к цели, вычитая из точки финиша
                                                                          //точку старта (координаты игрока минус координаты пушки)

            _angle = Vector3.Angle(Vector3.down, _dir); //находим угол поворота
            _axes = Vector3.Cross(Vector3.down, _dir); //получаем вектор, вокруг которого будем выполнять поворот
            _muzzleTransform.rotation = Quaternion.AngleAxis(_angle, _axes); //выполняем поворот пушки
        }
    }
}

