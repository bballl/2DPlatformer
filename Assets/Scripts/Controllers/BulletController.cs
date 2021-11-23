using UnityEngine;

namespace PlatformerMVC
{
    public class BulletController
    {
        private Vector3 _velocity;
        private LevelObjectView _view;

        public BulletController(LevelObjectView view)
        {
            _view = view;
            Active(false);
        }

        public void Active(bool value) //метод включает и выключает пулю
        {
            _view.gameObject.SetActive(value);
        }
        
        private void SetVelocity(Vector3 velocity) //метод устанавливает velocity и поворачивает пулю в сторону цели
        {
            _velocity = velocity;
            float angle = Vector3.Angle(Vector3.left, _velocity); //аналогично тому, что делали в CannonAimController.Update()
            Vector3 axis = Vector3.Cross(Vector3.left, _velocity);
            _view._transform.rotation = Quaternion.AngleAxis(angle, axis);
        }

        
        public void Trow(Vector3 position, Vector3 velocity) //активация выброса пули
        {
            Active(true);
            SetVelocity(velocity);
            _view._transform.position = position;
            _view._rigidbody.velocity = Vector2.zero;
            _view._rigidbody.AddForce(velocity, ForceMode2D.Impulse);
        }
    }
}

