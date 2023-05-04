using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class EntryRepoTests
{
    private readonly DbContextOptions<BusContext> _options;

    public EntryRepoTests()
    {
        // In-memory database options for testing
        _options = new DbContextOptionsBuilder<BusContext>()
            .UseInMemoryDatabase(databaseName: "TestBusDatabase")
            .Options;
    }

    [Fact]
    public void GetAllEntries_ReturnsAllEntriesInDatabase()
    {
        // Arrange
        using var context = new BusContext(_options);
        var entry1 = new Entry { TimeStamp = DateTime.Now, Boarded = 10, LeftBehind = 0 };
        var entry2 = new Entry { TimeStamp = DateTime.Now, Boarded = 5, LeftBehind = 2 };
        var repo = new EntryRepo(context);
        repo.AddEntry(entry1);
        repo.AddEntry(entry2);

        // Act
        var result = repo.GetAllEntries();

        // Assert
        Assert.Equal(4, result.Count);
        Assert.Contains(entry1, result);
        Assert.Contains(entry2, result);
    }

    [Fact]
    public void GetEntryById_ReturnsCorrectEntry()
    {
        // Arrange
        using var context = new BusContext(_options);
        var entry = new Entry { TimeStamp = DateTime.Now, Boarded = 10, LeftBehind = 0 };
        var repo = new EntryRepo(context);
        repo.AddEntry(entry);

        // Act
        var result = repo.GetEntryById(entry.Id);

        // Assert
        Assert.Equal(entry, result);
    }

    [Fact]
    public void GetEntryById_ReturnsNotNullWhenEntryNotFound()
    {
        // Arrange
        using var context = new BusContext(_options);
        var repo = new EntryRepo(context);

        // Act
        var result = repo.GetEntryById(1);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void AddEntry_AddsNewEntryToDatabase()
    {
        // Arrange
        using var context = new BusContext(_options);
        var entry = new Entry { TimeStamp = DateTime.Now, Boarded = 10, LeftBehind = 0 };
        var repo = new EntryRepo(context);

        // Act
        var result = repo.AddEntry(entry);

        // Assert
        Assert.Equal(entry, result);
        Assert.Contains(entry, context.Set<Entry>().ToList());
    }

    [Fact]
    public void UpdateEntry_UpdatesExistingEntryInDatabase()
    {
        // Arrange
        using var context = new BusContext(_options);
        var entry = new Entry { TimeStamp = DateTime.Now, Boarded = 10, LeftBehind = 0 };
        var repo = new EntryRepo(context);
        repo.AddEntry(entry);

        // Update the entry
        entry.Boarded = 15;
        entry.LeftBehind = 1;

        // Act
        var result = repo.UpdateEntry(entry);

        // Assert
        Assert.Equal(entry, result);
        Assert.Equal(15, context.Set<Entry>().Find(entry.Id).Boarded);
        Assert.Equal(1, context.Set<Entry>().Find(entry.Id).LeftBehind);
    }

    [Fact]
    public void DeleteEntry_RemovesEntryFromDatabase()
    {
        // Arrange
        using var context = new BusContext(_options);
        var entry = new Entry { TimeStamp = DateTime.Now, Boarded = 10, LeftBehind = 0 };
        var repo = new EntryRepo(context);
        repo.AddEntry(entry);

        // Act
        repo.DeleteEntry(entry.Id);

        // Assert
        Assert.DoesNotContain(entry, context.Set<Entry>().ToList());
    }
}
