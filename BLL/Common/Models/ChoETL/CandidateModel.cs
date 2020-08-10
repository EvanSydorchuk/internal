using ChoETL;

namespace BLL.Common.Models.ChoETL
{
    [ChoCSVRecordObject(
   ErrorMode = ChoErrorMode.IgnoreAndContinue, IgnoreFieldValueMode = ChoIgnoreFieldValueMode.Any, ThrowAndStopOnMissingField = false)]
    public class CandidateModel
    {
        [ChoCSVRecordField(1,FieldName = "Name")]
        public string Name { get; set; }

        [ChoCSVRecordField(2,FieldName = "Surname")]
        public string Surname { get; set; }

        [ChoCSVRecordField(3,FieldName = "Location")]
        public string Location { get; set; }

        [ChoCSVRecordField(4,FieldName = "Competence")]
        public string Competence { get; set; }

        [ChoCSVRecordField(5,FieldName = "Competence Level")]
        public string CompetenceLevel { get; set; }

        [ChoCSVRecordField(6,FieldName = "Contacts")]
        public string Contacts { get; set; }
    }
}
