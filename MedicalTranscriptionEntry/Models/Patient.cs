using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicalTranscriptionEntry.Models
{
    public class Patient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string SubDepartment { get; set; }
        public string ButtonContent { get; set; }

    }
}