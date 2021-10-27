using System.Collections.Generic;
using System;

public class AlertService
{
    private readonly AlertDAO storage = new AlertDAO();
    private readonly IAlertDAO IAD = new AlertDAO();

    public AlertService(IAlertDAO nIAD) 
    {
        IAD = nIAD;
    }

    public Guid RaiseAlert()
    {
        return IAD.AddAlert(DateTime.Now);
    }

    public DateTime GetAlertTime(Guid id)
    {
        return IAD.GetAlert(id);
    }
}

public interface IAlertDAO
{
    
    public Guid AddAlert(DateTime time);


    public DateTime GetAlert(Guid id);


}
public class AlertDAO : IAlertDAO
{
    private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();

    public Guid AddAlert(DateTime time)
    {
        Guid id = Guid.NewGuid();
        this.alerts.Add(id, time);
        return id;
    }

    public DateTime GetAlert(Guid id)
    {
        return this.alerts[id];
    }


}