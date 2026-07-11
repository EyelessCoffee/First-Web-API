using System.Text.Json;

// create a builder class instance which will create the application
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
// only if the app is not fully deployed
if (app.Environment.IsDevelopment()) app.MapOpenApi();


// create the noteHolder
NoteHolder noteHolder = new();

// if the file doesnt exist the noteHolder will make it
if (File.Exists("notes.json"))
{
    string json = File.ReadAllText("notes.json");
    List<Note>? loadedNotes = JsonSerializer.Deserialize<List<Note>>(json);

    if(loadedNotes != null && loadedNotes.Count > 0)
    {
        noteHolder.SetNotes(loadedNotes);  
    }
}

// This tells the web app to use HTTPS redirection protocol
// Meaning the app can respond to GET, POST, DELETE, etc. requests
app.UseHttpsRedirection();

// Get all notes
app.MapGet("/notes", () => 
{
    List<Note>? notes = noteHolder.GetNotes();
    return Results.Ok(notes);
}).WithName("GetNotes");

// Get note by index
app.MapGet("/notes/{index}", (int index) =>
{
    Note? note = noteHolder.GetNote(index); // assuming this returns null if not found
    if (note == null) return Results.NotFound();
    return Results.Ok(note);

}).WithName("GetNote");

// Delete note by index
app.MapDelete("/notes/{index}", (int index) =>
{
    if(noteHolder.DeleteNote(index)) return Results.Ok();
    
    return Results.NotFound();

}).WithName("DeleteNote");

// Post new note
app.MapPost("/notes", (string noteContent) =>
{
    if(noteContent == null) return Results.BadRequest();
    return Results.Created("/notes", noteHolder.PostNote(noteContent));
}).WithName("PostNote");

// runs the server
app.Run();