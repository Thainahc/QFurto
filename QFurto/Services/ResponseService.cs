using QFurto.Models.Enums;
using System.Collections.Generic;

namespace QFurto.Services
{
    public class ResponseService
    {
        string _message = string.Empty;
        List<string> _fieldsInvalids = new List<string>();

        public ResponseTypeEnum Type { get; set; }
        public string Message
        {
            get
            {
                return _message ?? string.Empty;
            }
            set
            {
                _message = value;
            }
        }

        public List<string> FieldsInvalids
        {
            get
            {
                return _fieldsInvalids ?? new List<string>();
            }
            set
            {
                _fieldsInvalids = value;
            }
        }
    }
}