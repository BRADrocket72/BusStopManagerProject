using Domain;

public interface IStopRepo
{
    Stop AddStop(Stop stop);
    void DeleteStop(int stopId);
    List<Stop> GetAllStops();
    Stop GetStopById(int id);
    Stop UpdateStop(Stop stop);
}