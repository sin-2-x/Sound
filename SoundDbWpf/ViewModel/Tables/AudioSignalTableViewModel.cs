using SoundDatabase.DataModel;
using SoundDbModel.Tables;
using SoundDbWpf.ViewModel.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundDbWpf.ViewModel.Tables
{
    public class AudioSignalTableViewModel : BaseTableViewModel<AudioSignalViewModel, AudioSignal>
    {
        DeviceWorkSessionTableViewModel workSessionTableViewModel;
        public AudioSignalTableViewModel(DeviceWorkSessionTableViewModel workSessionTableViewModel) : base(new AudioSignalTable(), TableEnum.AudioSignal)
        {
            this.workSessionTableViewModel = workSessionTableViewModel;
        }

        public ObservableCollection<DeviceWorkSessionViewModel> DeviceWorkSessionViewModels => workSessionTableViewModel.Items;

        public override void UpdateImpl()
        {
            workSessionTableViewModel.UpdateImpl();
            base.UpdateImpl();
        }

        protected override AudioSignalViewModel CreateViewModel(AudioSignal e)
        {
            var vm = new AudioSignalViewModel(e)
            {
                DeviceWorkSession = DeviceWorkSessionViewModels.FirstOrDefault(d => d.Model.Id == e.DeviceWorkSessionId)
            };
            return vm;
        }
    }
}
