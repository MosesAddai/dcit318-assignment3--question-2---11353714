using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // --------------------- Sample Patients ---------------------
        var patient1 = new Patient(1, "Alice Johnson", 30, "Female");
        var patient2 = new Patient(2, "Bob Smith", 45, "Male");

        // --------------------- Sample Prescriptions ---------------------
        var prescriptions = new List<Prescription>
        {
            new Prescription(1, 1, "Amoxicillin", DateTime.Now.AddDays(-2)),
            new Prescription(2, 1, "Ibuprofen", DateTime.Now.AddDays(-1)),
            new Prescription(3, 2, "Lisinopril", DateTime.Now)
        };

        // --------------------- Initialize PrescriptionManager ---------------------
        var prescriptionManager = new PrescriptionManager(prescriptions);

        // --------------------- Retrieve Prescriptions by Patient ID ---------------------
        Console.WriteLine($"Prescriptions for {patient1.Name}:");
        var patient1Prescriptions = prescriptionManager.GetPrescriptionsByPatientId(patient1.Id);
        foreach (var p in patient1Prescriptions)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine($"\nPrescriptions for {patient2.Name}:");
        var patient2Prescriptions = prescriptionManager.GetPrescriptionsByPatientId(patient2.Id);
        foreach (var p in patient2Prescriptions)
        {
            Console.WriteLine(p);
        }
    }
}
