namespace Chrome_dino_v2.Model
{
    public interface IEntity : IElement
    {
        double X { get; set; }
        double Y { get; set; }
        void Update();
        bool CheckColision(IElement element);
        void Accelerate(double accelerationX, double accelerationY);
        public void Move(double speedX, double speedY);
    }
}
