using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundDatabase.DataModel
{
    public class Device :BaseEntity
    {
        public string Name { get; set; }
        public List<DeviceWorkSession> DeviceWorkSession { get; set; }
    }
}
