using System.Windows.Controls;
using System.Windows.Shapes;

namespace Chrome_dino_v2.Model
{
    public interface IElement
    {
        Rectangle Hitbox { get; }
        ElementType Type { get; }

        double LevelGround { get; set; }
        bool CheckForEnd()
        {
            double x = Canvas.GetLeft(Hitbox);
            return x <= -Hitbox.Width;
        }
    }
}
