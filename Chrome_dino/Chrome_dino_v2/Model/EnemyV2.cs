using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Chrome_dino_v2.Model
{
    public class EnemyV2 : IEntity
    {
        public ElementType Type => ElementType.ENEMY;
        public Rectangle Hitbox { get; }

        private readonly EntitySetup entitySetup;
        private double speedX;
        private double speedY;
        public double X { get; set; }
        public double Y { get; set; }

        public double LevelGround { get; set; }

        public EnemyV2(double height, double width)
        {
            entitySetup = new EntitySetup();

            Hitbox = new Rectangle
            {
                Height = height,
                Width = width,
                Fill = new SolidColorBrush(Colors.Blue),
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 3
            };

            speedX = entitySetup.EnemySpeed;
            speedY = 0;

            LevelGround = 0;
        }

        public void Accelerate(double accelerationX, double accelerationY)
        {
            speedX += accelerationX;
            if (accelerationY <= 0)
                speedY += accelerationY;
            else
                speedY = accelerationY;
        }

        public void Move(double xDelta, double yDelta)
        {
            X -= xDelta;

            if (Y + speedY <= LevelGround)
                Y = LevelGround;
            else
                Y += yDelta;

            Canvas.SetLeft(Hitbox, X);
            Canvas.SetBottom(Hitbox, Y);
        }

        public void Update()
        {

            Move(speedX, speedY);
            if (Y > LevelGround)
            {
                Accelerate(0, -entitySetup.Gravity);
            }

        }

        public bool CheckColision(IElement element)
        {
            double hitboxX = Canvas.GetLeft(Hitbox);
            double hitboxY = Canvas.GetBottom(Hitbox);
            double elementX = Canvas.GetLeft(element.Hitbox);
            double elementY = Canvas.GetBottom(element.Hitbox);

            double elementWidth = element.Hitbox.Width;
            double elementHeight = element.Hitbox.Height;
            if (element.Type == ElementType.OBSTACLE)
            {
                elementWidth += entitySetup.ObstacleMarginWidth;
                elementHeight += entitySetup.ObstacleMarginHeight;
            }

            Rect hitboxRect = new Rect(hitboxX, hitboxY, Hitbox.Width, Hitbox.Height);
            Rect elementRect = new Rect(elementX, elementY, elementWidth, elementHeight);

            return hitboxRect.IntersectsWith(elementRect);

        }
    }
}
