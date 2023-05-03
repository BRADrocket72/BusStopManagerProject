using Domain;
using Microsoft.EntityFrameworkCore;
public class EntryRepo
{
    private readonly DbContext _context;

    public EntryRepo(DbContext context)
    {
        _context = context;
    }

    // Get all entries from the database
    public List<Entry> GetAllEntries()
    {
        return _context.Set<Entry>().ToList();
    }

    // Get an entry by its ID
    public Entry GetEntryById(int id)
    {
        return _context.Set<Entry>().Find(id);
    }

    // Add a new entry to the database
    public Entry AddEntry(Entry entry)
    {
        _context.Set<Entry>().Add(entry);
        _context.SaveChanges();
        return entry;
    }

    // Update an entry in the database
    public Entry UpdateEntry(Entry entry)
    {
        _context.Entry(entry).State = EntityState.Modified;
        _context.SaveChanges();
        return entry;
    }

    // Delete an entry from the database
    public void DeleteEntry(int entryId)
    {
        var entry = _context.Set<Entry>().Find(entryId);
        if (entry != null)
        {
            _context.Set<Entry>().Remove(entry);
            _context.SaveChanges();
        }
    }
}
