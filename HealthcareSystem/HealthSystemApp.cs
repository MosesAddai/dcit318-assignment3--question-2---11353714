using System;
using System.Collections.Generic;
using System.Linq;

public class HealthSystemApp
{
    // Fields
    private Repository<Patient> _patientRepo = new Repository<Patient>();
    private Repository<Prescription> _prescriptionRepo = new Repository<Prescription>();
    private Dictionary<int, List<Prescription>> _prescriptionMap = new Dictionary<int, List<Prescription>>();

    // Seed initial data
    public void SeedData()
    {
        // Add patients
        _patientRepo.Add(new Patient(1, "Alice Johnson", 30, "Female"));
        _patientRepo.Add(new Patient(2, "Bob Smith", 45, "Male"));
        _patientRepo.Add(new Patient(3, "Charlie Brown", 28, "Male"));

        // Add prescriptions (valid PatientIds)
        _prescriptionRepo.Add(new Prescription(1, 1, "Amoxicillin", DateTime.Now.AddDays(-2)));
        _prescriptionRepo.Add(new Prescription(2, 1, "Ibuprofen", DateTime.Now.AddDays(-1)));
        _prescriptionRepo.Add(new Prescription(3, 2, "Lisinopril", DateTime.Now));
        _prescriptionRepo.Add(new Prescription(4, 3, "Metformin", DateTime.Now.AddDays(-3)));
        _prescriptionRepo.Add(new Prescription(5, 2, "Atorvastatin", DateTime.Now.AddDays(-1)));
    }

    // Build the dictionary mapping PatientId -> List<Prescription>
    public void BuildPrescriptionMap()
    {
        _prescriptionMap.Clear();
        foreach (var p in _prescriptionRepo.GetAll())
        {
            if (!_prescriptionMap.ContainsKey(p.PatientId))
            {
                _prescriptionMap[p.PatientId] = new List<Prescription>();
            }
            _prescriptionMap[p.PatientId].Add(p);
        }
    }

    // Print all patients
    public void PrintAllPatients()
    {
        Console.WriteLine("=== All Patients ===");
        foreach (var patient in _patientRepo.GetAll())
        {
            Console.WriteLine(patient);
        }
    }

    // Print prescriptions for a specific patient
    public void PrintPrescriptionsForPatient(int patientId)
    {
        Console.WriteLine($"\n=== Prescriptions for Patient ID {patientId} ===");
        if (_prescriptionMap.ContainsKey(patientId))
        {
            foreach (var p in _prescriptionMap[patientId])
            {
                Console.WriteLine(p);
            }
        }
        else
        {
            Console.WriteLine("No prescriptions found for this patient.");
        }
    }
}
