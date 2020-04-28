using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.StorageInterfaces
{
    public interface INoteRepository
    {
        Note GetNote(int id);
        IEnumerable<Note> GetAllNotes();
        Note Add(Note note);
        Note Update(Note noteChanges);
        Note Delete(int id);
    }
}
