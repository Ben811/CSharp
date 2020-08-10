using Chrome_dino_v2.Model;
using System;

namespace Chrome_dino_v2.ViewModel
{
    public class RandomEntityFactory : IEntityFactory
    {
        private double timeSinceNext;

        private readonly EntitySetup entitySetup;

        private readonly Random random;


        public RandomEntityFactory()
        {
            //generation dealy
            timeSinceNext = 0;

            entitySetup = new EntitySetup();

            random = new Random(1);
        }
        public IEntity Generate(TickEventArgs eventArgs)
        {
            if (timeSinceNext <= entitySetup.TimeToNext)
            {
                timeSinceNext += eventArgs.Period;
                return null;
            }
            else
            {
                timeSinceNext = 0;

                int entityNumber = GenerateEntityNumber();

                if (0 < entityNumber && entityNumber < entitySetup.SmallStepChance)
                    return new Obstacle(entitySetup.SmallStepHeight,
                                        entitySetup.SmallStepWidth);
                else if (40 <= entityNumber && entityNumber < entitySetup.LongStepChance)
                    return new Obstacle(entitySetup.LongStepHeight,
                                        entitySetup.LongStepWidth);
                else
                    return new EnemyV2(entitySetup.EnemyHeight,
                                     entitySetup.EnemyWidth);
            }


        }

        private int GenerateEntityNumber()
        {
            return random.Next(0, entitySetup.SmallStepChance
                                  + entitySetup.LongStepChance
                                  + entitySetup.EnemyChance);
        }

    }

}
