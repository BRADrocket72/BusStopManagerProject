using Domain;

public interface IEntryRepo
{
    Entry AddEntry(Entry entry);
    void DeleteEntry(int entryId);
    List<Entry> GetAllEntries();
    Entry GetEntryById(int id);
    Entry UpdateEntry(Entry entry);
}