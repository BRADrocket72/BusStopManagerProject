using Domain;

public interface IDriverRepo
{
    Driver AddDriver(Driver driver);
    void DeleteDriver(int driverId);
    List<Driver> GetAllDrivers();
    Driver GetDriverById(int id);
    Driver UpdateDriver(Driver driver);
}