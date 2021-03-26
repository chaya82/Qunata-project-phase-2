using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCLS
{
    [Serializable]
    public class TransportationPacket
    {
        public TransportationPacket()
        {
            //Default Constructor
        }

        ~TransportationPacket()
        {
            //Default Destructor
        }

        public virtual void Dispose()
        {

        }

        public int MessageId
        { get; set; }

        public object MessagePacket
        { get; set; }

        public object MessageResultset
        { get; set; }

        public object MessageResultsetDS
        { get; set; }

        public EStatus MessageStatus
        { get; set; }

        public EMessageType MessageType
        { get; set; }

        public Exception ex
        { get; set; }
    }
}
