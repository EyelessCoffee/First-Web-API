using System.Text.Json;

class NoteHolder
{
    public List<Note> Notes { get; private set;} = new();

    #region  Get Requests
    public Note? GetNote(int index)
    {
        if (index < 0 || index >= Notes.Count) return null;
        return Notes[index];
    }

    public List<Note> GetNotes()
    {
        return Notes;
    }

    #endregion

    public Note PostNote(string noteContent)
    {
        // convert content to note
        Note note = new Note
        {
            Time = DateTime.Now.ToString(),
            NoteContent = noteContent
        };

        Notes.Add(note);
        Save();
        return note;
    }

    public bool DeleteNote(int index)
    {
        if(index < 0 || index >= Notes.Count) return false;
        Notes.RemoveAt(index);
        Save();
        return true;
    }

    public void SetNotes(List<Note> newNotes)
    {
        Notes = newNotes;
    }

    void Save()
    {
        string json = JsonSerializer.Serialize(
            Notes, new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText("notes.json", json);
    }
}

public class Note
{
    public string Time { get; set; } = "";
    public string NoteContent { get; set; } = "";
}