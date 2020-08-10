namespace Chrome_dino_v2.Model
{
    public class EntitySetup
    {
        //Obstacle setup
        public double SmallStepHeight { get; }
        public double SmallStepWidth { get; }
        public double LongStepHeight { get; }
        public double LongStepWidth { get; }
        public double ObstacleMarginWidth { get; }
        public double ObstacleMarginHeight { get; }


        //game speed setup
        public int TimerSpeed { get; }
        public double GameSpeed { get; }


        //enemy setup
        public double EnemyHeight { get; }
        public double EnemyWidth { get; }
        public double EnemySpeed { get; }
        //enemy setup jump
        public double EnemyFlyVelocity { get; }


        //generation rules
        public int SmallStepChance { get; }
        public int LongStepChance { get; }
        public int EnemyChance { get; }
        public int TimeToNext { get; }


        //player setup
        public double PlayerHeight { get; }
        public double PlayerWidth { get; }
        public double PlayerCrowl { get; }
        public double PlayerFlyVelocity { get; }
        public double PlayerMoveVelocity { get; }

        //scene setup
        public double Friction { get; }
        public double Gravity { get; }
        public double SceneWidth { get; }
        public double SceneHeight { get; }

        public EntitySetup()
        {
            //Obstacle setup
            SmallStepHeight = 30;
            SmallStepWidth = 60;
            LongStepHeight = 40;
            LongStepWidth = 240;

            ObstacleMarginWidth = 15;
            ObstacleMarginHeight = 1;


            //game speed
            TimerSpeed = 1;
            GameSpeed = 0.3;

            //enemy setup
            EnemyHeight = 15;
            EnemyWidth = 15;
            EnemySpeed = 0.8;
            //enemy setup jump
            EnemyFlyVelocity = 1.8;

            //generation rules
            SmallStepChance = 50;
            LongStepChance = 50;
            EnemyChance = 0;
            TimeToNext = 500;

            //player setup
            PlayerHeight = 40;
            PlayerWidth = 30;
            PlayerCrowl = 15;
            PlayerFlyVelocity = 5;
            PlayerMoveVelocity = 0.5;

            //scene setup
            Friction = 0.99;
            Gravity = 0.01;
            SceneHeight = 400;
            SceneWidth = 800;

        }

    }
}
