using System.Text.Json;

class NoteHolder
{
    public List<Note> notes { get; private set;} = new();

    #region  Get Requests
    public Note? GetNote(int index)
    {
        if (index < 0 || index >= notes.Count) return null;
        return notes[index];
    }

    public List<Note> GetNotes()
    {
        return notes;
    }

    #endregion

    public Note PostNote(string noteContent)
    {
        // convert content to note
        Note note = new Note
        {
            time = DateTime.Now.ToString(),
            noteContent = noteContent
        };

        notes.Add(note);
        Save();
        return note;
    }

    public bool DeleteNote(int index)
    {
        if(index < 0 || index >= notes.Count) return false;
        notes.RemoveAt(index);
        Save();
        return true;
    }

    public void SetNotes(List<Note> newNotes)
    {
        notes = newNotes;
    }

    void Save()
    {
        string json = JsonSerializer.Serialize(
            notes, new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText("notes.json", json);
    }
}

public class Note
{
    public string time { get; set; } = "";
    public string noteContent { get; set; } = "";
}