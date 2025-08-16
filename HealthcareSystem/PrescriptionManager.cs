using System;
using System.Collections.Generic;
using System.Linq;

public class PrescriptionManager
{
    // Dictionary to group prescriptions by PatientId
    private Dictionary<int, List<Prescription>> _prescriptionsByPatient = new Dictionary<int, List<Prescription>>();

    // Constructor accepts a list of prescriptions and populates the dictionary
    public PrescriptionManager(List<Prescription> prescriptions)
    {
        // Group prescriptions by PatientId
        _prescriptionsByPatient = prescriptions
            .GroupBy(p => p.PatientId)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Retrieve prescriptions for a specific patient
    public List<Prescription> GetPrescriptionsByPatientId(int patientId)
    {
        if (_prescriptionsByPatient.ContainsKey(patientId))
        {
            return _prescriptionsByPatient[patientId];
        }
        return new List<Prescription>(); // Return empty list if none found
    }
}
