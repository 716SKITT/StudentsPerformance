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
        Id = Guid.NewGuid();
        TableName = tableName;
        OperationType = operationType;
        OperationTime = operationTime;
        Username = username;
    }
}
