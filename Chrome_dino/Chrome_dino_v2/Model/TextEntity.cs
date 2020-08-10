namespace Chrome_dino_v2.Model
{
    class TextEntity
    {
        private const double FRICTION = 0.99;
        private const double GRAVITY = 0.01;
        private double posX;
        private double posY;
        private double speedX = 0;
        private double speedY = 0;

        public TextEntity(double posX, double posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public void Accelerate(double accelerationX, double accelerationY)
        {
            speedX += accelerationX;
            speedY += accelerationY;
        }

        public void Move(double xDelta, double yDelta)
        {
            posX += xDelta;
            posY += yDelta;
        }

        public void Update()
        {
            Move(speedX, speedY);
            speedX *= FRICTION;
            speedY *= FRICTION;
            Accelerate(0, -GRAVITY);
        }
    }

}
