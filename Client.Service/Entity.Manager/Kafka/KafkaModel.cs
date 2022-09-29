using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Manager.Kafka
{
    public class KafkaModel
    {
        public KafkaModel()
        {
            KafkaCorrelationId = Guid.NewGuid();
        }
        public Guid KafkaCorrelationId { get; set; }
        public string Topic { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

    }
}
