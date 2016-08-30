using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    public class QuestionnaireEntity
    {
        public List<QuestionAnswerEntity> questions { get; set; }
        public int QuestionnaireId { get; set; }

    }
}
