namespace Fish
{
    class Fish
    {
        private float _mass;

        public float mass
        {
            get { return _mass; }
            set
            { 
                if(value > 0)
                {
                    _mass = value;
                    return;
                }
                _mass = 1;
            }
        }

        private float _speed;

        public float speed
        {
            get { return _speed; }
            set
            {
                if (value > 0)
                {
                    _speed = value;
                    return;
                }
                _speed = 1;
            }
        }

        private float _cost;

        public float cost
        {
            get { return _cost; }
            set
            {
                if (value > 0)
                {
                    _cost = value;
                    return;
                }
                _cost = 1;
            }
        }


        public Fish()
        {
            _mass = 1;
            _speed = 1;
            _cost = 1;
        }

        public Fish(float mass, float speed, float cost)
        {
            _mass = mass;
            _speed = speed;
            _cost = cost;
        }
    }
}
