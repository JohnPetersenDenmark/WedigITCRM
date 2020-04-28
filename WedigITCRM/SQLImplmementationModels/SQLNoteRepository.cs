using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.SQLImplmementationModels
{
    public class SQLNoteRepository : INoteRepository
    {
        private AppDbContext context;
        public SQLNoteRepository(AppDbContext context)
        {
            this.context = context;
        }


        public Note Add(Note note)
        {
          
            context.Notes.Add(note);
            context.SaveChanges();
            return note;
        }

        public Note Delete(int id)
        {
            Note note;

            note = context.Notes.Find(id);
            if (note != null)
            {
                context.Notes.Remove(note);
                context.SaveChanges();
            }
            return note;
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return context.Notes;
        }

        public Note GetNote(int id)
        {
            return context.Notes.Find(id); ;
        }

        public Note Update(Note noteChanges)
        {
            var note = context.Notes.Attach(noteChanges);
            note.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return noteChanges;
        }
    }
}
