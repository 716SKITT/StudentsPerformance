namespace StudyPerformance.Domain.Entities;

public class AuditLog
{
    public Guid Id { get; private set; }

    public string TableName { get; private set; }

    public string OperationType { get; private set; }

    public DateTime OperationTime { get; private set; }

    public string Username { get; private set; }

    private AuditLog() { }

    public AuditLog(string tableName, string operationType, DateTime operationTime, string username)
    {
        if (string.IsNullOrWhiteSpace(tableName))
            throw new ArgumentException("TableName is required.", nameof(tableName));

        if (string.IsNullOrWhiteSpace(operationType))
            throw new ArgumentException("OperationType is required.", nameof(operationType));

        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username is required.", nameof(username));

        Id = Guid.NewGuid();
        TableName = tableName;
        OperationType = operationType;
        OperationTime = operationTime;
        Username = username;
    }
}
