using System;

class Program
{
    static void Main()
    {
        // Create instance of HealthSystemApp
        var app = new HealthSystemApp();

        // Seed sample data
        app.SeedData();

        // Build the prescription dictionary
        app.BuildPrescriptionMap();

        // Print all patients
        app.PrintAllPatients();

        // Print prescriptions for each patient
        foreach (var patientId in new int[] { 1, 2, 3 })
        {
            app.PrintPrescriptionsForPatient(patientId);
        }
    }
}

