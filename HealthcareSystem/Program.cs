using System;

class Program
{
    static void Main()
    {
        // --------------------- Main Application Flow ---------------------
        var app = new HealthSystemApp();

        // 1. Seed sample data (patients and prescriptions)
        app.SeedData();

        // 2. Build the dictionary mapping PatientId -> List<Prescription>
        app.BuildPrescriptionMap();

        // 3. Print all patients
        app.PrintAllPatients();

        // 4. Select a specific patient (e.g., Patient ID 2) and display their prescriptions
        int selectedPatientId = 2;
        app.PrintPrescriptionsForPatient(selectedPatientId);
    }
}
