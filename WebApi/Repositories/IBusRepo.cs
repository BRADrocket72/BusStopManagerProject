using Domain;

public interface IBusRepo
{
    Bus AddBus(Bus bus);
    void DeleteBus(int busId);
    List<Bus> GetAllBuses();
    Bus GetBusById(int id);
    Bus UpdateBus(Bus bus);
}