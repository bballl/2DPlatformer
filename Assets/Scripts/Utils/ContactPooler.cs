using UnityEngine;

namespace PlatformerMVC
{
    public class ContactPooler
    {
        private ContactPoint2D[] _contacts = new ContactPoint2D[10];
        private const float _collTreshold = 0.6f; //погрешность на столкновение
        private int _contactCount; //кол-во контактов
        private Collider2D _collider2D;

        public bool IsGrounded { get; private set; }
        public bool HasLeftContact { get; private set; } //контакт слева
        public bool HasRightContact { get; private set; } //контакт справа

        public ContactPooler(Collider2D collider)
        {
            _collider2D = collider;
        }

        public void Update()
        {
            IsGrounded = false;
            HasRightContact = false;
            HasLeftContact = false;

            _contactCount = _collider2D.GetContacts(_contacts); //GetContacts возвращает нам контакты

            for (int i = 0; i < _contactCount; i++) 
            {
                if (_contacts[i].normal.y > _collTreshold) IsGrounded = true;
                if (_contacts[i].normal.x > _collTreshold) HasLeftContact = true;
                if (_contacts[i].normal.y > -_collTreshold) HasRightContact = true;
            }
        }
    }
}

