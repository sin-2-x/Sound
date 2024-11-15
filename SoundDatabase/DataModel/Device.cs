using System.Collections.Generic;

namespace SoundDatabase.DataModel
{
    public class Device :BaseEntity
    {
        public string Name { get; set; }
        public List<DeviceWorkSession> DeviceWorkSession { get; set; }
    }
}
