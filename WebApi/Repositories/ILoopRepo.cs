using Domain;

public interface ILoopRepo
{
    Loop AddLoop(Loop loop);
    void DeleteLoop(int loopId);
    List<Loop> GetAllLoops();
    Loop GetLoopById(int id);
    Loop UpdateLoop(Loop loop);
}