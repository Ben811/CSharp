using Chrome_dino_v2.Model;

namespace Chrome_dino_v2.ViewModel
{
    interface IEntityFactory
    {
        IEntity Generate(TickEventArgs eventArgs);
    }
}
