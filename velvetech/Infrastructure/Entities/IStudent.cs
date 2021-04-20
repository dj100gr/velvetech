namespace velvetech.Infrastructure
{
    public interface IStudent : IEntity
    {
        int? Pol { get; set; }
        string Fam { get; set; }
        string Nam { get; set; }
        string Oth { get; set; }
        string Alias { get; set; }
    }
}
