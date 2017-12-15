using MedicalTranscriptionEntry.Data_Access;
using MedicalTranscriptionEntry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MedicalTranscriptionEntry.Helper
{
    public class DataAccessHelper
    {
        public bool SubmitData(Patient P)
        {
            DbOperations dbData = new DbOperations();
            return dbData.SubmitData(P);
        }
        public List<Patient> GetAllData(int pageNumber, int recordCount, bool nameSort , bool depSort , bool ageSort , bool subDepSort , bool genderSort )
        {
            DbOperations dbData = new DbOperations();
            return dbData.GetAndBindData(pageNumber, recordCount, nameSort, depSort, ageSort, subDepSort, genderSort);
        }
        public Patient SearchPatient(string patientName, string patientId)
        {
            DbOperations dbData = new DbOperations();
            return dbData.SearchPatient(patientName, patientId);
        }

        public bool UpdateData(Patient Pt)
        {
            DbOperations dbData = new DbOperations();
            return dbData.UpdateData(Pt);
        }

        public bool DeleteData(int Id)
        {
            DbOperations dbData = new DbOperations();
            return dbData.DeleteData(Id);
        }
    }
}