using SoundDatabase.DataModel;

namespace SoundDbWpf.ViewModel.Entities
{
    public interface ITableEntityViewModel 
    {
        bool NeedApply { get; }

        BaseEntity Model { get; }
    }
}
