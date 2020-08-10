using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Chrome_dino_v2.Model
{
    public class Obstacle : IEntity
    {
        public ElementType Type => ElementType.OBSTACLE;
        public Rectangle Hitbox { get; }

        private readonly EntitySetup entitySetup;
        private double speedX;
        private double speedY;
        public double X { get; set; }
        public double Y { get; set; }

        public double LevelGround { get; set; }

        public Obstacle(double height, double width)
        {
            entitySetup = new EntitySetup();

            Hitbox = new Rectangle
            {
                Height = height,
                Width = width,
                Fill = new SolidColorBrush(Colors.Red),
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 3
            };

            speedX = entitySetup.GameSpeed;
            speedY = 0;

            LevelGround = 0;
        }

        public void Accelerate(double accelerationX, double accelerationY)
        {
            speedX += accelerationX;
            speedY += accelerationY;
        }

        public void Move(double xDelta, double yDelta)
        {
            X -= xDelta;
            Y += yDelta;
            Canvas.SetLeft(Hitbox, X);
            Canvas.SetBottom(Hitbox, Y);
        }

        public void Update()
        {
            Move(speedX, speedY);
        }

        public bool CheckColision(IElement element)
        {
            double hitboxX = Canvas.GetLeft(Hitbox);
            double hitboxY = Canvas.GetBottom(Hitbox);
            double elementX = Canvas.GetLeft(element.Hitbox);
            double elementY = Canvas.GetBottom(element.Hitbox);

            double hitWidth = Hitbox.Width;
            double hitHeight = Hitbox.Height;
            double elWidth = element.Hitbox.Width;
            double elHeight = element.Hitbox.Height;

            Rect hitboxRect = new Rect(hitboxX, hitboxY, hitWidth, hitHeight);
            Rect elementRect = new Rect(elementX, elementY, elWidth, elHeight);

            return hitboxRect.IntersectsWith(elementRect);
        }
    }
}
