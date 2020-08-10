//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Media;
//using System.Windows.Shapes;

//namespace Chrome_dino_v2.Model
//{
//    public class Enemy : IEntity
//    {
//        private bool onGround;
//        private double airTime;
//        private readonly EntitySetup entitySetup;


//        public ElementType Type => ElementType.ENEMY;
//        public Rectangle Hitbox { get; }        
//        public double Velocity { get; }
//        public bool JumpTriggerd { get; set; }
//        public double LevelGround { get; set; }

//        public Enemy(double height, double width, double velocity)
//        {
//            onGround = true;
//            airTime = 0;
//            entitySetup = new EntitySetup();


//            Hitbox = new Rectangle
//            {
//                Height = height,
//                Width = width,
//                Fill = new SolidColorBrush(Colors.Blue),
//                Stroke = new SolidColorBrush(Colors.Black),
//                StrokeThickness = 3
//            };            

//            Velocity = velocity;            

//            JumpTriggerd = false;

//            LevelGround = 0;
//        }

//         public void Update(TickEventArgs eventArgs)
//         {
//             double x, y;

//             //begin jump
//             if (JumpTriggerd)
//             {
//                 onGround = false;

//                 if (airTime >= entitySetup.EnemyAirHalfTime)
//                 {
//                     JumpTriggerd = false;
//                     airTime = 0;
//                 }

//                 airTime += eventArgs.Period; 
//                 y = Canvas.GetBottom(Hitbox);
//                 Canvas.SetBottom(Hitbox, y + entitySetup.EnemyFlyVelocity);
//             }

//             //end jump
//             if (!JumpTriggerd && !onGround)
//             {
//                 y = Canvas.GetBottom(Hitbox);

//                 if (y > 0)
//                     Canvas.SetBottom(Hitbox, y - entitySetup.EnemyFlyVelocity);
//                 else
//                 {
//                     onGround = true;
//                     Canvas.SetBottom(Hitbox, 0);
//                 }


//             }

//             x = Canvas.GetLeft(Hitbox);

//             Canvas.SetLeft(Hitbox, x - Velocity);
//         }

//        public bool CheckColision(IElement element)
//        {
//            double hitboxX = Canvas.GetLeft(Hitbox);
//            double hitboxY = Canvas.GetBottom(Hitbox);
//            double elementX = Canvas.GetLeft(element.Hitbox);
//            double elementY = Canvas.GetBottom(element.Hitbox);

//            Rect hitboxRect = new Rect(hitboxX, hitboxY, Hitbox.Width, Hitbox.Height);

//            double elementWidth = element.Hitbox.Width;
//            double elementHeight = element.Hitbox.Height;
//            if (element.Type == ElementType.OBSTACLE)
//            {
//                elementWidth += entitySetup.ObstacleMarginWidth;
//                elementHeight += entitySetup.ObstacleMarginHeight;
//            }

//            Rect elementRect = new Rect(elementX, elementY, elementWidth, elementHeight);

//            return hitboxRect.IntersectsWith(elementRect);

//        }
//    }
//}
