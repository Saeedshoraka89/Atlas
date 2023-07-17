namespace Framework.Domain;

public class BaseEntity
{
    private readonly DateTime _date = DateTime.Now;
    private readonly PersianCalendar _persian = new();

    protected BaseEntity()
    {
        CreationDate = _persian.GetYear(_date) + "/" + _persian.GetMonth(_date) + "/" + _persian.GetDayOfMonth(_date);
    }

    public Ulid Id { get; set; }
    public string CreationDate { get; set; }
}