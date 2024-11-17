using SoundDatabase.DataModel;
using System;

namespace SoundDbWpf.ViewModel.Entities
{
    /*public abstract class BaseTableEntityViewModel
    {
        public event Action<BaseTableEntityViewModel> NeedUpdate;
    }*/

    public interface ITableEntityViewModel<T> where T : BaseEntity
    {
        bool NeedApply { get; }

        T Model { get; }
    }
}
