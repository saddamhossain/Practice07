Homework homework = new Homework("Math Assignment", new List<string> { "Algebra Problems", "Geometry Exercises" }, DateTime.Today.AddDays(5));

try
{
    ProcessSubmission(homework);

    UndoSubmission(homework);
}
catch (Exception ex)
{
    Console.WriteLine($"\nError: {ex.Message}");
}

void ProcessSubmission(Homework homework)
{
    Console.WriteLine("Processing Submission...\n");

    var submissionDate = DateTime.Today;

    homework.Submit(submissionDate);

    Console.WriteLine($"Homework : {homework.Title}");
    Console.WriteLine($"Submitted : {submissionDate:MM/dd/yyyy}");
    Console.WriteLine($"Status    : {(homework.IsSubmitted ? "Submitted" : "Pending")}");
    Console.WriteLine(new string('-', 40) + "\n");
}

void UndoSubmission(Homework homework)
{
    Console.WriteLine("Undoing Submission...\n");

    homework.UndoSubmission();

    Console.WriteLine($"Homework : {homework.Title}");
    Console.WriteLine($"Status    : {(homework.IsSubmitted ? "Submitted" : "Pending")}");
    Console.WriteLine(new string('-', 40) + "\n");
}