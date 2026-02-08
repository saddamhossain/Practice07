namespace Practice07;

public class Homework
{
    public string Title { get; }
    public List<string> Tasks { get; }
    public DateTime DueDate { get; }
    public bool IsSubmitted { get; private set; }
    public DateTime? SubmissionDate { get; private set; }

    public Homework(string title, List<string> tasks, DateTime dueDate)
    {
        Validate(title, nameof(title), "Title cannot be null or empty.");

        if (tasks == null || tasks.Count == 0)
            throw new ArgumentException("There must be at least one task.", nameof(tasks));

        if (dueDate.Date < DateTime.Now.Date)
            throw new ArgumentException("Due date cannot be in the past.", nameof(dueDate));

        Title = title;
        Tasks = tasks;
        DueDate = dueDate;
        IsSubmitted = false;
    }

    public void Submit(DateTime submissionDate)
    {
        EnsureNotSubmitted();

        ValidateSubmissionDate(submissionDate);

        SubmissionDate = submissionDate;
        IsSubmitted = true;
    }

    public void UndoSubmission()
    {
        EnsureSubmitted();

        SubmissionDate = null;
        IsSubmitted = false;
    }

    private void Validate(string value, string paramName, string message)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(message, paramName);
    }

    private void ValidateSubmissionDate(DateTime submissionDate)
    {
        if (submissionDate.Date > DueDate.Date)
            throw new ArgumentException("Submission date cannot be after the due date.");
    }

    private void EnsureNotSubmitted()
    {
        if (IsSubmitted)
            throw new InvalidOperationException($"{Title} is already submitted.");
    }

    private void EnsureSubmitted()
    {
        if (!IsSubmitted)
            throw new InvalidOperationException($"{Title} is not yet submitted.");
    }
}