using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSpace
{
    public class Character
    {
        //Champs
        //Points de vie
        int _hp;
        public int HP => _hp;

        //Points de vie max
        int _maxHp;
        public int MaxHp => _maxHp;

        //Est-on en vie ?
        bool _alive = true;
        public bool Alive => _alive;

        //Constructeur
        public Character(int hp, int maxHp = 20)
        {
            _hp = hp;
            _maxHp = maxHp;
        }

        //Fonctions
        public void TakeDamage(int damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                _alive = false;
                _hp = 0;
            }
        }

        public void Heal(int heal)
        {
            _hp += heal;
            if (_hp > _maxHp)
            {
                _hp = _maxHp;
            }
        }

        public void Resurect()
        {
            _alive = true;
            _hp = _maxHp;
        }
    }
}
